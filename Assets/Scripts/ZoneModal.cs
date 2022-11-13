using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ZoneModal : MonoBehaviour {
	[SerializeField] private Text zoneName;
	[SerializeField] private Text threatLevel;
	[SerializeField] private Text unlockedZones;
	[SerializeField] private Button playButton;
	[SerializeField] private Text playButtonText;
	[SerializeField] private float openSpeed;

	public bool isOpen { get; private set; } = false;
	private float t = 1f;
	private bool lastMouseState = false;
	private RectTransform rectTrans;

	void Start() {
		rectTrans = GetComponent<RectTransform>();
	}

	void Update() {
		if (t >= 1f) {
			bool mouseState = Input.GetMouseButton(0);
			if (isOpen && (Input.GetKey(KeyCode.Escape) || (mouseState && lastMouseState == false && !isPointWithinModal(Input.mousePosition)))) {
				resetAnimation(false);
				return;
			}
			lastMouseState = mouseState;
			transform.localScale = isOpen ? new Vector2(1, 1) : new Vector2(0, 0);
			return;
		}
		if (isOpen) {
			transform.localScale = Vector2.Lerp(new Vector2(0, 0), new Vector2(1, 1), t);
		} else {
			transform.localScale = Vector2.Lerp(new Vector2(1, 1), new Vector2(0, 0), t);
		}
		t += openSpeed * Time.deltaTime;
	}

	private bool isPointWithinModal(Vector2 point) {
		return RectTransformUtility.RectangleContainsScreenPoint(rectTrans, point);
	}

	private void resetAnimation(bool isOpening) {
		if (!isOpening) {
			playButton.onClick.RemoveAllListeners();
		}
		isOpen = isOpening;
		t = 0f;
	}

	public void OpenModal(MapZone zone, MapZone[] neighbourZones) {
		zoneName.text = zone.zoneName;
		threatLevel.text = zone.threatLevel.ToString();
		MapZone[] unlockableZones = neighbourZones.Where(z => z != null && z.isLocked).ToArray();
		if (unlockableZones.Length > 0) {
			unlockedZones.text = string.Join(", ", unlockableZones.Select(z => z ? z.zoneName : "").ToArray());
		} else {
			unlockedZones.text = "None";
		}
		if (zone.isLocked) {
			playButton.interactable = false;
			playButtonText.text = "Locked";
		} else {
			playButton.interactable = true;
			playButtonText.text = "Play";
		}

		playButton.onClick.AddListener(() => {
			zone.isCompleted = true;
			resetAnimation(false);
		});
		
		resetAnimation(true);
	}

	public void CloseModal() {
		resetAnimation(false);
	}
}
