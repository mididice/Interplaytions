using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartBackground : MonoBehaviour {

	public GameObject BgCube;
	private int[,] Matrix;
	private int row, col;
	// Use this for initialization
	void Start () {
		row = 15;
		col = 7;

		Matrix= new int[row, col];

		for (int i = 0; i < row; i++) {
			for (int j = 0; j < col; j++) {
				Matrix [i, j] = 0;
			}
		}

		float cubeRow =BgCube.transform.localScale.x+0.1f;
		float cubeCol = BgCube.transform.localScale.y+0.1f;
		Vector3 initPosition = new Vector3 (-9.7f, -4.17f, 0);

		for (int i = 0; i < row; i++) {
			for (int j = 0; j < col; j++) { 
				Instantiate (BgCube, new Vector3 (initPosition.x + (cubeRow * i), initPosition.y + (cubeCol * j), initPosition.z), Quaternion.identity);
			}
		}
		
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
