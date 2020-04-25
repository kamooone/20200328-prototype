using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particlealpha : MonoBehaviour//α値を消したり増やしたりする
{
    [SerializeField]
    private ParticleSystem.MainModule Main;

    [SerializeField]
    private float A;//アルファ値 
    private float R;//
    private float G;//
    private float B;//

    // Start is called before the first frame update
    void Start()
    {
       Main = GetComponent<ParticleSystem>().main;//パーティクルシステムを初期化
        A = Main.startColor.color.a;
        R = Main.startColor.color.r;
        G = Main.startColor.color.g;
        B = Main.startColor.color.b;
    }

    // Update is called once per frame
    void Update()
    {
        Main.startColor = new Color(R, G, B, A);
        A = A - 0.01f;
        if (A <= -2)//透明になったら戻す
        {
            A = 1.0f;
        }
    }
}
