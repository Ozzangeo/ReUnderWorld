using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
    public Text text;
    public AudioSource audioSource;
    public AudioClip clip;

    void Start()
    {
        audioSource.clip = clip;
        audioSource.Play();

        text.text = $"BEST SCORE : {PlayerPrefs.GetInt(GameDirector.HIGH_SCORE, 0)}Á¡\nSCORE : {PlayerPrefs.GetInt(GameDirector.SCORE, 0)}Á¡";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
