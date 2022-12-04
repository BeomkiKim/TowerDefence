using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerState : MonoBehaviour
{

    public GameObject gameoverObj;

    float startMoney = 500f;
    public float currentMoney;
    public int currentLife;
    int maxlife = 3;

    public int redCount;
    public int blueCount;
    public int yellowCount;

    public Text redCountText;
    public Text blueCountText;
    public Text yellowCountText;
    public Text moneyText;

    SoundManager sound;


    private void Start()
    {
        sound = GetComponent<SoundManager>();
        currentMoney = startMoney;
        currentLife = maxlife;
        redCount = 0;
        blueCount = 0;
        yellowCount = 0;
    }

    private void Update()
    {
        redCountText.text = redCount.ToString();
        blueCountText.text = blueCount.ToString();
        yellowCountText.text = yellowCount.ToString();
        moneyText.text = currentMoney.ToString("$ 00000");

        if(currentLife <= 0)
        {
            Time.timeScale = 0;
            gameoverObj.SetActive(true);
        }
    }

    void Set()
    {
        currentMoney -= 100;
    }

    void Hit()
    {
        sound.DamageSound();
        currentLife -= 1;
    }

}
