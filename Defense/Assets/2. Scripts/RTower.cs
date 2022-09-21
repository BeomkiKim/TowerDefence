using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RTower : MonoBehaviour
{
    Animator anim;
    public float explosionRadius;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Enemy")
        {
            anim.Play("Attack");
            Debug.Log(other.tag);
        }
    }


    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, explosionRadius);

    //}
}
