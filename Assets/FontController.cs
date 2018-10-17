﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FontController : MonoBehaviour {

	public Text gameTime, gameTurn, gameScore;
	private int turn, score,min,sec;
	private float timeleft;

	// Use this for initialization
	void Start () {
		timeleft = 300f;
		turn = 0;
		score = 0;
		min = 0;
		sec = 0;
		gameTurn.text = string.Format ("TURN"+"\n   "+"0"+"{0:N0}", turn);
		gameScore.text = string.Format ("YOUR SCORE" + "\n           " + "{0:N0}", score);
	}
	
	// Update is called once per frame
	void Update () {
		timeleft -= Time.deltaTime;
		if (timeleft >= 60) {
			min = (int)timeleft / 60;
			sec = (int)timeleft - (min * 60);
		} else if (timeleft <= 0) {
			GameObject.Find ("Main Camera").GetComponent<MatrixCreate> ().PlayerEnd ();
			Time.timeScale = 0;
		} else {
			sec = (int)timeleft;
		}
		gameTime.text=string.Format("TIME LEFT"+"\n    "+"{0:N0} : {1:N0}",min,sec);
		
	}

	public void CountingScore(int point){
		score += point;
		gameScore.text = string.Format ("YOUR SCORE" + "\n        " + "{0:N0}", score);
	}

	public void CountingTurn(){
		turn++;
		if (turn < 10)
			gameTurn.text = string.Format ("TURN"+"\n   "+"0"+"{0:N0}", turn);
		else
			gameTurn.text = string.Format ("TURN"+"\n   "+"{0:N0}", turn);
	}
}