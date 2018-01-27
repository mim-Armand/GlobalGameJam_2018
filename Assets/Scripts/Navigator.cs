using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator {
	private GameObject[] navPoints;
	private int index;

	public Navigator(GameObject[] points) {
		navPoints = points;
		index = 0;
	}

	public Vector2 Navigate(Vector2 currentPosition) {
		// must be length - 2 since the next iteration of this the index will be at the bounds
		if (index <= (navPoints.Length - 2) && Vector2.Distance (currentPosition, navPoints [index].transform.position) == 0)
			index++;
		
		return navPoints [index].transform.position;
	}
}
