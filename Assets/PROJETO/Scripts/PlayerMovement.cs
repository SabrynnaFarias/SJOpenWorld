using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float Life;
    public float speed = 7.5f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    public Transform playerCameraParent;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;

    CharacterController characterController;
    Vector3 moveDirection = Vector3.zero;
    Vector2 rotation = Vector2.zero;

    public Animator Anin;
    bool Atk;
    float TimeToAttack;

    [HideInInspector]
    public bool canMove = true;

    public Image LifeBar;

    bool Die;
    public GameObject Derrota;

    public AudioSource Sounds;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        rotation.y = transform.eulerAngles.y;
    }

    void Update()
    {
        if (!Die)
        {
            if (characterController.isGrounded)
            {
                if (!Atk)
                {

                    Vector3 forward = transform.TransformDirection(Vector3.forward);
                    Vector3 right = transform.TransformDirection(Vector3.right);
                    float curSpeedX = canMove ? speed * Input.GetAxis("Vertical") : 0;
                    float curSpeedY = canMove ? speed * Input.GetAxis("Horizontal") : 0;
                    moveDirection = (forward * curSpeedX) + (right * curSpeedY);

                    float Check = curSpeedX + curSpeedY;
                    if (Check == 0)
                    {
                        Anin.SetBool("isIddle", true);
                        Anin.SetBool("isWalk", false);
                    }
                    else
                    {
                        Anin.SetBool("isWalk", true);
                        Anin.SetBool("isIddle", false);
                    }

                    if (Input.GetButton("Jump") && canMove)
                    {
                        moveDirection.y = jumpSpeed;
                        Anin.SetTrigger("isJump");
                    }
                }
            }


            TimeToAttack += Time.deltaTime;
            if (Input.GetKeyDown(KeyCode.Q) && TimeToAttack >= 2)
            {
                Atk = true;
                TimeToAttack = 0;
                Anin.SetTrigger("isAttack");

                Sounds.Play();
                Invoke("Cancel", 1f);

            }

            moveDirection.y -= gravity * Time.deltaTime;
            characterController.Move(moveDirection * Time.deltaTime);
            if (canMove)
            {
                rotation.y += Input.GetAxis("Mouse X") * lookSpeed;
                rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
                rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
                playerCameraParent.localRotation = Quaternion.Euler(rotation.x, 0, 0);
                transform.eulerAngles = new Vector2(0, rotation.y);
            }
        }
    }


    void Cancel()
    {
        Atk = false;
    }

   public void HitPlayer()
    {
        Life--;
        float cal = Life / 25;
        LifeBar.fillAmount = cal;

        if(Life <= 0)
        {
            
            Die = true;
            Anin.SetTrigger("isDie");
            Invoke("DerrotaCancel", 3);
        }
    }

    void DerrotaCancel()
    {
        Derrota.SetActive(true);
        Invoke("DerrotaChangeScene", 3);
    }

    void DerrotaChangeScene()
    {
        SceneManager.LoadScene(0);
    }



}
