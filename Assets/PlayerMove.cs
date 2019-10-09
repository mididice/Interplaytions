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
	int curxPos, curyPos, maxPosX, maxPosY;
	int CubeType, backPosx, backPosy;
    int visitTrue;
    //private bool contected;
	Stack<Point> st;
	// Use this for initialization
	void Start () {
        //contected = false;
		curxPos = 0;
		curyPos = 0;
		backPosx = 0;
		backPosy = 0;
        visitTrue = 0;
		maxPosX = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().getX();
		maxPosY = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().getY();
	}
  

    public bool backPosEqual(){
		KeyValuePair<int,int> lastSelected = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().curPosPeek ();
        if (lastSelected.Key == -1)
            return false;
        else if (backPosx == lastSelected.Key && backPosy == lastSelected.Value) {
            return true;
        }
		return false;
	}

    void Move(){
        Vector3 movementUpCube = new Vector3(0, curCube.transform.localScale.y + 0.157f, 0);
        Vector3 movementRightCube = new Vector3(curCube.transform.localScale.x + 0.157f, 0, 0);
        int curType = -1;
		int curGetType = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().getGetType ();
		if (Input.GetKeyUp (KeyCode.UpArrow)) {
			if (curyPos + 1 < maxPosY) { 
				backPosx = curxPos;
				backPosy = curyPos;
				curyPos += 1;
				curType = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().getPos (curxPos,curyPos);
				visitTrue = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().visitChk (curxPos,curyPos);
				bool IsTrue = backPosEqual ();
				if (((curType == 0 || curType == curGetType)&& visitTrue==0) || curGetType==-1||(IsTrue&& visitTrue==curGetType)) {
					if ((IsTrue&& visitTrue==curGetType)) {
                        if (curType == curGetType && curType == visitTrue){
                            stopAudio();
                        }
                        eraseRoute(backPosx, backPosy);
                    }
                    countTurnAndPlayEffect();
                    transform.position += movementUpCube;
				} else {
					curyPos -= 1;
				}
				//st.Push (Point (curxPos, curyPos));
			}
        }
        else if (Input.GetKeyUp (KeyCode.DownArrow)) {
			if (curyPos - 1 >= 0) {
				backPosx = curxPos;
				backPosy = curyPos;
				curyPos -= 1;
				curType = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().getPos (curxPos,curyPos);
				visitTrue = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().visitChk (curxPos,curyPos);
				bool IsTrue = backPosEqual ();
				if (((curType == 0 || curType == curGetType)&& visitTrue==0) || curGetType==-1 || (IsTrue&& visitTrue==curGetType)) {
					if ((IsTrue&& visitTrue==curGetType)) {
                        if (curType == curGetType && curType == visitTrue){
                            stopAudio();
                        }
                        eraseRoute(backPosx, backPosy);
                    }
                    countTurnAndPlayEffect();
                    transform.position -= movementUpCube;
                } else {
					curyPos += 1;
				}
				//st.Push (Point (curxPos, curyPos));
			}
        }
        else if (Input.GetKeyUp (KeyCode.LeftArrow)) {
			if (curxPos - 1 >= 0) {
				backPosx = curxPos;
				backPosy = curyPos;
				curxPos -= 1;
				curType = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().getPos (curxPos,curyPos);
				visitTrue = GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().visitChk (curxPos,curyPos);
                bool IsTrue = backPosEqual();
                if (((curType == 0 || curType == curGetType)&& visitTrue==0) || curGetType==-1 ||(IsTrue&& visitTrue==curGetType)) {                 
                    if ((IsTrue&& visitTrue==curGetType)) {
                        if (curType == curGetType && curType == visitTrue){
                            stopAudio();
                        }
                        eraseRoute(backPosx, backPosy);
                    }
                    countTurnAndPlayEffect();
                    transform.position -= movementRightCube;
                } else {
					curxPos += 1;
				}
                //st.Push (Point (curxPos, curyPos));
            }
        }
        else if (Input.GetKeyUp (KeyCode.RightArrow)) {
			if (curxPos + 1 < maxPosX) {
                backPosx = curxPos;
                backPosy = curyPos;
                curxPos += 1;
                curType = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().getPos(curxPos, curyPos);
                visitTrue = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().visitChk(curxPos, curyPos);
                bool IsTrue = backPosEqual();
                if (((curType == 0 || curType == curGetType) && visitTrue == 0) || curGetType == -1 || (IsTrue && visitTrue == curGetType)){
                    if ((IsTrue && visitTrue == curGetType)){
                        if (curType == curGetType && curType == visitTrue){
                            stopAudio();
                        }
                        eraseRoute(backPosx, backPosy);
                    }
                    countTurnAndPlayEffect();
                    transform.position += movementRightCube;
                }
                else{
                    curyPos -= 1;
                }
                //st.Push (Point (curxPos, curyPos));
                
            }
            

        }
        setXYAndType(curxPos, curyPos, curType, curGetType);
    }

    private void countTurnAndPlayEffect() {
        GameObject.Find("FontController").GetComponent<FontController>().CountingTurn();        
        GameObject.Find("effectSound").GetComponent<AudioSource>().Play();
    }

    private void setXYAndType(int curxPos, int curyPos, int curType, int curGetType) {
        GameObject.Find("Main Camera").GetComponent<MatrixCreate>().setXY(curxPos, curyPos);
        if (curType > 0 && curType == curGetType ){
            GameObject.Find("Main Camera").GetComponent<MatrixCreate>().setGetType(-1);
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
        
            bool pickTrue = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().chkCompleteCube(CubeType);
            if (!pickTrue)
            {
                // contected = true;
                //GameObject.Find("MidiFileChecking").GetComponent<midPlayer>().GenerateUrl(CubeType);
                GameObject.Find("CubeSound").GetComponent<SoundSetting>().settingSound(CubeType - 1);
                GameObject.Find("CubeSound").GetComponent<AudioSource>().Play();
                GameObject.Find("Main Camera").GetComponent<MatrixCreate>().curPosPush(CubeType);
                GameObject.Find("Main Camera").GetComponent<MatrixCreate>().setGetType(CubeType);
            }
		}
	}

    private void eraseRoute(int backPosx, int backPosy) {
        GameObject.Find("Main Camera").GetComponent<MatrixCreate>().myRendererSet(backPosx, backPosy);
        GameObject.Find("Main Camera").GetComponent<MatrixCreate>().curPosPop(backPosx, backPosy);
    }

    private void stopAudio() {
        GameObject.Find("CubeSound").GetComponent<AudioSource>().Stop();
    }

	// Update is called once per frame
	void Update () {
		Move ();
		
	}
}
