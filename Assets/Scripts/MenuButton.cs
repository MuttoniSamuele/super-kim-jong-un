using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {
	void Start() {

	}

	void Update() {

	}

	public void HandlePlay() {
		SceneManager.LoadScene("Map");
	}

	public void HandleQuit() {
		Application.Quit();
	}
}
