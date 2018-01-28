using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// go with PlaceTower script
public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }
    public GameObject standardTowerPrefab;

    

    public bool CanBuild { get { return towerToBuild != null; } }
    public bool HasMoney { get {return PlayerStats.Money >= towerToBuild.cost; } }

    public void BuildTowerOn (PlaceTower node)
    {
        if (PlayerStats.Money < towerToBuild.cost)
        {
            Debug.Log("Insufficient Fund");
            return;
        }

        PlayerStats.Money -= towerToBuild.cost;

        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, node.GetBuildPosition);
        node.tower = tower;
    }

    private void Start()
    {
        towerToBuild = standardTowerPrefab;
    }
    private GameObject towerToBuild;

    //called in PlaceTower script
    public GameObject GetTowerToBuild()
    {
        return towerToBuild;
    }
}
