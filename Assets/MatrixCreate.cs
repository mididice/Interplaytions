using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixCreate : MonoBehaviour {

	public GameObject player;
	public GameObject []cube;
	// Use this for initialization
	int xPos,yPos,row, col,getType,curType;
	int[,] Matrix;

	void Start () {
		row = col = 8;
		getType = -1;
		curType = -1;

		 Matrix= new int[row, col];

		for (int i = 0; i < row; i++) {
			for (int j = 0; j < col; j++) {
				Matrix [i, j] = 0;
			}
		}

		Matrix [0, 3] = 1;
		Matrix [1, 7] = 1;
		Matrix [1, 5] = 2;
		Matrix [2, 7] = 2;
		Matrix [2, 3] = 3;
		Matrix [6, 5] = 3;
		Matrix [5, 3] = 4;
		Matrix [7, 3] = 4;
		Matrix [7, 5] = 5;
		Matrix [1, 3] = 5;
	
		float cubeRow =cube[0].transform.localScale.x+0.3f;
		float cubeCol = cube[0].transform.localScale.y;
		Vector3 initPosition = new Vector3 (0, -3, 0);

		for (int i = 0; i < row; i++) {
			for (int j = 0; j < col; j++) {
				int idx = Matrix [i, j];
				Instantiate (cube [idx], new Vector3 (initPosition.x + (cubeRow * i), initPosition.y + (cubeCol * j), initPosition.z), Quaternion.identity);
			}
		}

		xPos = 0;
		yPos = 0;
		Instantiate (player, new Vector3 (0.02f, -3.04f,-0.7f), Quaternion.identity);
	
	}

	public int getX(){
		return row;
	}

	public int getY(){
		return col;
	}
		
	public void setXY(int x,int y){
		xPos = x;
		yPos = y;
	}

	public int getPos(){
		return Matrix [xPos, yPos];
	}
	public int getPos(int x,int y){
		return Matrix [x, y];
	}

	public void setGetType(int val){
		getType = val;
	}

	public int getGetType(){
		return getType;
	}

	public void setCurType(int val){
		curType = val;
	}
	public int getCurType(){
		return curType;
	}
	
	// Update is called once per frame
	void Update () {
			
	}
}
