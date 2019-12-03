using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartBtn : MonoBehaviour {

    public Sprite[] btnSprite;
    private bool restartBtn;
    // Use this for initialization
    void Start () {
        restartBtn = true ;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.GetComponent<Image>().sprite = btnSprite[0];
            restartBtn = true;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.GetComponent<Image>().sprite = btnSprite[1];
            restartBtn = false;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            if (restartBtn)
            {
                SceneManager.LoadScene("startScene");
            }
        }
    }
}
