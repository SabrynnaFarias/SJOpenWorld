using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public Animator Enemy;
    public int Life;
    public bool Patrol;
    public bool Attack;
    public Transform[] Target;
    public float speed;
    public float speedTurn;
    bool die;
    public int TargetID;

    public AudioSource Sound;
    

    private void Start()
    {
        GameObject target = GameObject.Find("Castle");
        GameObject targetPlayer = GameObject.Find("Player");
        Target[1] = target.transform;
        Target[0] = targetPlayer.transform;

        TargetID = 1;
        Patrol = true;
    }

    private void FixedUpdate()
    {
        if (Patrol && !Attack && !die)
        {
            Enemy.SetBool("isWalk",true);
            

            Vector3 player = Target[TargetID].position;
            transform.position = Vector3.MoveTowards(transform.position, player , speed * Time.deltaTime);

            Vector3 distancce = Target[TargetID].position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(distancce);

           transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * (speedTurn / 360.0f));
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && !die)
        {
            TargetID = 0;
            Attack = true;
            Sound.Play();
            Patrol = false;
            Enemy.SetTrigger("isAttack");
            Invoke("OnAttackGatilho", 0.25f);
            
        }

        if (other.gameObject.tag == "Shot" && !die)
        {
            SetDamage();
        }
    }

   

    void OnAttackGatilho()
    {
        Patrol = true;
        Enemy.SetBool("isWalk", true);

        Attack = false;
    }

    public void SetDamage()
    {
        Life--;
        if(Life <= 0)
        {
            EnemyDie();
        }
    }

    public void EnemyDie()
    {
        die = true;
        Enemy.SetTrigger("isDie");
    }

}
