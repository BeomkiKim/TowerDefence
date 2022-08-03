using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 15f;
    float countdown = 2f;

    public Text waveCountdownText;

    int waveIndex = 10;
    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Floor(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        for(int i = 0; i<waveIndex;i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);
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
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
