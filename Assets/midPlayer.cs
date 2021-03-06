﻿using System;
using System.Collections;
using System.Net;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Runtime.InteropServices;

public class midPlayer : MonoBehaviour {

    int Sequence;
    string Url;
    string CombineUrl;

    void Start()
    {
        this.Sequence = 0;
        this.CombineUrl = "http://localhost:8000/api/v2/midi/combine/";
    }

    // Update is called once per frame
    void Update()
    {

    }
    //요청순서
    private void _PlusSequence()
    {
        this.Sequence++;
    }
    //url생성하고
    public void GenerateUrl(int cubeIndex)
    {
        _PlusSequence();
        string url = "http://localhost:8000/api/v2/midi/" + this.Sequence + "/" + cubeIndex + "/";
        this.Url = url;
        string filpath=GetMidiFile();
        GameObject.Find("MidiFileChecking").GetComponent<testmid>().SetsFile(filpath);
    }
    //생성된 url에 요청을 보낸 후, 미디파일받아온다.
    public string GetMidiFile()
    {
        try{
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(this.Url);

            req.Method = "POST";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            String filePath = sr.ReadToEnd();
            return filePath;
        }catch (WebException ex) { 
            WebResponse errorResponse = (WebResponse)ex.Response;
            return "";
        }
        

    }
    public string GetCombineFile()
    {
        try{
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(this.CombineUrl);

            req.Method = "POST";
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            StreamReader sr = new StreamReader(resp.GetResponseStream());
            String filePath = sr.ReadToEnd();
            return filePath;
        } catch (WebException ex) {
            WebResponse errorResponse = (WebResponse)ex.Response;
            return "";
        }
    }
}
