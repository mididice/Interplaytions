using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MatrixCreate : MonoBehaviour {

	public GameObject gameOverPanel,gameWinnerPanel;
	public GameObject player;
	public GameObject []cube;
	public Sprite[] BlackSprite;
    public Sprite[] resultSprite;
	private GameObject[,] matrixCube;
	private GameObject curPlayer;
    // Use this for initialization
    private int[] typeArray;
	private int xPos,yPos,row, col,getType,curType;
	private int[,] Matrix;
	private int[,] visit;
	private bool[] completeCube;
	private Animator ani;
	private SpriteRenderer renderer;
	private int bottomTileIdx;
	private string Contectedmatrix;
	Stack<KeyValuePair<int,int>> stack=new Stack<KeyValuePair<int,int>>();
    
	void MatrixPatternInit(int idx){
		if (idx == 0) {
			Matrix [1, 4] = 1;
			Matrix [4, 3] = 1;
			Matrix [2, 3] = 2;
			Matrix [5, 5] = 2;
			Matrix [0, 2] = 3;
			Matrix [8, 0] = 3;
			Matrix [4, 1] = 4;
			Matrix [10, 3] = 4;
			Matrix [7, 4] = 5;
			Matrix [10, 1] = 5;
		} else if (idx == 1) {
			Matrix [1, 2] = 1;
			Matrix [11,2] = 1;
			Matrix [3, 0] = 2;
			Matrix [6, 4] = 2;
			Matrix [1, 4] = 3;
			Matrix [2, 1] = 3;
			Matrix [7,2] = 4;
			Matrix [9, 4] = 4;
			Matrix [3, 3] = 5;
			Matrix [5, 2] = 5;
		} else if (idx == 2) {
			Matrix [1, 5] = 1;
			Matrix [8,4] = 1;
			Matrix [2, 5] = 2;
			Matrix [5, 2] = 2;
			Matrix [3, 1] = 3;
			Matrix [5, 4] = 3;
			Matrix [8, 3] = 4;
			Matrix [10, 1] = 4;
			Matrix [3, 3] = 5;
			Matrix [7, 4] = 5;
		} else if (idx == 3) {
			Matrix [5, 1] = 1;
			Matrix [5, 4] = 1;
			Matrix [2, 2] = 2;
			Matrix [8, 4] = 2;
			Matrix [5, 2] = 3;
			Matrix [9, 1] = 3;
			Matrix [1, 5] = 4;
			Matrix [3, 4] = 4;
			Matrix [7, 3] = 5;
			Matrix [2, 0] = 5;
		} else if (idx == 4) {
			Matrix [1, 4] = 1;
			Matrix [4, 1] = 1;
			Matrix [1, 2] = 2;
			Matrix [6, 0] = 2;
			Matrix [8, 0] = 3;
			Matrix [11, 5] = 3;
			Matrix [3, 3] = 4;
			Matrix [9, 4] = 4;
			Matrix [5, 5] = 5;
			Matrix [9, 2] = 5;
		}
	}

	void Start () {
        Time.timeScale = 1;
        PlayerPrefs.SetString ("UserMatrix", "");
		PlayerPrefs.SetInt ("Score", 0);
        PlayerPrefs.SetString("resultTiles", "");
		Contectedmatrix = "";
		gameOverPanel.SetActive (false);
		gameWinnerPanel.SetActive (false);
		row = 12;
		col = 6;
		getType = -1;
		curType = -1;
		bottomTileIdx = 1;
        typeArray = new int[6];
		completeCube = new bool[6];
		Matrix= new int[row, col];
		visit = new int[row, col];
		matrixCube = new GameObject[row,col];

        for (int i = 0; i < 6; i++) completeCube[i] = false;
		for (int i = 0; i < row; i++) {
			for (int j = 0; j < col; j++) {
				Matrix [i, j] = 0;
			}
		}

		MatrixPatternInit (Random.Range(0, 4));
	
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

	public string getContectedmatrix(){
		return Contectedmatrix;
	}

    public void EndScene()
    {
        SceneManager.LoadScene("endscene");
    }


    public void PlayerEnd(int status){
       
		curPlayer.SetActive (false);
        if (status == 0) {
			gameOverPanel.SetActive (true);
        }
		else
			gameWinnerPanel.SetActive (true);
      //  string file=GameObject.Find("MidiFileChecking").GetComponent<midPlayer>().GetCombineFile();
       // GameObject.Find("MidiFileChecking").GetComponent<testmid>().SetsFile(file);
      
    }

    private void EndSceneCall()
    {
        Debug.Log("End Scene Call");
        string file = GameObject.Find("MidiFileChecking").GetComponent<midPlayer>().GetCombineFile();
        GameObject.Find("MidiFileChecking").GetComponent<testmid>().SetsFile(file);
        SceneManager.LoadScene("endscene");
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
    public int[] getTypeArray() {
        return typeArray;
    }
    public bool chkCompleteCube(int idx) {
        return completeCube[idx];
    }
	public void setGetType(int val){ // set current Pick ColorType status. 
		if (val == -1) {
			if (stack.Count > 1) {
				string typeName = "BottomTile" + bottomTileIdx.ToString ();
                typeArray[bottomTileIdx] = getType - 1;
                GameObject.Find(typeName).GetComponent<Image>().sprite=BlackSprite [getType-1];
				bottomTileIdx++;
				GameObject.Find ("FontController").GetComponent<FontController> ().CountingScore ((stack.Count - 1) * 100 + 1000);
                GameObject.Find("MidiFileChecking").GetComponent<midPlayer>().GenerateUrl(getType);
                GameObject.Find("CubeSound").GetComponent<AudioSource>().Stop();
                GameObject.Find("tileContectedSound").GetComponent<AudioSource>().Play();
                
                completeCube [getType] = true;
			}

			bool IsTrue = false;
			for (int i = 1; i <= 5; i++)
				if (!completeCube[i])
					IsTrue = true;
			bool contectedTrue = false;

			while (stack.Count > 0) {
				KeyValuePair<int,int> tmp = stack.Peek ();
				ani = matrixCube [tmp.Key, tmp.Value].GetComponent<Animator> ();
				if (stack.Count <=1) {
					if (contectedTrue)
						Contectedmatrix = Contectedmatrix + "@"+tmp.Key.ToString () + tmp.Value.ToString ();
					ani.SetTrigger ("Empty");
				}
				else if(stack.Count>1) {
					ani.enabled = false;
					if(!contectedTrue)Contectedmatrix = Contectedmatrix +  "#" + getType.ToString ()+tmp.Key.ToString () + tmp.Value.ToString ();
					else Contectedmatrix = Contectedmatrix +tmp.Key.ToString () + tmp.Value.ToString ();
					contectedTrue=true;
					renderer = matrixCube [tmp.Key, tmp.Value].GetComponent<SpriteRenderer> ();
					renderer.sprite = BlackSprite [getType-1];
				}
				stack.Pop ();
			}
			stack.Clear ();
			getType = -1;

			if (!IsTrue) {
				PlayerEnd (1);
				int curScore = GameObject.Find ("FontController").GetComponent<FontController> ().getScore ();
				PlayerPrefs.SetInt ("Score", curScore);
				PlayerPrefs.SetString ("UserMatrix", Contectedmatrix);
                string gotTiles = "";
                for (int i = 0; i < typeArray.Length; i++) {
                    gotTiles += typeArray[i].ToString()+"|";
                }
                PlayerPrefs.SetString("resultTiles", gotTiles);
                Debug.Log(gotTiles);
                Invoke("EndSceneCall", 5.0f);
				//SceneManager.LoadScene("endscene");
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
