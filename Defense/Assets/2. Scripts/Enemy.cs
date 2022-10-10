using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public float gold;
    public float startSpeed = 10f;
    [HideInInspector]
    public float speed;
    EnemyMovement enemyMove;
    WaveSpawner wave;

    PlayerState player;

    public Image healthBar;

    public bool isKotlin;
    public float poiDmg;


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

    public float poisionTime;

    private void Start()
    {
        
        player = GameObject.Find("GameManager").GetComponent<PlayerState>();
        wave = GameObject.Find("GameManager").GetComponent<WaveSpawner>();
        enemyMove = GetComponent<EnemyMovement>();
        speed = startSpeed;
        
        
        if (wave.stage <= 6 && !(wave.stage % 10 == 0))
        {
            maxHp = wave.stage * 150;
            gold = wave.stage * 20;
        }
        else if(wave.stage > 6 && !(wave.stage % 10 == 0) && wave.stage<10)
        {
            maxHp = wave.stage * 1000;
            gold = wave.stage * 5;
        }    
        else if (wave.stage > 10 && wave.stage <= 16 && !(wave.stage % 10 == 0))
        {
            gold = wave.stage * 2;
            maxHp = wave.stage * 200;
        }
        else if(wave.stage > 16 && wave.stage < 20)
        {
            maxHp = wave.stage * 1500;
            gold = wave.stage;
        }
        else if (wave.stage > 20 && wave.stage <= 30 && !(wave.stage % 10 == 0))
        {
            gold = wave.stage;
            maxHp = wave.stage * 2000;
        }
        else if (wave.stage > 30 && !(wave.stage % 10 == 0))
        {
            gold = wave.stage;
            maxHp = wave.stage * 2500;
        }
        else if (wave.stage % 10 == 0)
        {
            gold = wave.stage * 10;
            maxHp = wave.stage * 3000;
        }

        hp = maxHp;

        foreach (var item in percentage)
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

        if (poisionTime>0.0f)
        {
            poisionTime -= Time.deltaTime;

            if(!isKotlin)
                StartCoroutine(Poision(poiDmg));
        }
        if(poisionTime<=0.0f)
        {
            poisionTime = 0;
        }
        healthBar.fillAmount = hp / maxHp;
    }

    public void TakeDamage(float amount)
    {
        hp -= amount;
    }

    public void Damage(float damage)
    {
        hp -= damage;
    }
    public void SlowTime(float value)
    {
        enemyMove.iceTime += value;
    }
    public void SlowBullet(float pct)
    {
        
        speed = startSpeed * (1f - pct);
    }
    public void Slow(float pct)//laser slow
    {
        speed = startSpeed * (1f - pct);
    }
    public void PoisionDamage(float dmg)
    {
        poisionTime += 3.0f;
        poiDmg = dmg;
        

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

    IEnumerator Poision(float dmg)
    {
        isKotlin = true;
        yield return new WaitForSeconds(1.0f);
        hp -= (maxHp * dmg);
        yield return new WaitForSeconds(1.0f);
        hp -= (maxHp * dmg);
        yield return new WaitForSeconds(1.0f);
        hp -= (maxHp * dmg);
        isKotlin = false;

    }
}
