using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KimController : MonoBehaviour {
	[SerializeField] private float moveSpeed;
	[SerializeField] private float jumpSpeed;

	private Rigidbody2D rbody;

    void Start() {
		rbody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {
		Vector2 newVel = rbody.velocity;
		bool moveLeft = Input.GetKey(KeyCode.LeftArrow);
		bool moveRight = Input.GetKey(KeyCode.RightArrow);

		if (moveLeft == moveRight) {
			newVel.x = 0;
		} else {
			newVel.x = moveRight ? moveSpeed : -moveSpeed;
		}

		if (Input.GetKey(KeyCode.UpArrow) && rbody.velocity.y == 0) {
			newVel.y = jumpSpeed;
		}

		rbody.velocity = newVel;
    }
}
