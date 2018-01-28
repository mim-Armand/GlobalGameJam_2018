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
    public GameObject anotherTowerPrefab;
    public GameObject yetanotherTowerPrefab;

    private TowerBlueprint towerToBuild;

    public bool CanBuild { get { return towerToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= towerToBuild.cost; } }

    public void BuildTowerOn(PlaceTower node)
    {
        if(PlayerStats.Money < towerToBuild.cost)
        {
            Debug.Log("Insufficient fund");
            return;
        }

        PlayerStats.Money -= towerToBuild.cost;
        
        GameObject tower = (GameObject)Instantiate(towerToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.tower = tower;
        Debug.Log("Tower has been built, the remaining money is :" + PlayerStats.Money);
    }

    //called in PlaceTower script
    public void SelectTowerToBuild(TowerBlueprint tower)
    {
        towerToBuild = tower;
    }
 
}
