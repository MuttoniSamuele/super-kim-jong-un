using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapZone : MonoBehaviour {
	public string zoneName;
	[Range(1, 5)] public int threatLevel;
	[SerializeField] private Color unlockedColor;
	[SerializeField] private Color lockedColor;
	[SerializeField] private Color hoverColor;
	[SerializeField] private Color selectColor;
	public bool isLocked;
	[SerializeField] private MapZone[] neighbourZones;
	[SerializeField] private ZoneModal zoneModal;

	[HideInInspector] public bool isCompleted = false;
	private SpriteRenderer spriteRenderer;
	private bool isHovered = false;
	private bool isClicked = false;

	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = unlockedColor;
	}

    void Update() {
		if (zoneModal.isOpen) {
			return;
		}
		if (isCompleted) {
			foreach (MapZone zone in neighbourZones) {
				if (zone) {
					zone.isLocked = false;
				}
			}
		}
		if (isHovered) {
			if (isClicked) {
				spriteRenderer.color = selectColor;
				zoneModal.OpenModal(this, neighbourZones);
			} else {
				spriteRenderer.color = hoverColor;
			}
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
		if (zoneModal.isOpen) {
			return;
		}
		isClicked = true;
	}

	private void OnMouseUp() {
		isClicked = false;
	}
}
