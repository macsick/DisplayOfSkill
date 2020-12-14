using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerPrefText : MonoBehaviour
{
    public string name;
    private void Start()
    {
        PlayerPrefs.SetInt("Score",0);
    }
    void Update()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt(name) + "";
    }
}
