﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button2 : MonoBehaviour
{
    GameObject PlayerObject;
    PlayerMove PlayerScript;

    //水の高さ取得
    float WaterHight;

    float rotate = -1f;

    /*パーティクル追加*/
    [SerializeField]
    private ParticleSystem particle;//スプリンクラー

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.Find("player");
        PlayerScript = PlayerObject.GetComponent<PlayerMove>();

        /*パーティクル*/
        particle.gameObject.SetActive(false);//非表示にする

        rotate = -1f;
    }

    // Update is called once per frame
    void Update()
    {
        //二階の水の高さ取得
        WaterHight = PlayerScript.WaterHight2;

        if (WaterHight == 0.0f || WaterHight == -0.11f)
        {
            rotate = 1f;

            /*パーティクル*/
            particle.gameObject.SetActive(true);//表示にする
            particle.Play();
        }
        if (WaterHight == 0.11f)
        {
            rotate = -1f;
        }


        if (PlayerMove.StageNow == 2 && PlayerMove.WaterAction == true)
        {
            transform.Rotate(new Vector3(rotate, 0f, 0f));
        }
    }
}
