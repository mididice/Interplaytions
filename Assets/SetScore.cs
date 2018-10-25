using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetScore : MonoBehaviour {

    public Text ScoreTxt;
    private int score;
    private string numlen;
	// Use this for initialization
	void Start () {
        score = PlayerPrefs.GetInt("Score");
        string t = score.ToString();
        if (t.Length <= 3)
        {
            for (int i = 0; i < 4 - t.Length; i++) numlen += " ";
        }
        
        ScoreTxt.text= string.Format(numlen+ "{0:N0}", score);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
