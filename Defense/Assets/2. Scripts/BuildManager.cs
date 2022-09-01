using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    public GameObject standardTurretPrefab;
    GameObject turretToBuild;


    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }
    

    private void Start()
    {
        turretToBuild = standardTurretPrefab;
    }
    

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }

}
