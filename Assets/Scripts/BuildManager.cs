using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// go with PlaceTower script
public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }
    public GameObject standardTowerPrefab;
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
