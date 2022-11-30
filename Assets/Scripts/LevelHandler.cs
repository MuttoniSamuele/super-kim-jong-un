using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour {
	public static MapZone currentZone;

	[SerializeField] private Collider2D levelEndCollider;
	[SerializeField] private float deathY;

	void Start() {
		
	}

	void Update() {
		if (transform.position.y < deathY) {
			exitLevel(false);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll == levelEndCollider) {
			exitLevel(true);
		}
	}

	void exitLevel(bool hasWon) {
		if (hasWon) {
			currentZone.ChangeState(MapZone.State.Completed);
		}
		SceneManager.LoadScene("Map");
	}
}
