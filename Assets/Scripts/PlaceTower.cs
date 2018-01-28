using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//go with BuildManager script
public class PlaceTower : MonoBehaviour {

    public Color hoverColor;
    private GameObject tower;
    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (tower != null)
        {
            Debug.Log("Can't build there");
            return;
        }

        GameObject towerToBuild = BuildManager.instance.GetTowerToBuild();
        tower = (GameObject)Instantiate(towerToBuild, transform.position, transform.rotation);
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;

    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

