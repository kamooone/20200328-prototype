﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMVolume : MonoBehaviour
{

    AudioSource m_AudioSource;
    
    
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Debug.Log(BGM.volume);
        m_AudioSource.volume = BGM.volume;
    }
}