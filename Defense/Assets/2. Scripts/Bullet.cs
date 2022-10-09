using UnityEngine;


public class Bullet : MonoBehaviour
{
    public Transform target;

    public float bulletPower;
    public float speed = 70f;
    public float explosionRadius = 0f;

    public GameObject impactEffect;

    public bool iceBullet = false;
    public float slowPercent;
    public float slowTime;

    public bool poisionBullet = false;
    public float poisionPercent;



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

        if (dir.magnitude <= distanceTisFrame)
        {
            HitTarget(target);
            return;
        }

            transform.Translate(dir.normalized * distanceTisFrame, Space.World);
            transform.LookAt(target);
            transform.localRotation =
            Quaternion.Slerp(transform.localRotation,
            Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }

	void HitTarget (Transform enemy)
	{
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectIns, 5f);

        if (explosionRadius > 0f && !iceBullet && !poisionBullet)
        {
            Explode();
        }
        else if (iceBullet && explosionRadius == 0f && !poisionBullet) //bbb
        {
            enemy.SendMessage("SlowBullet", slowPercent);
            enemy.SendMessage("SlowTime", slowTime);


            Damage(target);
        }
        else if (iceBullet && explosionRadius > 0f && !poisionBullet)//bbr
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Enemy")
                {
                    Damage(collider.transform);
                    collider.transform.SendMessage("SlowBullet", slowPercent);
                    collider.transform.SendMessage("SlowTime", slowTime);
                }
            }
        }
        else if (poisionBullet && explosionRadius > 0f && !iceBullet)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
            foreach (Collider collider in colliders)
            {
                if (collider.tag == "Enemy")
                {
                    Damage(collider.transform);
                    collider.transform.SendMessage("PoisionDamage", poisionPercent);
                }
            }
        }
        else if (!iceBullet && explosionRadius == 0f && poisionBullet)
        {
            enemy.SendMessage("PoisionDamage", poisionPercent);
            Damage(target);
        }
        else if (iceBullet && explosionRadius == 0f && poisionBullet)
        {
            enemy.SendMessage("SlowBullet", slowPercent);
            enemy.SendMessage("SlowTime", slowTime);
            enemy.SendMessage("PoisionDamage", poisionPercent);
            Damage(target);
        }
        else
        {
            Damage(target);
        }

        Destroy(gameObject);
	}
    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "Enemy")
            {
                Damage(collider.transform);
            }
        }
    }
    void Damage(Transform enemy)
    {
        enemy.SendMessage("Damage", bulletPower);
        //Destroy(enemy.gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);

    }
}