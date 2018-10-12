using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;

public class StartBtnController : MonoBehaviour {

	public Sprite []btnSprite;
	private bool curStartBtnStatus;

	// Use this for initialization
	void Start () {
		curStartBtnStatus = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void startScene(){
		SceneManager.LoadScene("firstsene");
	}

	void LateUpdate(){
		if (Input.GetKey (KeyCode.UpArrow)) {
			gameObject.GetComponent<Image> ().sprite = btnSprite [1];
			curStartBtnStatus = true;
		} else if (Input.GetKey (KeyCode.DownArrow)) {
			gameObject.GetComponent<Image> ().sprite = btnSprite [0];
			curStartBtnStatus = false;
		} else if (Input.GetKey (KeyCode.A)) {
			if (curStartBtnStatus) {
				startScene ();
			}
		}
	}
}
