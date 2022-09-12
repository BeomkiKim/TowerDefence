using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
    float startMoney = 300f;
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


    private void Start()
    {
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
        moneyText.text = currentMoney.ToString("$ 0000");

        if(currentLife <= 0)
        {
            Debug.Log("GameOver");
            Time.timeScale = 0;
        }
    }

    void Set()
    {
        currentMoney -= 100;
    }

    void Hit()
    {
        currentLife -= 1;
    }
}
