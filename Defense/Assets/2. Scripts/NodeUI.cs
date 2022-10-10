using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
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
        ui.SetActive(true);
    }

    public void Hide()
    {
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
