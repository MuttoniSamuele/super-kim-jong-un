using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour {
	[SerializeField] private ZoneModal zoneModal;

	private Button btn;

	void Start() {
		btn = GetComponent<Button>();
	}

	void Update() {
		btn.interactable = !zoneModal.isOpen;
	}

	public void HandleBack() {
		SceneManager.LoadScene("Menu");
	}
}
