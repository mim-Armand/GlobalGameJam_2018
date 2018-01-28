using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Splash : MonoBehaviour
{
	public Image splashImage;
    public string loadLevel;
	// Use this for initialization

	void Start() {
		StartCoroutine (begin());
	}
	private IEnumerator begin () {
        yield return new WaitForSeconds(20.0f);
        SceneManager.LoadScene(loadLevel);
	}
	

    void FadeIn()
    {
        splashImage.CrossFadeAlpha(1.0f, 1.5f, false);

    }

    void FadeOut()
    {
        splashImage.CrossFadeAlpha(0.0f, 2.5f, false);
    }
}
