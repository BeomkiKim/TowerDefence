using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 10f;
    Transform target;
    int wavepointIndex = 0;


    private void Start()
    {
        target = WayPoints.points[0];

    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized*speed *Time.deltaTime,Space.World);

        if(Vector3.Distance(transform.position, target.position)<= 0.4f)
        {
            GetNextWaypoint();
        }

        transform.localRotation =
            Quaternion.Slerp(transform.localRotation,
            Quaternion.LookRotation(dir), 5 * Time.deltaTime);
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= WayPoints.points.Length -1)
        {
            Destroy(gameObject);
        }
        wavepointIndex++;
        target = WayPoints.points[wavepointIndex];


    }
}
