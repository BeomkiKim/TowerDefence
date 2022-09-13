using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public int gold;
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    EnemyMovement enemyMove;

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
        enemyMove = GetComponent<EnemyMovement>();
        speed = startSpeed;
        hp = maxHp;
        foreach(var item in percentage)
        {
            total += item;
        }

    }

    private void Update()
    {
        if (hp <= 0f)
        {
            EnemyDie();
        }
    }

    public void TakeDamage(float amount)
    {
        hp -= amount;
    }

    public void Damage(float damage)
    {
        hp -= damage;
    }
    public void SlowBullet(float pct)
    {
        enemyMove.iceTime += 1f;
        speed = startSpeed * (1f - pct);
    }
    public void Slow(float pct)
    {
        speed = startSpeed * (1f - pct);
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
