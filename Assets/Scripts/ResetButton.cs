using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResetButton : MonoBehaviour {
	private RectTransform rectTrans;
	private TMP_Text  textComp;

	void Start() {
		rectTrans = GetComponent<RectTransform>();
		textComp = GetComponentInChildren<TMP_Text>();
	}

	void Update() {
		textComp.fontStyle = isPointWithinBtn(Input.mousePosition) ? FontStyles.Underline : FontStyles.Normal;
	}

	private bool isPointWithinBtn(Vector2 point) {
		return RectTransformUtility.RectangleContainsScreenPoint(rectTrans, point);
	}

	public void HandleClick() {
		PlayerPrefs.DeleteAll();
	}
}
