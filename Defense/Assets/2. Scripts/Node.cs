using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffet;

    GameObject turret;

    Renderer rend;
    Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    private void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Can't build there!");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position+positionOffet, transform.rotation);
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
