using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ButtonCtrl : MonoBehaviour
{
    public GameObject howToPlay;

    public void ClickHowToPlay()
    {
        howToPlay.SetActive(true);
    }


    public void ClickX()
    {
        howToPlay.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKey("m"))
        {
            AudioListener.volume = 0;
        }
        if (Input.GetKey("n"))
        {
            AudioListener.volume = 1;
        }
    }

}
