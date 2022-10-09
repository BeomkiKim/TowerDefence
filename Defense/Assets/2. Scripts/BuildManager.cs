using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject standardTurretPrefab;
    GameObject turretToBuild;
    Node selectedNode;
    public NodeUI nodeUI;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        Screen.SetResolution(1280, 720, false);
        instance = this;
    }
    private void Start()
    {
        SelectTurretToBuild();
    }

    public void SelectTurretToBuild()
    {
        turretToBuild = standardTurretPrefab;
        DeselectNode();
    }

    

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

    public void SelectNode(Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}
