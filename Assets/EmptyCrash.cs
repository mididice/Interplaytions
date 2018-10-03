using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyCrash : MonoBehaviour {

	private SpriteRenderer myRenderer;
	public Sprite []sprite;
	public GameObject curPlayer;
	// Use this for initialization
	void Start () {
		if (myRenderer == null) {
			myRenderer = GetComponent<SpriteRenderer> ();	
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			int curType=GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().getGetType();
			int BackPosChk = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().visitChk ();
			if (myRenderer == null) {
				myRenderer = GetComponent<SpriteRenderer> ();
				int pickType = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().getPos ();
				if (curType > 0) {
					if (BackPosChk==1) {
						GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().curPosPush (curType);
						myRenderer.sprite = sprite [0];
					} 
				}
			} else {
				if (curType > 0) {
					if (BackPosChk==1) {
						GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().curPosPush (curType);
						myRenderer.sprite = sprite [0];
					}
				}
			}
		}
	}

	public void Setrenderer(){
		myRenderer.sprite = sprite [1];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
