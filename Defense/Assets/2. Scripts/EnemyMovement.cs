using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    Transform target;
    int wavepointIndex = 0;
    PlayerState player;

    Enemy enemy;
    public float iceTime;



    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Enemy>();

        player = GameObject.Find("GameManager").GetComponent<PlayerState>();
        target = WayPoints.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }

        if(iceTime > 0f)
        {
            StartCoroutine(IceTimeStart());
        }    
        else
            enemy.speed = enemy.startSpeed;

        
        transform.localRotation =
            Quaternion.Slerp(transform.localRotation,
            Quaternion.LookRotation(dir), 5 * Time.deltaTime);

    }

    void GetNextWaypoint()
    {
        if (wavepointIndex >= WayPoints.points.Length - 1)
        {
            player.SendMessage("Hit");
            player.currentMoney -= enemy.gold;
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = WayPoints.points[wavepointIndex];

    }

    IEnumerator IceTimeStart()
    {
        yield return new WaitForSeconds(iceTime);
        enemy.speed = enemy.startSpeed;
        iceTime = 0f;

    }
}
