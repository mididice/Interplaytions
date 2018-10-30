using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSetting : MonoBehaviour {

    public AudioClip[] Sounds;
    private AudioSource myAudio;
	// Use this for initialization
	void Start () {
        myAudio = GetComponent<AudioSource>();
        myAudio.loop = true;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void settingSound(int idx)
    {
        myAudio.clip = Sounds[idx];

    }
}
