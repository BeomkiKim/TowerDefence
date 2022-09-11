using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    Node target;
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
        target.RedUpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    public void BlueUpgrade()
    {
        target.BlueUpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    public void YellowUpgrade()
    {
        target.YellowUpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
