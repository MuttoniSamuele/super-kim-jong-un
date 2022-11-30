using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreserveGameObject : MonoBehaviour {
	private static GameObject instance = null;

	void Awake() {
		if (instance) {
			Destroy(instance);
		}
		instance = gameObject;
		DontDestroyOnLoad(gameObject);
	}
}
