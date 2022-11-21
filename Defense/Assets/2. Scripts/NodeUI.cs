using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public GameObject[] rangeUI;
    int uiNum;
    Node target;
    PlayerState player;

    private void Start()
    {
        player = GameObject.Find("GameManager").GetComponent<PlayerState>();
    }
    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();
        Hide();
        ui.SetActive(true);

        switch(target.turretNumber)
        {
            case 15:
                rangeUI[0].SetActive(true);
                uiNum = 0;
                break;
            case 17:
                rangeUI[1].SetActive(true);
                uiNum = 1;
                break;
            case 19:
                rangeUI[2].SetActive(true);
                uiNum = 2;
                break;
        }
    }

    public void Hide()
    {
        switch (uiNum)
        {
            case 0:
                rangeUI[0].SetActive(false);
                break;
            case 1:
                rangeUI[1].SetActive(false);
                break;
            case 2:
                rangeUI[2].SetActive(false);
                break;
        }
        ui.SetActive(false);
    }

    public void RedUpgrade()
    {
        if (player.redCount == 0)
            return;
         
        if (target.totalUpgradeCount == 0 && player.currentMoney < 50)
            return;
        if (target.totalUpgradeCount == 1 && player.currentMoney < 100)
            return;
        if (target.totalUpgradeCount == 2 && player.currentMoney < 150)
            return;

        //if (target.totalUpgradeCount == 0 && player.redCount>1)
        //    player.currentMoney -= 50f;
        //else if (target.totalUpgradeCount == 1 && player.redCount > 1)
        //    player.currentMoney -= 100f;
        //else if (target.totalUpgradeCount == 2 && player.redCount > 1)
        //    player.currentMoney -= 150f;

        target.UpgradeTurret(0);
        BuildManager.instance.DeselectNode();
    }
    public void BlueUpgrade()
    {
        if (player.blueCount == 0)
            return;

        if (target.totalUpgradeCount == 0 && player.currentMoney < 50)
            return;
        if (target.totalUpgradeCount == 1 && player.currentMoney < 100)
            return;
        if (target.totalUpgradeCount == 2 && player.currentMoney < 150)
            return;

        //if (target.totalUpgradeCount == 0 && player.blueCount > 1) 
        //    player.currentMoney -= 50f;
        //else if (target.totalUpgradeCount == 1 && player.blueCount > 1)
        //    player.currentMoney -= 100f;
        //else if (target.totalUpgradeCount == 2 && player.blueCount > 1)
        //    player.currentMoney -= 150f;

        target.UpgradeTurret(1);
        BuildManager.instance.DeselectNode();
    }
    public void YellowUpgrade()
    {
        if (player.yellowCount == 0)
            return;

        if (target.totalUpgradeCount == 0 && player.currentMoney < 50)
            return;
        if (target.totalUpgradeCount == 1 && player.currentMoney < 100)
            return;
        if (target.totalUpgradeCount == 2 && player.currentMoney < 150)
            return;

        //if (target.totalUpgradeCount == 0 && player.yellowCount > 1)
        //    player.currentMoney -= 50f;
        //else if (target.totalUpgradeCount == 1 && player.yellowCount > 1)
        //    player.currentMoney -= 100f;
        //else if (target.totalUpgradeCount == 2 && player.yellowCount > 1 )
        //    player.currentMoney -= 150f;

        target.UpgradeTurret(2);
        BuildManager.instance.DeselectNode();
    }

    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeselectNode();

    }
}
