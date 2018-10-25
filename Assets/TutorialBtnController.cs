using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TutorialBtnController : MonoBehaviour {

	public Sprite []btnSprite;
	public Sprite[] TutorialImg;
	private Image TutorialRender;
	public GameObject TutorialPanel;
	private bool curTutorialBtnStatus;
	private int curTutorialIdx;

	// Use this for initialization
	void Start () {
		curTutorialIdx = 0;
		curTutorialBtnStatus = false;
		hideTutorial ();
		TutorialRender = TutorialPanel.GetComponent<Image> ();
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
		} else if (Input.GetKeyUp (KeyCode.A)) {
			if (curTutorialBtnStatus) {
				if (curTutorialIdx == 0) {
					ShowTutorial ();
				}
				if (curTutorialIdx != 3) {
					TutorialRender.sprite = TutorialImg [curTutorialIdx];
				}
				else if (curTutorialIdx == 3) {
					curTutorialIdx = -1;
					hideTutorial ();
				}
					
				curTutorialIdx++;
			}
		}
	}
}
