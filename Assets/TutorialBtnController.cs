using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TutorialBtnController : MonoBehaviour {

	public Sprite []btnSprite;
	public GameObject TutorialPanel;
	private bool curTutorialBtnStatus;
	// Use this for initialization
	void Start () {
		curTutorialBtnStatus = true;
		hideTutorial ();
	}

	// Update is called once per frame
	void Update () {

	}

	void hideTutorial(){
		TutorialPanel.gameObject.SetActive (false);
	}

	void ShowTutorial(){
		TutorialPanel.gameObject.SetActive (true);
	}

	void LateUpdate(){
		if (Input.GetKey (KeyCode.UpArrow)) {
			gameObject.GetComponent<Image> ().sprite = btnSprite [0];
			curTutorialBtnStatus = false;
			hideTutorial ();
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			gameObject.GetComponent<Image> ().sprite = btnSprite [1];
			curTutorialBtnStatus = true;
		} else if (Input.GetKey (KeyCode.A)) {
			if (curTutorialBtnStatus) {
				ShowTutorial ();
			}
		}
	}
}
