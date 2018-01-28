
using UnityEngine;

//script to select the kind of tower to build
public class Shop : MonoBehaviour {

    public TowerBlueprint standardTower;
    public TowerBlueprint anotherTower;
    public TowerBlueprint yetanotherTower;
    BuildManager buildManager;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTower()
    {
        Debug.Log("TV Tower Purchased");
        buildManager.SelectTowerToBuild(standardTower);
    }
    public void SelectAnotherTower()
    {
        Debug.Log("Radio Tower Purchased");
        buildManager.SelectTowerToBuild(anotherTower);
    }
    public void PurchaseYetAnotherTower()
    {
        Debug.Log("WifiTower Purchased");
        buildManager.SelectTowerToBuild(yetanotherTower);
    }
}
