using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapZone : MonoBehaviour {
	public enum State { Locked, Unlocked, Completed };

	public string zoneName;
	[Range(1, 5)] public int threatLevel;
	[SerializeField] private Color completedColor;
	[SerializeField] private Color unlockedColor;
	[SerializeField] private Color lockedColor;
	[SerializeField] private Color hoverColor;
	[SerializeField] private Color selectColor;
	[SerializeField] private bool isLocked;
	[SerializeField] private MapZone[] neighbourZones;
	[SerializeField] private ZoneModal zoneModal;

	public State state { get; private set; }
	private SpriteRenderer spriteRenderer;
	private bool isHovered = false;
	private bool isClicked = false;

	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.color = unlockedColor;
		loadState();
	}

    void Update() {
		if (zoneModal.isOpen) {
			return;
		}
		if (isHovered) {
			if (isClicked) {
				spriteRenderer.color = selectColor;
				zoneModal.OpenModal(this, neighbourZones);
			} else {
				spriteRenderer.color = hoverColor;
			}
		} else {
			switch (state) {
				case State.Locked: {
					spriteRenderer.color = lockedColor;
					break;
				}
				case State.Unlocked: {
					spriteRenderer.color = unlockedColor;
					break;
				}
				case State.Completed: {
					spriteRenderer.color = completedColor;
					break;
				}
			}
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

	private void loadState() {
		state = (State) PlayerPrefs.GetInt(zoneName, (int) (isLocked ? State.Locked : State.Unlocked));
	}

	public void ChangeState(State newState) {
		state = newState;
		PlayerPrefs.SetInt(zoneName, (int) state);
		if (state == State.Completed) {
			foreach (MapZone zone in neighbourZones) {
				if (zone && zone.state != State.Completed) {
					zone.ChangeState(State.Unlocked);
				}
			}
		}
	}
}
