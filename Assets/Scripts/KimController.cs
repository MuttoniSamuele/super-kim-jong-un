using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KimController : MonoBehaviour {
	[SerializeField] private float moveSpeed;
	[SerializeField] private float jumpSpeed;
	[SerializeField] private Collider2D groundColl;
	[SerializeField] private Transform groundCheckTransform;
	[SerializeField] private Vector2 boxSize;

	private Rigidbody2D rbody;
	private Collider2D coll;
	private float matFriction;

    void Start() {
		rbody = gameObject.GetComponent<Rigidbody2D>();
	}

    void FixedUpdate() {
		Vector2 newVel = rbody.velocity;
		bool moveLeft = Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A);
		bool moveRight = Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D);

		if (moveLeft == moveRight) {
			newVel.x = 0;
		} else {
			newVel.x = moveRight ? moveSpeed : -moveSpeed;
		}

		if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)) && isGrounded()) {
			newVel.y = jumpSpeed;
		}
		
		rbody.velocity = newVel;
    }

	bool isGrounded() {
		Collider2D[] colls = Physics2D.OverlapBoxAll(groundCheckTransform.position, boxSize, 0f);
		foreach (Collider2D coll in colls) {
			if (coll == groundColl) {
				return true;
			}
		}
		return false;
	}
}
