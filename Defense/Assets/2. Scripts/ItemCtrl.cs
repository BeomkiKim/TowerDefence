using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    PlayerState player;
    public enum ItemKind
    {
        Empty,
        Blue,
        Red,
        Yellow,
    };

    public ItemKind kind;

    private void Start()
    {
        if (kind == ItemKind.Empty)
            Destroy(gameObject);

        player = GameObject.Find("GameManager").GetComponent<PlayerState>();
    }

    private void OnMouseDown()
    {
        if (kind == ItemKind.Blue)
        {
            player.blueCount++;
            Destroy(gameObject);
        }
        else if (kind == ItemKind.Red)
        {
            player.redCount++;
            Destroy(gameObject);
        }
        else if (kind == ItemKind.Yellow)
        {
            player.yellowCount++;
            Destroy(gameObject);
        }



    }

}