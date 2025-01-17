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
    public float totalTurretCost = 100;

    bool isNode;
    bool isUi;

    public int turretNumber;

    SoundManager sound;


    private void Start()
    {
        rend = GetComponent<Renderer>();
        player = FindObjectOfType<PlayerState>();
        buildManager = GameObject.Find("GameManager").GetComponent<BuildManager>();
        sound = GameObject.Find("GameManager").GetComponent<SoundManager>();
        turretBlueprint = GetComponent<TurretBlueprint>();
        startColor = rend.material.color;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffet;
    }
    private void OnMouseDown()
    {
        int layerMask = 1 << 8;

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        isNode = Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask);


        isUi = EventSystem.current.IsPointerOverGameObject();

        if (turret != null && !isUi && isNode)
        {
            buildManager.SelectNode(this);
            
            return;
        }

        if (player.currentMoney >= turretCost && player.currentMoney > 0 && !isUi &&isNode)
        {
            buildManager.SelectTurretToBuild();
            player.SendMessage("Set");
            turretNumber = 15;
            GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
            turret = (GameObject)Instantiate(turretToBuild, GetBuildPosition(), Quaternion.identity);
            
        }

        //Debug.Log(hit.collider.gameObject);
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;

    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public void UpgradeTurret(int GemNumer)
    {
        
        if(totalUpgradeCount == 1) //���׷��̵带 �̹� 1�� �� ��� 
        {
            
            if (player.currentMoney >= 150)
            {
                sound.SendMessage("UpgradeSound");
                if (redUpgradeCount == 1 && blueUpgradeCount == 0 && yellowUpgradeCount == 0)
                {
                    switch (GemNumer)
                    {
                        case 0://red red
                            Destroy(turret);
                            player.redCount--;
                            player.currentMoney -= 150;
                            GameObject redredTurret = (GameObject)Instantiate(turretBlueprint.redredUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                            turret = redredTurret;
                            redUpgradeCount++;
                            totalUpgradeCount++;
                            totalTurretCost += 150;
                            turretNumber = 19;
                            return;
                        case 1:// redblue
                            Destroy(turret);
                            player.blueCount--;
                            player.currentMoney -= 150;
                            GameObject redblueTurret = (GameObject)Instantiate(turretBlueprint.redblueUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                            turret = redblueTurret;
                            blueUpgradeCount++;
                            totalUpgradeCount++;
                            totalTurretCost += 150;
                            turretNumber = 17;
                            return;
                        case 2://redyellow
                            Destroy(turret);
                            player.yellowCount--;
                            player.currentMoney -= 150;
                            GameObject redyellowTurret = (GameObject)Instantiate(turretBlueprint.redyellowUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                            turret = redyellowTurret;
                            yellowUpgradeCount++;
                            totalUpgradeCount++;
                            totalTurretCost += 150;
                            turretNumber = 17;
                            return;

                    }
                }
                else if (redUpgradeCount == 0 && blueUpgradeCount == 1 && yellowUpgradeCount == 0)
                {

                    switch (GemNumer)
                    {
                        case 0://blue red
                            Destroy(turret);
                            player.redCount--;
                            player.currentMoney -= 150;
                            GameObject redblueTurret = (GameObject)Instantiate(turretBlueprint.redblueUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                            turret = redblueTurret;
                            redUpgradeCount++;
                            totalUpgradeCount++;
                            totalTurretCost += 150;
                            turretNumber = 17;
                            return;
                        case 1:// blueblue
                            Destroy(turret);
                            player.blueCount--;
                            player.currentMoney -= 150;
                            GameObject blueblueTurret = (GameObject)Instantiate(turretBlueprint.blueblueUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                            turret = blueblueTurret;
                            blueUpgradeCount++;
                            totalUpgradeCount++;
                            totalTurretCost += 150;
                            turretNumber = 15;
                            return;
                        case 2://blueyellow
                            Destroy(turret);
                            player.yellowCount--;
                            player.currentMoney -= 150;
                            GameObject blueyellowTurret = (GameObject)Instantiate(turretBlueprint.blueyellowUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                            turret = blueyellowTurret;
                            yellowUpgradeCount++;
                            totalUpgradeCount++;
                            totalTurretCost += 150;
                            turretNumber = 15;
                            return;

                    }
                }
                else if (redUpgradeCount == 0 && blueUpgradeCount == 0 && yellowUpgradeCount == 1)
                {
                    switch (GemNumer)
                    {
                        case 0://yellow red
                            Destroy(turret);
                            player.redCount--;
                            player.currentMoney -= 150;
                            GameObject yellowredTurret = (GameObject)Instantiate(turretBlueprint.redyellowUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                            turret = yellowredTurret;
                            redUpgradeCount++;
                            totalUpgradeCount++;
                            totalTurretCost += 150;
                            turretNumber = 17;
                            return;
                        case 1:// yeloowblue
                            Destroy(turret);
                            player.blueCount--;
                            player.currentMoney -= 150;
                            GameObject yellowblueTurret = (GameObject)Instantiate(turretBlueprint.blueyellowUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                            turret = yellowblueTurret;
                            blueUpgradeCount++;
                            totalUpgradeCount++;
                            totalTurretCost += 150;
                            turretNumber = 15;
                            return;
                        case 2://yellowyellow
                            Destroy(turret);
                            player.yellowCount--;
                            player.currentMoney -= 150;
                            GameObject yellowyellowTurret = (GameObject)Instantiate(turretBlueprint.yellowyellowUpgradePrefab, transform.position + positionOffet, Quaternion.identity);
                            turret = yellowyellowTurret;
                            yellowUpgradeCount++;
                            totalUpgradeCount++;
                            totalTurretCost += 150;
                            turretNumber = 15;
                            return;

                    }
                }
            }
        }
        else if(totalUpgradeCount == 2)//���׷��̵带 �̹� 2�� �� ���
        {

            if (player.currentMoney >= 200)
            {
                sound.SendMessage("UpgradeSound");
                switch (redUpgradeCount)
                {
                    case 0: // ���� ���� ���
                        switch (blueUpgradeCount)
                        {
                            case 0: //��� 2��
                                switch (GemNumer)
                                {
                                    case 0://���2�� ����1��
                                        Destroy(turret);
                                        player.redCount--;
                                        player.currentMoney -= 200;
                                        GameObject yyrturret = (GameObject)Instantiate(turretBlueprint.yellowUpgradePrefab[1], transform.position + positionOffet, Quaternion.identity);
                                        turret = yyrturret;
                                        redUpgradeCount++;
                                        totalUpgradeCount++;
                                        totalTurretCost += 200;
                                        turretNumber = 17;
                                        return;
                                    case 1: //���2�� �Ķ�1��
                                        Destroy(turret);
                                        player.blueCount--;
                                        player.currentMoney -= 200;
                                        GameObject yybturret = (GameObject)Instantiate(turretBlueprint.yellowUpgradePrefab[2], transform.position + positionOffet, Quaternion.identity);
                                        turret = yybturret;
                                        blueUpgradeCount++;
                                        totalUpgradeCount++;
                                        totalTurretCost += 200;
                                        turretNumber = 15;
                                        return;
                                    case 2: // ���3��
                                        Destroy(turret);
                                        player.yellowCount--;
                                        player.currentMoney -= 200;
                                        GameObject yyyturret = (GameObject)Instantiate(turretBlueprint.yellowUpgradePrefab[0], transform.position + positionOffet, Quaternion.identity);
                                        turret = yyyturret;
                                        yellowUpgradeCount++;
                                        totalUpgradeCount++;
                                        totalTurretCost += 200;
                                        turretNumber = 15;
                                        return;
                                }
                                return;
                            case 1: //�Ķ� 1�� ��� 1��
                                switch (GemNumer)
                                {
                                    case 0: //�Ķ� 1 ���1 ����1
                                        Destroy(turret);
                                        player.redCount--;
                                        player.currentMoney -= 200;
                                        GameObject rbyturret = (GameObject)Instantiate(turretBlueprint.redUpgradePrefab[3], transform.position + positionOffet, Quaternion.identity);
                                        turret = rbyturret;
                                        redUpgradeCount++;
                                        totalUpgradeCount++;
                                        totalTurretCost += 200;
                                        turretNumber = 15;
                                        return;
                                    case 1: //�Ķ� 2 ���1
                                        Destroy(turret);
                                        player.blueCount--;
                                        player.currentMoney -= 200;
                                        GameObject bbyturret = (GameObject)Instantiate(turretBlueprint.blueUpgradePrefab[2], transform.position + positionOffet, Quaternion.identity);
                                        turret = bbyturret;
                                        yellowUpgradeCount++;
                                        totalUpgradeCount++;
                                        totalTurretCost += 200;
                                        turretNumber = 15;
                                        return;
                                    case 2: //�Ķ�1 ��� 2
                                        Destroy(turret);
                                        player.yellowCount--;
                                        player.currentMoney -= 200;
                                        GameObject byyturret = (GameObject)Instantiate(turretBlueprint.yellowUpgradePrefab[2], transform.position + positionOffet, Quaternion.identity);
                                        turret = byyturret;
                                        yellowUpgradeCount++;
                                        totalUpgradeCount++;
                                        totalTurretCost += 200;
                                        turretNumber = 15;
                                        return;
                                }
                                return;
                            case 2://�Ķ� 2��
                                switch (GemNumer)
                                {
                                    case 0: // �Ķ� 2 ��1
                                        Destroy(turret);
                                        player.redCount--;
                                        player.currentMoney -= 200;
                                        GameObject bbrturret = (GameObject)Instantiate(turretBlueprint.blueUpgradePrefab[1], transform.position + positionOffet, Quaternion.identity);
                                        turret = bbrturret;
                                        redUpgradeCount++;
                                        totalUpgradeCount++;
                                        totalTurretCost += 200;
                                        turretNumber = 17;
                                        return;
                                    case 1: //�Ķ�3
                                        Destroy(turret);
                                        player.blueCount--;
                                        player.currentMoney -= 200;
                                        GameObject bbbturret = (GameObject)Instantiate(turretBlueprint.blueUpgradePrefab[0], transform.position + positionOffet, Quaternion.identity);
                                        turret = bbbturret;
                                        blueUpgradeCount++;
                                        totalUpgradeCount++;
                                        totalTurretCost += 200;
                                        turretNumber = 15;
                                        return;
                                    case 2: //�Ķ�2 ��� 1
                                        Destroy(turret);
                                        player.yellowCount--;
                                        player.currentMoney -= 200;
                                        GameObject ___turret = (GameObject)Instantiate(turretBlueprint.blueUpgradePrefab[2], transform.position + positionOffet, Quaternion.identity);
                                        turret = ___turret;
                                        yellowUpgradeCount++;
                                        totalUpgradeCount++;
                                        totalTurretCost += 200;
                                        turretNumber = 15;
                                        return;

                                }
                                return;

                        }
                        return;
                    case 1: //���� �ѹ�
                        switch (blueUpgradeCount)
                        {
                            case 0: //���� 1�� ��� 1��
                                switch (GemNumer)
                                {
                                    case 0: //���� 2 ��� 1
                                        Destroy(turret);
                                        player.redCount--;
                                        player.currentMoney -= 200;
                                        GameObject rryturret = (GameObject)Instantiate(turretBlueprint.redUpgradePrefab[2], transform.position + positionOffet, Quaternion.identity);
                                        turret = rryturret;
                                        redUpgradeCount++;
                                        totalUpgradeCount++;
                                        totalTurretCost += 200;
                                        turretNumber = 15;
                                        return;
                                    case 1: //����1 ���1 �Ķ� 1
                                        Destroy(turret);
                                        player.blueCount--;
                                        player.currentMoney -= 200;
                                        GameObject rbyturret = (GameObject)Instantiate(turretBlueprint.redUpgradePrefab[3], transform.position + positionOffet, Quaternion.identity);
                                        turret = rbyturret;
                                        blueUpgradeCount++;
                                        totalUpgradeCount++;
                                        totalTurretCost += 200;
                                        turretNumber = 15;
                                        return;
                                    case 2: //���� 1 ���2
                                        Destroy(turret);
                                        player.yellowCount--;
                                        player.currentMoney -= 200;
                                        GameObject yyrturret = (GameObject)Instantiate(turretBlueprint.yellowUpgradePrefab[1], transform.position + positionOffet, Quaternion.identity);
                                        turret = yyrturret;
                                        yellowUpgradeCount++;
                                        totalUpgradeCount++;
                                        totalTurretCost += 200;
                                        turretNumber = 17;
                                        return;

                                }
                                return;
                            case 1: //���� 1�� �Ķ� 1��
                                switch (GemNumer)
                                {
                                    case 0: //��2 ��1
                                        Destroy(turret);
                                        player.redCount--;
                                        player.currentMoney -= 200;
                                        GameObject rrbturret = (GameObject)Instantiate(turretBlueprint.redUpgradePrefab[1], transform.position + positionOffet, Quaternion.identity);
                                        turret = rrbturret;
                                        redUpgradeCount++;
                                        totalUpgradeCount++;
                                        totalTurretCost += 200;
                                        turretNumber = 15;
                                        return;
                                    case 1://��1 ��2
                                        Destroy(turret);
                                        player.blueCount--;
                                        player.currentMoney -= 200;
                                        GameObject rbbturret = (GameObject)Instantiate(turretBlueprint.blueUpgradePrefab[1], transform.position + positionOffet, Quaternion.identity);
                                        turret = rbbturret;
                                        blueUpgradeCount++;
                                        totalUpgradeCount++;
                                        totalTurretCost += 200;
                                        turretNumber = 17;
                                        return;
                                    case 2://��1 ��1 ��1
                                        Destroy(turret);
                                        player.yellowCount--;
                                        player.currentMoney -= 200;
                                        GameObject rbyturret = (GameObject)Instantiate(turretBlueprint.redUpgradePrefab[3], transform.position + positionOffet, Quaternion.identity);
                                        turret = rbyturret;
                                        yellowUpgradeCount++;
                                        totalUpgradeCount++;
                                        totalTurretCost += 200;
                                        turretNumber = 15;
                                        return;

                                }
                                return;

                        }
                        return;
                    case 2: //���� �ι�
                        switch (GemNumer)
                        {
                            case 0://���� 3��
                                Destroy(turret);
                                player.redCount--;
                                player.currentMoney -= 200;
                                GameObject rrrturret = (GameObject)Instantiate(turretBlueprint.redUpgradePrefab[0], transform.position + positionOffet, Quaternion.identity);
                                turret = rrrturret;
                                redUpgradeCount++;
                                totalUpgradeCount++;
                                totalTurretCost += 200;
                                turretNumber = 15;
                                return;
                            case 1://����2 �Ķ� 1
                                Destroy(turret);
                                player.blueCount--;
                                player.currentMoney -= 200;
                                GameObject rrbturret = (GameObject)Instantiate(turretBlueprint.redUpgradePrefab[1], transform.position + positionOffet, Quaternion.identity);
                                turret = rrbturret;
                                blueUpgradeCount++;
                                totalUpgradeCount++;
                                totalTurretCost += 200;
                                turretNumber = 15;
                                return;
                            case 2://����2 ��� 1
                                Destroy(turret);
                                player.yellowCount--;
                                player.currentMoney -= 200;
                                GameObject rryturret = (GameObject)Instantiate(turretBlueprint.redUpgradePrefab[2], transform.position + positionOffet, Quaternion.identity);
                                turret = rryturret;
                                yellowUpgradeCount++;
                                totalUpgradeCount++;
                                totalTurretCost += 200;
                                turretNumber = 15;
                                return;

                        }
                        return;
                }
            }
        }
        else if(totalUpgradeCount >= 3)//���׷��̵带 3���ߴµ� �� �ϰ� �ʹٰ� ���� ���
        {
            return;

        }
        else // ���׷��̵尡 ó���ΰ��
        {
            if (player.currentMoney >= 100)
            {
                sound.SendMessage("UpgradeSound");
                switch (GemNumer)
                {
                    case 0:
                        Destroy(turret);
                        player.redCount--;
                        player.currentMoney -= 100;
                        GameObject redTurret = (GameObject)Instantiate(turretBlueprint.upgradePrefab[0], transform.position + positionOffet, Quaternion.identity);
                        turret = redTurret;
                        redUpgradeCount++;
                        totalUpgradeCount++;
                        totalTurretCost += 100;
                        turretNumber = 17;
                        return;
                    case 1:
                        Destroy(turret);
                        player.blueCount--;
                        player.currentMoney -= 100;
                        GameObject blueTurret = (GameObject)Instantiate(turretBlueprint.upgradePrefab[1], transform.position + positionOffet, Quaternion.identity);
                        turret = blueTurret;
                        blueUpgradeCount++;
                        totalUpgradeCount++;
                        totalTurretCost += 100;
                        turretNumber = 15;
                        return;
                    case 2:
                        Destroy(turret);
                        player.yellowCount--;
                        player.currentMoney -= 100;
                        GameObject yellowTurret = (GameObject)Instantiate(turretBlueprint.upgradePrefab[2], transform.position + positionOffet, Quaternion.identity);
                        turret = yellowTurret;
                        yellowUpgradeCount++;
                        totalUpgradeCount++;
                        totalTurretCost += 100;
                        turretNumber = 15;
                        return;
                }
            }
        }
    }

  
    public void SellTurret()
    {
        player.currentMoney += totalTurretCost / 2;
        redUpgradeCount = 0;
        blueUpgradeCount = 0;
        yellowUpgradeCount = 0;
        totalUpgradeCount = 0;
        totalTurretCost = 100;

        Destroy(turret);

    }

}
