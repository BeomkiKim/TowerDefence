using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffet;

    GameObject turret;

    Renderer rend;
    Color startColor;
    public PlayerState player;
    public int turretCost = 100;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        player = FindObjectOfType<PlayerState>();

        startColor = rend.material.color;
    }
    private void OnMouseDown()
    {
        
        if(turret != null)
        {
            Debug.Log("Can't build there!");
            return;
        }

        if (player.currentMoney >= turretCost && player.currentMoney > 0 && !EventSystem.current.IsPointerOverGameObject())
        {
            player.SendMessage("Set");
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffet, transform.rotation);
        }
    }
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;

    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
