using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class WaveSpawner : MonoBehaviour {
    public Transform piratePrefab;
    public Transform spawnPoint;
    public float timeBetweenWaves = 10f;
    private float countdown = 2f;
    public Text waveCountdownText;
    private int waveNumber = 0;

    // Update is called once per frame
    void Update ()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave()) ; //called here
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
	}

    IEnumerator SpawnWave() //will be called when countdown is 0 to indicate another enemy wave is coming
    {
        waveNumber++;
        for (int i = 0; i <waveNumber; i++)
        {
            SpawnPirate(); //keep spawning as long as the number is smaller than predetermined waveNunber which incremented after every way by 1
            yield return new WaitForSeconds(0.5f); //wait 0.5 second before spawning the next wave
        }
        
        Debug.Log("Wave Incoming"); 
        
    }

    void SpawnPirate() //spawn pirates at the spawn point indicated on the map
    {
        Instantiate(piratePrefab, spawnPoint.position, spawnPoint.rotation);
    }


}
