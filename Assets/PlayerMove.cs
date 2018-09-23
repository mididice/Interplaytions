using System.Collections;
using System.Collections.Generic;
using UnityEngine;

struct Point
{
	int x,y;
	public Point(int _x,int _y){
		this.x = _x;
		this.y = _y;
	}
};
public class PlayerMove : MonoBehaviour {

	public GameObject curCube;
	int curxPos, curyPos,maxPosX,maxPosY;
	int CubeType;

	Stack<Point> st;
	// Use this for initialization
	void Start () {
		curxPos = 0;
		curyPos = 0;
		maxPosX = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().getX();
		maxPosY = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().getY();
	}


	void Move(){
		int curType = -1;
		int curGetType = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().getGetType ();
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			if (curyPos + 1 < maxPosY) { 
				curyPos += 1;
				curType = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().getPos (curxPos,curyPos);
				if (curType == 0 || curType == curGetType || curGetType==-1) {
					transform.position += new Vector3 (0, (curCube.transform.localScale.y), 0);
				} else {
					curyPos -= 1;
				}
				//st.Push (Point (curxPos, curyPos));
			}
		} else if (Input.GetKeyUp (KeyCode.DownArrow)) {
			if (curyPos - 1 >= 0) {
				curyPos -= 1;
				curType = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().getPos (curxPos,curyPos);
				if (curType == 0 || curType == curGetType || curGetType==-1) {
					transform.position -= new Vector3 (0, (curCube.transform.localScale.y), 0);
				} else {
					curyPos += 1;
				}
				//st.Push (Point (curxPos, curyPos));
			}
		} else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			if (curxPos - 1 >= 0) {
				curxPos -= 1;
				curType = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().getPos (curxPos,curyPos);
				if (curType == 0 || curType == curGetType || curGetType==-1) {
					transform.position -= new Vector3 (curCube.transform.localScale.x+0.3f,  0, 0);
				} else {
					curxPos += 1;
				}

				//st.Push (Point (curxPos, curyPos));
			}
		} else if (Input.GetKeyUp (KeyCode.RightArrow)) {
			if (curxPos + 1 < maxPosX) {
				curxPos += 1;
				curType = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().getPos (curxPos,curyPos);
				if (curType == 0 || curType == curGetType || curGetType==-1) {
					transform.position += new Vector3 (curCube.transform.localScale.x+0.3f, 0, 0);
				} else {
					curxPos -= 1;
				}
				//st.Push (Point (curxPos, curyPos));
			}
		}
		GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().setXY (curxPos, curyPos);
		if (curType > 0 && curType == curGetType) {
			GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().setGetType (-1);
		}
	}

	void OnTriggerEnter2D(Collider2D col){

		if (col.gameObject.tag == "Cube1") {
			GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().setCurType (1);
		}
		else if (col.gameObject.tag == "Cube2") {
			GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().setCurType (2);
		}
		else if (col.gameObject.tag == "Cube3") {
			GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().setCurType (3);
		}
		else if (col.gameObject.tag == "Cube4") {
			GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().setCurType (4);
		}
		else if (col.gameObject.tag == "Cube5") {
			GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().setCurType (5);
		}
		else{
			GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().setCurType (0);
		}

	}


	public void PickCube(){
		CubeType=GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().getCurType();
		if (CubeType > 0) {
			GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().setGetType (CubeType);
		}
	}
	// Update is called once per frame
	void Update () {
		Move ();
		
	}
}
