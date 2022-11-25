using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroll : MonoBehaviour {
	[SerializeField] private Vector3 start;
	[SerializeField] private Vector3 end;
	[SerializeField] private float duration;

	private RectTransform rectTrans;
	private float startTime;
	private Vector3 curStart;
	private Vector3 curEnd;

	void Start() {
		rectTrans = GetComponent<RectTransform>();
		startTime = Time.time;
		curStart = start;
		curEnd = end;
	}

	void Update() {
		float t = (Time.time - startTime) / duration;
		if (t >= 1) {
			startTime = Time.time;
			Vector3 temp = curStart;
			curStart = curEnd;
			curEnd = temp;
		}
		rectTrans.anchoredPosition = Vector3.Lerp(curStart, curEnd, t);
	}
}
