using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTower : MonoBehaviour
{
    Animator anim;
    public float rTowerPower;
    public float explosionRadius;

    public bool ice = false;
    public float slowPercent;
    public float slowTime;
    Collider[] colliders;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                anim.Play("Attack");

            }
        }
    }
    void Attack()
    {
        if (ice)
        {
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Enemy")
                {
                    Ice(collider.transform);
                    Damage(collider.transform);
                }
            }



        }
        else
        {
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Enemy")
                {

                    Damage(collider.transform);
                }
            }

        }
    }

    void Damage(Transform enemy)
    {
        enemy.SendMessage("Damage", rTowerPower);
    }
    void Ice(Transform enemy)
    {
        enemy.SendMessage("SlowBullet", slowPercent);
        enemy.SendMessage("SlowTime", slowTime);
    }




    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

    }
}
