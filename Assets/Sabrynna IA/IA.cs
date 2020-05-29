using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA : MonoBehaviour
{
    public Animator Enemy;
    public int Life;
    public bool Patrol;
    public bool Attack;
    public Transform Target;
    public float speed;
    public float speedTurn;

    private void Start()
    {
        Patrol = true;
    }

    private void FixedUpdate()
    {
        if (Patrol && !Attack)
        {
            Enemy.SetBool("isWalk",true);

            Vector3 player = Target.position;
            transform.position = Vector3.MoveTowards(transform.position, player , speed * Time.deltaTime);

            Vector3 distancce = Target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(distancce);

           transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * (speedTurn / 360.0f));
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Enemy.SetBool("isWalk", false);

            Attack = true;
            OnAttack();
        }

        if (other.gameObject.tag == "Shot")
        {
            SetDamage();
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.tag == "Player" && Attack)
        {
            Patrol = true;
            Attack = false;
            CancelInvoke("OnAttackGatilho");
        }
 
    }

    void OnAttack()
    {
        InvokeRepeating("OnAttackGatilho", 0, 1);
    }

    void OnAttackGatilho()
    {
        Enemy.SetTrigger("isAttack");
    }

    public void SetDamage()
    {
        Life -= 1;
        if(Life <= 0)
        {
            EnemyDie();
        }
    }

    public void EnemyDie()
    {
        Enemy.SetTrigger("isDie");
    }

}
