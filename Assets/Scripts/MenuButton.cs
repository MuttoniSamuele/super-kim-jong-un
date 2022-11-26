using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {
	[SerializeField] private float scaleMultiplier;
	[SerializeField] private float duration;

	private RectTransform rectTrans;
	private Vector3 start;
	private Vector3 end;
	private bool doAnimation = false;
	private bool isMouseHover = false;
	private bool lastIsMouseHover = false;
	private float elapsedTime = 0f;

	void Start() {
		rectTrans = GetComponent<RectTransform>();
		start = rectTrans.localScale;
		end = rectTrans.localScale * scaleMultiplier;
	}

	void Update() {
		lastIsMouseHover = isMouseHover;
		isMouseHover = isPointWithinBtn(Input.mousePosition);
		if (isMouseHover != lastIsMouseHover) {
			doAnimation = true;
		}
		if (!doAnimation) {
			return;
		}
		rectTrans.localScale = Vector3.Lerp(start, end, elapsedTime / duration);
		elapsedTime += Time.deltaTime * (isMouseHover ? 1 : -1);
		if (elapsedTime < 0) {
			elapsedTime = 0;
			doAnimation = false;
		}
		if (elapsedTime > duration) {
			elapsedTime = duration;
			doAnimation = false;
		}
	}

	private bool isPointWithinBtn(Vector2 point) {
		return RectTransformUtility.RectangleContainsScreenPoint(rectTrans, point);
	}

	public void HandlePlay() {
		SceneManager.LoadScene("Map");
	}

	public void HandleQuit() {
		Application.Quit();
	}
}
