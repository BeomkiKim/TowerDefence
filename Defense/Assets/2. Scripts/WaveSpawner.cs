using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public int stage = 0;
    public Transform[] enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 15f;
    float countdown = 2f;

    public Text waveCountdownText;

    int waveIndex = 10;
    private void Update()
    {
        if (countdown <= 0f)
        {
            stage++;
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;

        }
        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Floor(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        if (stage % 10 != 0)
        {
            for (int i = 0; i < waveIndex; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(0.5f);
            }
        }
        else if(stage % 10 == 0)
        {
            Instantiate(enemyPrefab[0], spawnPoint.position, spawnPoint.rotation);
        }
        if (waveIndex < 30)
        {
            waveIndex++;
            waveIndex++;
            timeBetweenWaves++;
        }
    }

    void SpawnEnemy()
    {
        switch(stage%10)
        {
            case 0:
                break;
            case 1:
            case 2:
                Instantiate(enemyPrefab[1], spawnPoint.position, spawnPoint.rotation);
                break;
            case 3:
            case 4:
                Instantiate(enemyPrefab[2], spawnPoint.position, spawnPoint.rotation);
                break;
            case 5:
            case 6:
                Instantiate(enemyPrefab[3], spawnPoint.position, spawnPoint.rotation);
                break;
            case 7:
            case 8:
            case 9:
                Instantiate(enemyPrefab[4], spawnPoint.position, spawnPoint.rotation);
                break;
        }
    }
}
