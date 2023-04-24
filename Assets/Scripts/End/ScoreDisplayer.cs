using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
    public Text text;

    void Start()
    {
        text.text = $"BEST SCORE : {PlayerPrefs.GetInt(GameDirector.HIGH_SCORE, 0)}Á¡\nSCORE : {PlayerPrefs.GetInt(GameDirector.SCORE, 0)}Á¡";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
