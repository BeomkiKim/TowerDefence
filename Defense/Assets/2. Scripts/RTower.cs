using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTower : MonoBehaviour
{
    Animator anim;
    public float rTowerPower;
    public float explosionRadius;

    public bool ice = false;
    public bool poision = false;

    public float slowPercent;
    public float slowTime;
    Collider[] colliders;

    float fireCountdown = 0f;
    public float fireRate = 1f;

    public float poisionPercent;
    private void Start()
    {
        anim = GetComponent<Animator>();
        if (slowPercent == 0)
            return;
        if (slowTime == 0)
            return;
    }
    private void Update()
    {
        colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                if (fireCountdown <= 0f)
                {
                    anim.Play("Attack");
                    fireCountdown = 1f / fireRate;
                }
                fireCountdown -= Time.deltaTime;

            }
        }
    }
    void Attack()
    {
        if (ice && !poision)
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
        else if(ice && poision)
        {
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Enemy")
                {
                    Ice(collider.transform);
                    Poision(collider.transform);
                    Damage(collider.transform);
                }
            }
        }
        else if(!ice && poision)
        {
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Enemy")
                {
                    Poision(collider.transform);
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
    void Poision(Transform enemy)
    {
        enemy.SendMessage("PoisionDamage", poisionPercent);
    }




    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

    }
}
