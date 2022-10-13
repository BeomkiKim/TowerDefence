using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCtrl : MonoBehaviour
{
    PlayerState player;
    SoundManager sound;
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
        sound = GameObject.Find("GameManager").GetComponent<SoundManager>();
    }

    private void OnMouseDown()
    {
        
        if (kind == ItemKind.Blue)
        {
            player.blueCount++;
            sound.SendMessage("GetItem");
            Destroy(gameObject);
        }
        else if (kind == ItemKind.Red)
        {
            player.redCount++;
            sound.SendMessage("GetItem");
            Destroy(gameObject);
        }
        else if (kind == ItemKind.Yellow)
        {
            player.yellowCount++;
            sound.SendMessage("GetItem");
            Destroy(gameObject);
        }

    }

}
