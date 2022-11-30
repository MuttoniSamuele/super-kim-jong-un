using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KimController : MonoBehaviour {
	[SerializeField] private float moveSpeed;
	[SerializeField] private float jumpSpeed;
	[SerializeField] private float defaultFriction = 0.4f;

	private Rigidbody2D rbody;
	private Collider2D coll;
	private float matFriction;

    void Start() {
		rbody = gameObject.GetComponent<Rigidbody2D>();
		coll = gameObject.GetComponent<Collider2D>();
		matFriction = 0;//coll.sharedMaterial.friction;
	}

    void FixedUpdate() {
		Vector2 newVel = rbody.velocity;
		bool moveLeft = Input.GetKey(KeyCode.LeftArrow);
		bool moveRight = Input.GetKey(KeyCode.RightArrow);

		if (moveLeft == moveRight) {
			newVel.x = 0;
			rbody.sharedMaterial.friction = defaultFriction;
		} else {
			newVel.x = moveRight ? moveSpeed : -moveSpeed;
			rbody.sharedMaterial.friction = matFriction;
		}

		if (Input.GetKey(KeyCode.UpArrow) && rbody.velocity.y == 0) {
			newVel.y = jumpSpeed;
		}

		rbody.velocity = newVel;
    }
}
