using System.Collections;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    public float cost;

    Enemy targetEnemy;

    [Header("타워설정")]
    public float range = 15f;
    public float fireRate = 1f;
    float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firePoint;

    [Header("아이스")]
    public bool useLaser = false;
    public GameObject iceEffect;
    public Transform secondFirePoint;

    public int damagerOverTime = 20;
    public float slowPct = 0.5f;

    public LineRenderer lineRenderer;

    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        if (secondFirePoint == null)
            return;
        if (iceEffect == null)
            return;
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;

            }
        }

        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else{ target = null; }
    }
    private void Update()
    {
        if (target == null)
        {
            if(useLaser)
            {
                if (lineRenderer.enabled)
                    lineRenderer.enabled = false;
            }    
            return;

        }


        LockOnTarget();

        if(useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;

            }
            fireCountdown -= Time.deltaTime;
        }
        
     


    }
    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }


    void Laser()
    {
        targetEnemy.TakeDamage(damagerOverTime * Time.deltaTime);
        targetEnemy.Slow(slowPct);
        GameObject effectIns = (GameObject)Instantiate(iceEffect, firePoint.position, firePoint.rotation);
        GameObject secondEffectIns = (GameObject)Instantiate(iceEffect, secondFirePoint.position, secondFirePoint.rotation);
        Destroy(effectIns, 0.5f);
        Destroy(secondEffectIns, 0.5f);
        if (!lineRenderer.enabled)
            lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

    }
    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGo.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);//seek함수 : 찾기
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);

    }


}
