using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayBGM : MonoBehaviour
{
    [SerializeField] AudioClip m_Clip;
    [SerializeField] private AudioSource m_AudioSource;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource.clip = m_Clip;
        m_AudioSource.Play();
        m_AudioSource.loop = true;
    }
}
