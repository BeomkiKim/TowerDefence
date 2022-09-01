using UnityEngine;

public class Shop : MonoBehaviour
{

    public GameObject[] gems;
    public bool isGemOpen;


    public void ClickGem()
    {
        if(!isGemOpen)
        {
            gems[0].SetActive(true);
            gems[1].SetActive(true);
            gems[2].SetActive(true);
            isGemOpen = true;
        }
        else if(isGemOpen)
        {
            gems[0].SetActive(false);
            gems[1].SetActive(false);
            gems[2].SetActive(false);
            isGemOpen = false;
        }
    }
}
