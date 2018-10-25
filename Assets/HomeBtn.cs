using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HomeBtn : MonoBehaviour {

    public Sprite[] btnSprite;
    private bool Homebtn;
    // Use this for initialization
    void Start () {
        Homebtn = false ;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void LateUpdate()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            gameObject.GetComponent<Image>().sprite = btnSprite[0];
            Homebtn = false;
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.GetComponent<Image>().sprite = btnSprite[1];
            Homebtn = true;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            if (Homebtn) SceneManager.LoadScene("startScene");
        }
    }
}
