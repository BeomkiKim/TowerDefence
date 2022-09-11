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
    BuildManager buildManager;
    public TurretBlueprint turretBlueprint;

    public int redUpgradeCount;
    public int blueUpgradeCount;
    public int yellowUpgradeCount;

    public int totalUpgradeCount;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        player = FindObjectOfType<PlayerState>();
        buildManager = GameObject.Find("GameManager").GetComponent<BuildManager>();
        turretBlueprint = GetComponent<TurretBlueprint>();
        startColor = rend.material.color;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffet;
    }
    private void OnMouseDown()
    {
        
        if(turret != null && !EventSystem.current.IsPointerOverGameObject())
        {
            buildManager.SelectNode(this);
            return;
        }

        if (player.currentMoney >= turretCost && player.currentMoney > 0 && !EventSystem.current.IsPointerOverGameObject())
        {
            buildManager.SelectTurretToBuild();
            player.SendMessage("Set");
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, GetBuildPosition(), Quaternion.identity);
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

    public void RedUpgradeTurret()
    {
        if (player.redCount < 1)
            return;

        player.redCount -= 1;

        Destroy(turret);

        switch(redUpgradeCount)
        {
            case 0:
                GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradePrefab[0], transform.position + positionOffet, Quaternion.identity);
                turret = _turret;
                return; //»¡°­º¸¼®1°³
            case 1:
                GameObject __turret = (GameObject)Instantiate(turretBlueprint.redredUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                turret = __turret;
                return;//»¡°­º¸¼® 2°³
            case 2:
                GameObject ___turret = (GameObject)Instantiate(turretBlueprint.redUpgradePrefab[0], transform.position + positionOffet, Quaternion.identity);
                turret = ___turret;
                return;//»¡°­º¸¼® 3°³
        }
        switch (blueUpgradeCount)
        {
            case 1:
                if (yellowUpgradeCount == 0)
                {
                    GameObject __turret = (GameObject)Instantiate(turretBlueprint.redblueUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                    turret = __turret;
                }//ÆÄ¶û 1 »¡°­ 1
                else if (yellowUpgradeCount == 1)
                {
                    GameObject __turret = (GameObject)Instantiate(turretBlueprint.redUpgradePrefab[3], transform.position + positionOffet, Quaternion.identity);
                    turret = __turret;
                }
                return; //ÆÄ¶û 1 ³ë¶û1 »¡°­ 1
            case 2:
                GameObject ___turret = (GameObject)Instantiate(turretBlueprint.blueUpgradePrefab[1], transform.position + positionOffet, Quaternion.identity);
                turret = ___turret;
                return;//ÆÄ¶û2 »¡°­1
        }
        switch (yellowUpgradeCount)
        {
            case 1:
                if (blueUpgradeCount == 0)
                {
                    GameObject __turret = (GameObject)Instantiate(turretBlueprint.redyellowUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                    turret = __turret;
                } // ³ë¶û 1 »¡°­ 1
                else if(blueUpgradeCount == 1)
                {
                    GameObject __turret = (GameObject)Instantiate(turretBlueprint.redUpgradePrefab[3], transform.position + positionOffet, Quaternion.identity);
                    turret = __turret;
                }
                return;//³ë¶û1 »¡°­ 1 ÆÄ¶û 1
            case 2:
                GameObject ___turret = (GameObject)Instantiate(turretBlueprint.yellowUpgradePrefab[1], transform.position + positionOffet, Quaternion.identity);
                turret = ___turret;
                return;//³ë¶û2 »¡°­1
        }
        redUpgradeCount += 1;
    }
    public void BlueUpgradeTurret()
    {
        if (player.blueCount < 1)
            return;

        player.blueCount -= 1;

        Destroy(turret);
        switch (blueUpgradeCount)
        {
            case 0:
                GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradePrefab[1], transform.position + positionOffet, Quaternion.identity);
                turret = _turret;
                return; // ÆÄ¶û 1
            case 1:
                GameObject __turret = (GameObject)Instantiate(turretBlueprint.blueblueUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                turret = __turret;
                return; // ÆÄ¶û 2
            case 2:
                GameObject ___turret = (GameObject)Instantiate(turretBlueprint.blueUpgradePrefab[0], transform.position + positionOffet, Quaternion.identity);
                turret = ___turret;
                return; // ÆÄ¶û 3
        }
        switch (redUpgradeCount)
        {
            case 1:
                if (yellowUpgradeCount == 0)
                {
                    GameObject __turret = (GameObject)Instantiate(turretBlueprint.redblueUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                    turret = __turret;
                }//»¡°­ 1 ÆÄ¶û 1
                else if(yellowUpgradeCount == 1)
                {
                    GameObject __turret = (GameObject)Instantiate(turretBlueprint.redUpgradePrefab[3], transform.position + positionOffet, Quaternion.identity);
                    turret = __turret;
                }//ÆÄ»¡³ë
                return; 
            case 2:
                GameObject ___turret = (GameObject)Instantiate(turretBlueprint.redUpgradePrefab[1], transform.position + positionOffet, Quaternion.identity);
                turret = ___turret;
                return;
                //»¡2 ÆÄ1
        }

        switch (yellowUpgradeCount)
        {
            case 1:
                if (redUpgradeCount == 0)
                {
                    GameObject __turret = (GameObject)Instantiate(turretBlueprint.blueyellowUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                    turret = __turret;
                }//³ë 1 ÆÄ 1
                else if(redUpgradeCount == 1)
                {
                    GameObject __turret = (GameObject)Instantiate(turretBlueprint.redUpgradePrefab[3], transform.position + positionOffet, Quaternion.identity);
                    turret = __turret;
                }//³ë1 ÆÄ1 »¡1
                return;
            case 2:
                GameObject ___turret = (GameObject)Instantiate(turretBlueprint.yellowUpgradePrefab[2], transform.position + positionOffet, Quaternion.identity);
                turret = ___turret;
                return;
                //³ë2 ÆÄ1
        }
        blueUpgradeCount += 1;
    }
    public void YellowUpgradeTurret()
    {
        if (player.yellowCount < 1)
            return;

        player.yellowCount -= 1;

        Destroy(turret);


        switch (yellowUpgradeCount)
        {
            case 0:
                GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradePrefab[2], transform.position + positionOffet, Quaternion.identity);
                turret = _turret;
                return;// ³ë1
            case 1:
                GameObject __turret = (GameObject)Instantiate(turretBlueprint.yellowyellowUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                turret = __turret;
                return;// ³ë2
            case 2:
                GameObject ___turret = (GameObject)Instantiate(turretBlueprint.yellowUpgradePrefab[0], transform.position + positionOffet, Quaternion.identity);
                turret = ___turret;
                return;// ³ë3
        }
        switch (blueUpgradeCount)
        {
            case 1:
                if (redUpgradeCount == 0)
                {
                    GameObject __turret = (GameObject)Instantiate(turretBlueprint.blueyellowUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                    turret = __turret;
                } //³ë1 ÆÄ 1
                else if(redUpgradeCount == 1)
                {
                    GameObject __turret = (GameObject)Instantiate(turretBlueprint.redUpgradePrefab[3], transform.position + positionOffet, Quaternion.identity);
                    turret = __turret;
                }//³ë1 »¡ 1ÆÄ1
                return;
            case 2:
                GameObject ___turret = (GameObject)Instantiate(turretBlueprint.blueUpgradePrefab[2], transform.position + positionOffet, Quaternion.identity);
                turret = ___turret;
                return;
                //ÆÄ2 ³ë 1
        }
        switch (redUpgradeCount)
        {
            case 1:
                if (blueUpgradeCount == 0)
                {
                    GameObject __turret = (GameObject)Instantiate(turretBlueprint.redyellowUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                    turret = __turret;
                } //»¡ 1 ³ë 1
                if(blueUpgradeCount == 1)
                {
                    GameObject __turret = (GameObject)Instantiate(turretBlueprint.redUpgradePrefab[3], transform.position + positionOffet, Quaternion.identity);
                    turret = __turret;
                } //»¡ 1 ÆÄ1 ³ë1
                return;
            case 2:
                GameObject ___turret = (GameObject)Instantiate(turretBlueprint.redUpgradePrefab[2], transform.position + positionOffet, Quaternion.identity);
                turret = ___turret;
                return;
                //»¡ 2 ³ë1
        }
        yellowUpgradeCount += 1;
    }

}
