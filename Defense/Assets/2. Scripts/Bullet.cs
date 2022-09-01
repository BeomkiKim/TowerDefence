using UnityEngine;


public class Bullet : MonoBehaviour
{
    Transform target;

    public float bulletPower;
    public float speed = 70f;
    public float explosionRadius = 0f;

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
        transform.LookAt(target);
        transform.localRotation =
        Quaternion.Slerp(transform.localRotation,
        Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }

	void HitTarget ()
	{
		GameObject effectIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
		Destroy(effectIns, 5f);

		if (explosionRadius > 0f)
		{
			Explode();
		} else
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