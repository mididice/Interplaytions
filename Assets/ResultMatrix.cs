using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResultMatrix : MonoBehaviour {

	string resultCube;
	public GameObject []cube;
	private int[,] Matrix;
	private bool[,] blackCubeChk;
	private GameObject[,] matrixCube;
	private int row,col;
	// Use this for initialization
	void Start () {
		row = 12;
		col = 6;

		resultCube = PlayerPrefs.GetString ("UserMatrix");
		Matrix= new int[row,col];
		matrixCube = new GameObject[row,col];
		blackCubeChk = new bool[row, col];
		print (resultCube);
		for (int i = 0; i < 12; i++) {
			for (int j = 0; j < 6; j++) {
				Matrix [i, j] = 0;
				blackCubeChk [i, j] = false;
			}
		}
		print (resultCube.Length);
		int curtype = 0;
		int num = 48;

		for (int i = 0; i < resultCube.Length; ) {
			if (i+1 >= (resultCube.Length - 1))
				break; 
			if(resultCube[i]=='@'){
				i++;
				int x= Convert.ToInt32 (resultCube [i])-num;
				int y= Convert.ToInt32 (resultCube [i+1])-num;
				print ("@"+ "  " +curtype + " " +x+ " "+y+ " i : "+i);
				Matrix [x, y] = curtype;
				i += 2;
			}
			else if (resultCube [i] == '#') {
				curtype = Convert.ToInt32 (resultCube [i + 1])-num;
				print (" i : " + i);
				i += 2;
			} else {
				int x= Convert.ToInt32 (resultCube [i])-num;
				int y= Convert.ToInt32 (resultCube [i+1])-num;
				//print (x + "  " + y);
				Matrix [x, y] = curtype;
				print ("#" + " " + x + " " + y+ " i : "+i);
				blackCubeChk [x, y] = true;
				i+=2;
			}
		}

		float cubeRow =cube[0].transform.localScale.x+0.1f;
		float cubeCol = cube[0].transform.localScale.y+0.1f;
		Vector3 initPosition = new Vector3 (-3, -1.45f, 0);

		for (int i = 0; i < row; i++) {
			for (int j = 0; j < col; j++) {
				int idx = Matrix [i, j];
				if (blackCubeChk [i, j]) {
					print (i + " " + j);
					matrixCube [i, j] = Instantiate (cube [0], new Vector3 (initPosition.x + (cubeRow * i), initPosition.y + (cubeCol * j), initPosition.z), Quaternion.identity) as GameObject;
				} else {
					if(idx>0)print ("color");
					matrixCube [i, j] = Instantiate (cube [idx], new Vector3 (initPosition.x + (cubeRow * i), initPosition.y + (cubeCol * j), initPosition.z), Quaternion.identity) as GameObject;
				}
			}
		}


	}
		
	// Update is called once per frame
	void Update () {
		
	}
}
