using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatrixCreate : MonoBehaviour {

	public GameObject gameOverPanel;
	public GameObject player;
	public GameObject []cube;
	public Sprite[] BlackSprite;
	private GameObject[,] matrixCube;
	private GameObject curPlayer;
	// Use this for initialization
	private int xPos,yPos,row, col,getType,curType;
	private int[,] Matrix;
	private int[,] visit;
	private bool[] completeCube;
	private Animator ani;
	private SpriteRenderer renderer;
	private int bottomTileIdx;
	Stack<KeyValuePair<int,int>> stack=new Stack<KeyValuePair<int,int>>();

	void Start () {
		gameOverPanel.SetActive (false);
		row = 12;
		col = 6;
		getType = -1;
		curType = -1;
		bottomTileIdx = 1;
		completeCube = new bool[6];
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
		Vector3 initPosition = new Vector3 (-3, -1.83f, 0);

		for (int i = 0; i < row; i++) {
			for (int j = 0; j < col; j++) {
				int idx = Matrix [i, j];
				matrixCube[i,j]=Instantiate (cube [idx], new Vector3 (initPosition.x + (cubeRow * i), initPosition.y + (cubeCol * j), initPosition.z), Quaternion.identity) as GameObject;
			}
		}

		xPos = 0;
		yPos = 0;
		curPlayer=Instantiate (player, new Vector3 (-3.00f, -1.83f,-0.7f), Quaternion.identity);
	
	}

	public void PlayerEnd(){
		curPlayer.SetActive (false);
		gameOverPanel.SetActive (true);
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
		if (Matrix [x, y] == 0) {
			matrixCube [x, y].GetComponent<EmptyCrash> ().Setrenderer ();
		}
	}

	public void curPosPush(int type){
		visit [xPos, yPos] = type;
		stack.Push (new KeyValuePair<int,int> (xPos, yPos));
	}

	public void curPosPop(int x,int y){
		stack.Pop ();
		visit [x, y] = 0;
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
		if (val == -1) {
			if (stack.Count > 1) {
				string typeName = "BottomTile" + bottomTileIdx.ToString ();
				GameObject.Find(typeName).GetComponent<Image>().sprite=BlackSprite [getType-1];
				bottomTileIdx++;
				GameObject.Find ("FontController").GetComponent<FontController> ().CountingScore ((stack.Count - 1) * 100 + 1000);
				completeCube [getType] = true;
			}

			bool IsTrue = false;
			for (int i = 1; i <= 5; i++)
				if (!completeCube[i])
					IsTrue = true;

			while (stack.Count > 0) {
				KeyValuePair<int,int> tmp = stack.Peek ();
				ani = matrixCube [tmp.Key, tmp.Value].GetComponent<Animator> ();
				if (stack.Count <=1) {
					ani.SetTrigger ("Empty");
				}
				else if(stack.Count>1) {
					ani.enabled = false;
					renderer = matrixCube [tmp.Key, tmp.Value].GetComponent<SpriteRenderer> ();
					renderer.sprite = BlackSprite [getType-1];
				}
				stack.Pop ();
			}
			stack.Clear ();
			getType = -1;

			if (!IsTrue) {
				PlayerEnd ();
				Time.timeScale = 0;
			}
		} else {
			ani=matrixCube[xPos,yPos].GetComponent<Animator>();
			ani.SetTrigger ("Pick");
			getType = val;
		}
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
		if (Input.GetKeyUp (KeyCode.A)) {
			player.GetComponent<PlayerMove> ().PickCube ();
		}
			
	}
}
