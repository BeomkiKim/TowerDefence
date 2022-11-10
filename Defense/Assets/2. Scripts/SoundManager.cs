using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip enemyDieSound;
    public AudioClip itemSound;
    public AudioClip spawnSound;
    public AudioClip bossSpawnSound;
    public AudioClip upGradeSound;
    public AudioClip damageSound;


    public void EnemyDie()
    {
        audioSource.PlayOneShot(enemyDieSound);
    }
    public void GetItem()
    {
        audioSource.volume *= 2f;
        audioSource.PlayOneShot(itemSound);
    }
    public void SpawnSound()
    {
        audioSource.PlayOneShot(spawnSound);
    }

    public void BossSound()
    {
        audioSource.PlayOneShot(bossSpawnSound);
    }

    public void UpgradeSound()
    {
        audioSource.PlayOneShot(upGradeSound);
    }

    public void DamageSound()
    {
        audioSource.PlayOneShot(damageSound);
    }
}
