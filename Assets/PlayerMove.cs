using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Point
{
    public int x, y;
    public Point(int _x, int _y)
    {
        this.x = _x;
        this.y = _y;
    }
};
public class PlayerMove : MonoBehaviour
{

    public GameObject curCube;
    int curxPos, curyPos, maxPosX, maxPosY;
    int CubeType, backPosx, backPosy;
    int visited;
    Stack<Point> footprints;
    public static int connectedNum;
    // Use this for initialization
    void Start()
    {
        curxPos = 0;
        curyPos = 0;
        backPosx = 0;
        backPosy = 0;
        visited = 0;
        footprints = new Stack<Point>();
        maxPosX = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().getX();
        maxPosY = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().getY();
        connectedNum = 0;
    }

    public bool backPosEqual()
    {
        KeyValuePair<int, int> lastSelected = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().curPosPeek();
        if (lastSelected.Key == -1)
            return false;
        else if (backPosx == lastSelected.Key && backPosy == lastSelected.Value)
            return true;
        return false;
    }


    void Move()
    {
        int curType = -1;
        int pickedType = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().getGetType();
        Vector3 movementUpCube = new Vector3(0, curCube.transform.localScale.y + 0.157f, 0);
        Vector3 movementRightCube = new Vector3(curCube.transform.localScale.x + 0.157f, 0, 0);
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (curyPos + 1 < maxPosY)
            {
                backPosx = curxPos;
                backPosy = curyPos;
                curyPos += 1;
                curType = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().getPos(curxPos, curyPos);
                visited = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().visitChk(curxPos, curyPos);
                bool isLastSelected = backPosEqual();
                if (((curType == 0 || curType == pickedType) && visited == 0) || pickedType == -1 || (isLastSelected && visited == pickedType))
                {
                    if (visited == pickedType && pickedType > -1)
                    {
                        Point prevPoint = footprints.Pop();
                        if (prevPoint.x == curxPos && prevPoint.y == curyPos)
                        {
                            if (curType == pickedType && curType == visited)
                            {
                                stopAudio();
                            }
                            eraseRoute(backPosx, backPosy);
                            transform.position += movementUpCube;
                            countTurnAndPlayEffect();
                            moveCube(curxPos, curyPos, curType, pickedType, visited);
                        }
                        else
                        {
                            footprints.Push(prevPoint);
                            curyPos -= 1;
                            setCurrentXY(curxPos, curyPos);
                        }
                    }
                    else
                    {
                        footprints.Push(new Point(backPosx, backPosy));
                        transform.position += movementUpCube;
                        countTurnAndPlayEffect();
                        moveCube(curxPos, curyPos, curType, pickedType, visited);
                    }
                    
                }
                else
                {
                    curyPos -= 1;
                    setCurrentXY(curxPos, curyPos);
                }
                
            }

        }
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (curyPos - 1 >= 0)
            {
                backPosx = curxPos;
                backPosy = curyPos;
                curyPos -= 1;
                curType = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().getPos(curxPos, curyPos);
                visited = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().visitChk(curxPos, curyPos);
                bool isLastSelected = backPosEqual();
                if (((curType == 0 || curType == pickedType) && visited == 0) || pickedType == -1 || (isLastSelected && visited == pickedType))
                {
                    if (isLastSelected && visited == pickedType && pickedType > -1)
                    {
                        Point prevPoint = footprints.Pop();
                        if (prevPoint.x == curxPos && prevPoint.y == curyPos)
                        {
                            if (curType == pickedType && curType == visited)
                            {
                                stopAudio();
                            }
                            eraseRoute(backPosx, backPosy);
                            transform.position -= movementUpCube;
                            countTurnAndPlayEffect();
                            moveCube(curxPos, curyPos, curType, pickedType, visited);
                        }
                        else
                        {
                            footprints.Push(prevPoint);
                            curyPos += 1;
                            setCurrentXY(curxPos, curyPos);
                        }
                    }
                    else
                    {
                        footprints.Push(new Point(backPosx, backPosy));
                        transform.position -= movementUpCube;
                        countTurnAndPlayEffect();
                        moveCube(curxPos, curyPos, curType, pickedType, visited);
                    }
                    
                }
                else
                {
                    curyPos += 1;
                    setCurrentXY(curxPos, curyPos);
                }
                
            }
            
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (curxPos - 1 >= 0)
            {
                backPosx = curxPos;
                backPosy = curyPos;
                curxPos -= 1;
                curType = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().getPos(curxPos, curyPos);
                visited = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().visitChk(curxPos, curyPos);
                bool isLastSelected = backPosEqual();
                if (((curType == 0 || curType == pickedType) && visited == 0) || pickedType == -1 || (isLastSelected && visited == pickedType))
                {
                    if (isLastSelected && visited == pickedType && pickedType > -1)
                    {
                        Point prevPoint = footprints.Pop();
                        if (prevPoint.x == curxPos && prevPoint.y == curyPos)
                        {
                            if (curType == pickedType && curType == visited)
                            {
                                stopAudio();
                            }
                            eraseRoute(backPosx, backPosy);
                            transform.position -= movementRightCube;
                            countTurnAndPlayEffect();
                            moveCube(curxPos, curyPos, curType, pickedType, visited);
                        }
                        else
                        {
                            footprints.Push(prevPoint);
                            curxPos += 1;
                            setCurrentXY(curxPos, curyPos);
                        }
                    }
                    else
                    {
                        footprints.Push(new Point(backPosx, backPosy));
                        transform.position -= movementRightCube;
                        countTurnAndPlayEffect();
                        moveCube(curxPos, curyPos, curType, pickedType, visited);
                    }
                }
                else
                {
                    curxPos += 1;
                    setCurrentXY(curxPos, curyPos);
                }

            }
            
        }
        else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (curxPos + 1 < maxPosX)
            {
                backPosx = curxPos;
                backPosy = curyPos;
                curxPos += 1;
                curType = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().getPos(curxPos, curyPos);
                visited = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().visitChk(curxPos, curyPos);
                bool isLastSelected = backPosEqual();
                if (((curType == 0 || curType == pickedType) && visited == 0) || pickedType == -1 || (isLastSelected && visited == pickedType ))
                {
                    if (isLastSelected && visited == pickedType && pickedType > -1)
                    {
                        Point prevPoint = footprints.Pop();
                        if (prevPoint.x == curxPos && prevPoint.y == curyPos)
                        {
                            if (curType == pickedType && curType == visited)
                            {
                                stopAudio();
                            }
                            eraseRoute(backPosx, backPosy);
                            transform.position += movementRightCube;
                            countTurnAndPlayEffect();
                            moveCube(curxPos, curyPos, curType, pickedType, visited);
                        }
                        else
                        {
                            footprints.Push(prevPoint);
                            curxPos -= 1;
                            setCurrentXY(curxPos, curyPos);
                        }
                    }
                    else {
                        footprints.Push(new Point(backPosx, backPosy));
                        transform.position += movementRightCube;
                        countTurnAndPlayEffect();
                        moveCube(curxPos, curyPos, curType, pickedType, visited);
                    }
                }
                else
                {
                    curxPos -= 1;
                    setCurrentXY(curxPos, curyPos);
                }
            }
            
        }
        
    }

    void setCurrentXY(int curxPos, int curyPos) {
        GameObject.Find("Main Camera").GetComponent<MatrixCreate>().setXY(curxPos, curyPos);
    }

    void moveCube(int curxPos, int curyPos, int curType, int pickedType, int visited) {
        setCurrentXY(curxPos, curyPos);
        if (curType > 0 && curType == pickedType)
        {
            GameObject.Find("Main Camera").GetComponent<MatrixCreate>().setGetType(-1);
            connectedNum += 1;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Cube1")
        {
            GameObject.Find("Main Camera").GetComponent<MatrixCreate>().setCurType(1);
        }
        else if (col.gameObject.tag == "Cube2")
        {
            GameObject.Find("Main Camera").GetComponent<MatrixCreate>().setCurType(2);
        }
        else if (col.gameObject.tag == "Cube3")
        {
            GameObject.Find("Main Camera").GetComponent<MatrixCreate>().setCurType(3);
        }
        else if (col.gameObject.tag == "Cube4")
        {
            GameObject.Find("Main Camera").GetComponent<MatrixCreate>().setCurType(4);
        }
        else if (col.gameObject.tag == "Cube5")
        {
            GameObject.Find("Main Camera").GetComponent<MatrixCreate>().setCurType(5);
        }
        else
        {
            GameObject.Find("Main Camera").GetComponent<MatrixCreate>().setCurType(0);
        }

    }

    private void countTurnAndPlayEffect()
    {
        GameObject.Find("FontController").GetComponent<FontController>().CountingTurn();
        GameObject.Find("effectSound").GetComponent<AudioSource>().Play();
    }

    private void eraseRoute(int backPosx, int backPosy)
    {
        GameObject.Find("Main Camera").GetComponent<MatrixCreate>().myRendererSet(backPosx, backPosy);
        GameObject.Find("Main Camera").GetComponent<MatrixCreate>().curPosPop(backPosx, backPosy);
    }

    private void stopAudio()
    {
        GameObject.Find("CubeSound").GetComponent<AudioSource>().Stop();
    }

    public void PickCube()
    {
        CubeType = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().getCurType();

        if (CubeType > 0)
        {
            bool pickTrue = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().chkCompleteCube(CubeType);
            if (!pickTrue)
            {
                footprints = new Stack<Point>();
                GameObject.Find("CubeSound").GetComponent<SoundSetting>().settingSound(CubeType - 1);
                GameObject.Find("CubeSound").GetComponent<AudioSource>().Play();
                GameObject.Find("Main Camera").GetComponent<MatrixCreate>().curPosPush(CubeType);
                GameObject.Find("Main Camera").GetComponent<MatrixCreate>().setGetType(CubeType);
                if (connectedNum >= 4) { 
                    bool isPossible = GameObject.Find("Main Camera").GetComponent<MatrixCreate>().isPossibleLink();
                    if(!isPossible)
                    GameObject.Find("Main Camera").GetComponent<MatrixCreate>().EndScene(4);
                }
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move();

    }
}