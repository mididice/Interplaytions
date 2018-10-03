using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class TutorialBtnController : MonoBehaviour {

	public Sprite []btnSprite;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}

	void LateUpdate(){
		if (Input.GetKey (KeyCode.UpArrow)) {
			gameObject.GetComponent<Image> ().sprite = btnSprite [0];
		} else if(Input.GetKey(KeyCode.DownArrow)){
			gameObject.GetComponent<Image> ().sprite = btnSprite [1];
		}
	}
}
