using UnityEngine;


public class Bullet : MonoBehaviour
{
    Transform target;

    public float speed = 70f;
    public GameObject impactEffect;



    public void Seek(Transform _target)
    {
        target = _target;
    }
    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceTisFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceTisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceTisFrame, Space.World);

    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(effectIns, 2f);

        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}