using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public int gold;
    public float speed = 10f;
    Transform target;
    int wavepointIndex = 0;
    PlayerState player;

    public int[] percentage =
    {
        70,
        10,
        10,
        10,
    };
    [SerializeField]
    int total;

    public GameObject[] dropItemPrefab;
    int randomNumber;



    private void Start()
    {
        player = GameObject.Find("GameManager").GetComponent<PlayerState>();
        target = WayPoints.points[0];
        hp = maxHp;
        foreach(var item in percentage)
        {
            total += item;
        }

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
        if(hp <= 0f)
        {
            EnemyDie();
        }
    }

    void GetNextWaypoint()
    {
        if(wavepointIndex >= WayPoints.points.Length -1)
        {
            player.SendMessage("Hit");
            player.currentMoney -= gold;
            Destroy(gameObject);
            return;
        }
        wavepointIndex++;
        target = WayPoints.points[wavepointIndex];

    }

    void Damage(float damage)
    {
        hp -= damage;
    }

    private void OnDestroy()
    {
        player.currentMoney += gold;
    }

    void DropItem()
    {
        if (dropItemPrefab.Length == 0)
            return;

        randomNumber = Random.Range(0, total);

        for(int i = 0; i<percentage.Length; i++)
        {
            if(randomNumber <= percentage[i])
            {
                GameObject dropItem = dropItemPrefab[i];
                Instantiate(dropItem, transform.position+new Vector3(0,3f,0), dropItem.transform.rotation);
                return;

            }
            else
            {
                randomNumber -= percentage[i];
            }
        }
    }

    void EnemyDie()
    {
        DropItem();
        Destroy(gameObject);
    }
}
