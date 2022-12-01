using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelHandler : MonoBehaviour {
	public static MapZone currentZone;

	[SerializeField] private Collider2D levelEndCollider;
	[SerializeField] private float deathY;

	void Update() {
		if (transform.position.y < deathY) {
			exitLevel(false);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll == levelEndCollider) {
			exitLevel(true);
		}
		if (coll.gameObject.tag == "Bullet") {
			exitLevel(false);
		}
	}

	void OnCollisionEnter2D(Collision2D collision) {
		if (collision.gameObject.tag == "Bot") {
			exitLevel(false);
		}
	}

	void exitLevel(bool hasWon) {
		if (hasWon) {
			currentZone.ChangeState(MapZone.State.Completed);
		}
		SceneManager.LoadScene("Map");
	}
}
