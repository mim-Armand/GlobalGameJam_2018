using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Spawner : MonoBehaviour {
		public GameObject piratePrefab;
		public GameObject shipPrefab;
		public float timeBetweenWaves = 10f;
		private float countdown = 2f;
		public Text waveCountdownText;
		private int waveNumber = 0;
		[SerializeField]
		private GameObject[] navPoints;
		// Update is called once per frame
		void FixedUpdate ()
		{
			if(countdown <= 0f)
			{
				//spawn pirate ship every 10th wave
				if ((waveNumber + 1) % 10 == 0) {
					SpawnPirateShip ();
				} else {
					StartCoroutine (SpawnWave ()); //called here
				}
				countdown = timeBetweenWaves;
			}
			countdown -= Time.deltaTime;
			waveCountdownText.text = Mathf.Floor(countdown).ToString();
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
			GameObject spawnedObject = GameObject.Instantiate (piratePrefab);
			// we only need to set the position since the thing spawned will take care of that
			spawnedObject.transform.position = this.transform.position;
			spawnedObject.GetComponent<Entity> ().SetNavigator (new Navigator (navPoints));
		}

		void SpawnPirateShip() {
			waveNumber++;
			GameObject spawnedObject = GameObject.Instantiate (shipPrefab);
			// we only need to set the position since the thing spawned will take care of that
			spawnedObject.transform.position = this.transform.position;
			spawnedObject.GetComponent<Entity> ().SetNavigator (new Navigator (navPoints));
		}
	}

