using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    private bool gameEnded = false;
    public GameObject gameOverUI;
	// Update is called once per frame
	void Update ()
    {
		if (gameEnded)
        {
            return;
        }
        if() //enter the losing condition here
        {
            EndGame();
        }
	}

    void EndGame()
    {
        gameEnded = true;
        Debug.Log("Game Over");

        gameOverUI.SetActive(true);
    }
}
