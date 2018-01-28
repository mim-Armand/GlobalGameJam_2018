using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//go with BuildManager script
public class PlaceTower : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public GameObject tower;
    private Renderer rend;
    private Color startColor;
    public Vector3 positionOffSet;
    BuildManager buildManager;

    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
		Debug.Log (buildManager.gameObject.name);
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffSet;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        if (tower != null)
        {
            Debug.Log("Can't build there");
            return;
        }

        buildManager.BuildTowerOn(this);
    }

    private void OnMouseEnter()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if(!buildManager.CanBuild)
        {
            return;
        }
        if(buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}

