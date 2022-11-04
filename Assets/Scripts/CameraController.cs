using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	[SerializeField] private GameObject kim;
	[SerializeField] private float offset;

    void Start() {
		
    }

    void Update(){
		Vector3 newPos = new Vector3(
			kim.transform.position.x + offset,
			transform.position.y,
			transform.position.z
		);
		transform.position = newPos;
    }
}
