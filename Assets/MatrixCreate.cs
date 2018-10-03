using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatrixCreate : MonoBehaviour {

	public GameObject player;
	public GameObject []cube;
	GameObject[,] matrixCube;
	// Use this for initialization
	private int xPos,yPos,row, col,getType,curType;
	private int[,] Matrix;
	private int[,] visit;
	Stack<KeyValuePair<int,int>> stack=new Stack<KeyValuePair<int,int>>();

	void Start () {
		row = 12;
		col = 6;
		getType = -1;
		curType = -1;
	
		Matrix= new int[row, col];
		visit = new int[row, col];
		matrixCube = new GameObject[row,col];

		for (int i = 0; i < row; i++) {
			for (int j = 0; j < col; j++) {
				Matrix [i, j] = 0;
			}
		}

		Matrix [0, 4] = 1;
		Matrix [2, 3] = 1;
		Matrix [0, 2] = 2;
		Matrix [3, 2] = 2;
		Matrix [3, 0] = 3;
		Matrix [5, 0] = 3;
		Matrix [5, 3] = 4;
		Matrix [1, 3] = 4;
		Matrix [1, 5] = 5;
		Matrix [3, 3] = 5;
	
		float cubeRow =cube[0].transform.localScale.x+0.1f;
		float cubeCol = cube[0].transform.localScale.y+0.1f;
		Vector3 initPosition = new Vector3 (-3, -1.3f, 0);

		for (int i = 0; i < row; i++) {
			for (int j = 0; j < col; j++) {
				int idx = Matrix [i, j];
				matrixCube[i,j]=Instantiate (cube [idx], new Vector3 (initPosition.x + (cubeRow * i), initPosition.y + (cubeCol * j), initPosition.z), Quaternion.identity) as GameObject;
			}
		}

		xPos = 0;
		yPos = 0;
		Instantiate (player, new Vector3 (-3.02f, -1.34f,-0.7f), Quaternion.identity);
	
	}

	public int visitChk(){
		if (visit [xPos, yPos] != 0)
			return 0;
		return 1;
	}
	public int visitChk(int x,int y){ // current visit status.
		if (visit [x, y] != 0)
			return visit [x, y];
		return 0;
	}

	public void myRendererSet(int x,int y){
		matrixCube [x, y].GetComponent<EmptyCrash> ().Setrenderer ();
	}

	public void curPosPush(int type){
		visit [xPos, yPos] = type;
		stack.Push (new KeyValuePair<int,int> (xPos, yPos));
	}

	public void curPosPop(int x,int y){
		stack.Pop ();
		//visit [x, y] = 0;
	}

	public KeyValuePair<int,int> curPosPeek(){
		if (stack.Count == 0)
			return new KeyValuePair<int,int> (-1, -1);
		return stack.Peek();
	}

	public int getX(){ // return current max row size.
		return row;
	}

	public int getY(){ // return current max col size.
		return col;
	}
		
	public void setXY(int x,int y){ // set current x,y pos setting.
		xPos = x;
		yPos = y;
	}

	public int getPos(){ // get current Matrix status.
		return Matrix [xPos, yPos];
	}
	public int getPos(int x,int y){
		return Matrix [x, y];
	}

	public void setGetType(int val){ // set current Pick ColorType status. 
		if(val==-1) stack.Clear();
		getType = val;

	}

	public int getGetType(){ // get current Pick ColorType status. 
		return getType;
	}

	public void setCurType(int val){ // set current ColorType status.
		curType = val;
	}
	public int getCurType(){ // get current ColorType status.
		return curType;
	}
	
	// Update is called once per frame
	void Update () {
			
	}
}
