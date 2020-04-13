using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{

    AudioSource m_AudioSource;

    public Slider m_Slider;
    
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        m_AudioSource.volume = m_Slider.GetComponent<Slider>().normalizedValue;
    }
}