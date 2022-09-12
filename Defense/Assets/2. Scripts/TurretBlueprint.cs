using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TurretBlueprint : MonoBehaviour
{

    [Header("3�ܰ� Ÿ��")]
    public GameObject[] redUpgradePrefab;
    //0 rrr 1 rrb 2 rry 3 rby
    public GameObject[] blueUpgradePrefab;
    //0 bbb 1 bbr 2 bby
    public GameObject[] yellowUpgradePrefab;
    //0 yyy 1 yyr 2 yyb
    [Header("2�ܰ� Ÿ��")]
    public GameObject redredUpgradePrefab;
    public GameObject blueblueUpgradePrefab;
    public GameObject yellowyellowUpgradePrefab;
    public GameObject redblueUpgradePrefab;
    public GameObject redyellowUpgradePrefab;
    public GameObject blueyellowUpgradePrefab;
    [Header("1�ܰ� Ÿ��")]
    public GameObject[] upgradePrefab;
    //0 r 1 b 2 y


}
