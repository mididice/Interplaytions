using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyCrash : MonoBehaviour {

	private SpriteRenderer myRenderer;
	public Sprite []sprite;
	public GameObject curPlayer;
	private Animator ani;

	void PlayAnimation(int idx){
		if (idx == 0)
			ani.SetTrigger ("Empty");
		else if (idx == 1)
			ani.SetTrigger ("Cube1");
		else if (idx == 2)
			ani.SetTrigger ("Cube2");
		else if (idx == 3)
			ani.SetTrigger ("Cube3");
		else if (idx == 4)
			ani.SetTrigger ("Cube4");
		else if (idx == 5)
			ani.SetTrigger ("Cube5");
	}
	// Use this for initialization
	void Start () {
		if (ani == null) {
			//myRenderer = GetComponent<SpriteRenderer> ();	
			ani = gameObject.GetComponent<Animator> ();
		}
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			int curType=GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().getGetType();
			int BackPosChk = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().visitChk ();
			if (ani == null) {
				//myRenderer = GetComponent<SpriteRenderer> ();
				ani = gameObject.GetComponent<Animator> ();
				
				if (curType > 0) {
					if (BackPosChk==1) {
						GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().curPosPush (curType);
						//myRenderer.sprite = sprite [0];
						PlayAnimation (curType);
					} 
				}
			} else {
				if (curType > 0) {
					if (BackPosChk==1) {
						GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().curPosPush (curType);
						//myRenderer.sprite = sprite [0];
						PlayAnimation (curType);
					}
				}
			}
		}
	}

	public void Setrenderer(){
		//myRenderer.sprite = sprite [1];
		PlayAnimation (0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
