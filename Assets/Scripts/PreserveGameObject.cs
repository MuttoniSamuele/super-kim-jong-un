using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreserveGameObject : MonoBehaviour {
	private static GameObject instance = null;

	void Awake() {
		if (instance) {
			Destroy(instance);
		}
		instance = gameObject;
		DontDestroyOnLoad(instance);
	}

	void Update() {
		gameObject.SetActive(SceneManager.GetActiveScene().name == "Map");
	}
}
