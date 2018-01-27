using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceTower : MonoBehaviour
{
    //instantiate a copy of the object stored in towerPrefab to create a tower, and store it in tower to manipulate it during the game.
    public GameObject towerPrefab;
    private GameObject tower;

    private bool CanPlaceTower()
    {
        return tower == null;
    }

    //Method to check on what to do with the tower placing 
    void OnMouseUp()
    {
        Debug.Log(" Error");
        if (CanPlaceTower()) //if tower can be placed 
        {
            tower = GameObject.Instantiate(towerPrefab, transform.position, Quaternion.identity);
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.PlayOneShot(audioSource.clip);

            //extra stuff like gold deduction can be added here
        }
    }
}

