using System;
using System.Collections;
using System.Net;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Runtime.InteropServices;

public class midPlayer : MonoBehaviour {

    int Sequence;
    private int cubeIdx;
    string Url;
    string CombineUrl;
    private string[] files = { "C:\\Users\\user\\Desktop\\interplaytion_server\\mididice-python\\midibasic\\1.mid", "C:\\Users\\user\\Desktop\\interplaytion_server\\mididice-python\\midibasic\\2.mid",
        "C:\\Users\\user\\Desktop\\interplaytion_server\\mididice-python\\midibasic\\3.mid",
        "C:\\Users\\user\\Desktop\\interplaytion_server\\mididice-python\\midibasic\\4.mid",
        "C:\\Users\\user\\Desktop\\interplaytion_server\\mididice-python\\midibasic\\5.mid",
        "C:\\Users\\user\\Desktop\\interplaytion_server\\mididice-python\\midibasic\\6.mid",
        "C:\\Users\\user\\Desktop\\interplaytion_server\\mididice-python\\midibasic\\7.mid",
        "C:\\Users\\user\\Desktop\\interplaytion_server\\mididice-python\\midibasic\\8.mid",
        "C:\\Users\\user\\Desktop\\interplaytion_server\\mididice-python\\midibasic\\9.mid",
        "C:\\Users\\user\\Desktop\\interplaytion_server\\mididice-python\\midibasic\\10.mid",
        "C:\\Users\\user\\Desktop\\interplaytion_server\\mididice-python\\midibasic\\11.mid",
        "C:\\Users\\user\\Desktop\\interplaytion_server\\mididice-python\\midibasic\\12.mid"};

    void Start()
    {
        cubeIdx = 0;
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
        cubeIdx = cubeIndex;
        _PlusSequence();
        string url = "http://localhost:8000/api/v2/midi/" + this.Sequence + "/" + cubeIndex + "/";
        this.Url = url;
        string filpath=GetMidiFile();
        GameObject.Find("MidiFileChecking").GetComponent<testmid>().SetsFile(filpath);
    }
    //생성된 url에 요청을 보낸 후, 미디파일받아온다.
    public string GetMidiFile()
    {
        
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(this.Url);

        req.Method = "POST";
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        StreamReader sr = new StreamReader(resp.GetResponseStream());
        String filePath = sr.ReadToEnd();
        return filePath;

    }
    public string GetCombineFile()
    {
        
        HttpWebRequest req = (HttpWebRequest)WebRequest.Create(this.CombineUrl);

        req.Method = "POST";
        HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
        StreamReader sr = new StreamReader(resp.GetResponseStream());
        String filePath = sr.ReadToEnd();
        return filePath;

    }
}
