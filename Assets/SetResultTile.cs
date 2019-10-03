using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SetResultTile : MonoBehaviour
{
    private string result;
    public Sprite[] BlackSprite;

    void Start()
    {
        result = PlayerPrefs.GetString("resultTiles");
        string[] tiles = result.Split('|');        
        for (int i = 1; i < tiles.Length-1; i++) {
            string typeName = "BottomTile" + i.ToString();
            GameObject.Find(typeName).GetComponent<Image>().sprite = BlackSprite[Convert.ToInt32(tiles[i])];

        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
