using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapZone : MonoBehaviour {
	[SerializeField] private Color unlockedColor;
	[SerializeField] private Color lockedColor;
	[SerializeField] private Color hoverColor;
	[SerializeField] private Color selectColor;
	[SerializeField] public bool isLocked;
	[SerializeField] public bool isCompleted = false;
	[SerializeField] private MapZone[] neighbourZones;

	private SpriteRenderer spriteRenderer;
	private bool isHovered = false;
	private bool isClicked = false;

	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = unlockedColor;
	}

    void Update() {
		if (isCompleted) {
			foreach (MapZone zone in neighbourZones) {
				if (zone) {
					zone.isLocked = false;
				}
			}
		}

		if (isHovered) {
			spriteRenderer.color = isClicked ? selectColor : hoverColor;
		} else {
			spriteRenderer.color = isLocked ? lockedColor : unlockedColor;
		}
	}

	private void OnMouseEnter() {
		isHovered = true;
	}

	private void OnMouseExit() {
		isHovered = false;
	}

	private void OnMouseDown() {
		isClicked = true;
	}

	private void OnMouseUp() {
		isClicked = false;
	}
}
