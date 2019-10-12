using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ResultMatrix : MonoBehaviour {

    int map;
	public GameObject[] cube;
	private int[,] Matrix;
	private GameObject[,] matrixCube;
	private int row,col;

    void MatrixPatternInit(int idx)
    {
        if (idx == 0)
        {
            Matrix[1, 4] = 1;
            Matrix[4, 3] = 1;
            Matrix[2, 3] = 2;
            Matrix[5, 5] = 2;
            Matrix[0, 2] = 3;
            Matrix[8, 0] = 3;
            Matrix[4, 1] = 4;
            Matrix[10, 3] = 4;
            Matrix[7, 4] = 5;
            Matrix[10, 1] = 5;
        }
        else if (idx == 1)
        {
            Matrix[1, 2] = 1;
            Matrix[11, 2] = 1;
            Matrix[3, 0] = 2;
            Matrix[6, 4] = 2;
            Matrix[1, 4] = 3;
            Matrix[2, 1] = 3;
            Matrix[7, 2] = 4;
            Matrix[9, 4] = 4;
            Matrix[3, 3] = 5;
            Matrix[5, 2] = 5;
        }
        else if (idx == 2)
        {
            Matrix[1, 5] = 1;
            Matrix[8, 4] = 1;
            Matrix[2, 5] = 2;
            Matrix[5, 2] = 2;
            Matrix[3, 1] = 3;
            Matrix[5, 4] = 3;
            Matrix[8, 3] = 4;
            Matrix[10, 1] = 4;
            Matrix[3, 3] = 5;
            Matrix[7, 4] = 5;
        }
        else if (idx == 3)
        {
            Matrix[5, 1] = 1;
            Matrix[5, 4] = 1;
            Matrix[2, 2] = 2;
            Matrix[8, 4] = 2;
            Matrix[5, 2] = 3;
            Matrix[9, 1] = 3;
            Matrix[1, 5] = 4;
            Matrix[3, 4] = 4;
            Matrix[7, 3] = 5;
            Matrix[2, 0] = 5;
        }
        else if (idx == 4)
        {
            Matrix[1, 4] = 1;
            Matrix[4, 1] = 1;
            Matrix[1, 2] = 2;
            Matrix[6, 0] = 2;
            Matrix[8, 0] = 3;
            Matrix[11, 5] = 3;
            Matrix[3, 3] = 4;
            Matrix[9, 4] = 4;
            Matrix[5, 5] = 5;
            Matrix[9, 2] = 5;
        }
    }

    // Use this for initialization
    void Start () {
		row = 12;
		col = 6;
        
        Matrix = new int[row, col];
        matrixCube = new GameObject[row,col];

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                Matrix[i, j] = 0;
            }
        }
        map = PlayerPrefs.GetInt("map");
        MatrixPatternInit(map);

        float cubeRow = 1.01f;
        float cubeCol = 1f;
        Vector3 initPosition = new Vector3(0.71f, -1.42f, 0);

        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                int idx = Matrix[i, j];
                cube[idx].transform.localScale = new Vector3(1f, 1f, 0);
                matrixCube[i, j] = Instantiate(cube[idx], new Vector3(initPosition.x + (cubeRow * i), initPosition.y + (cubeCol * j) , initPosition.z), Quaternion.identity) as GameObject;
            }
        }
        
    }
		
	// Update is called once per frame
	void Update () {
		
	}
}
