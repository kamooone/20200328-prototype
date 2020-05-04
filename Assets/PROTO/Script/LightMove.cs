﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightMove : MonoBehaviour//カメラ移動処理
{
    GameObject PlayerObject;
    PlayerMove PlayerScript;

    GameObject Camera;

    public Transform target;//中心となるオブジェクト

    // Use this for initialization
    void Start()
    {
        PlayerObject = GameObject.Find("player");
        PlayerScript = PlayerObject.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, PlayerScript.transform.position.y, transform.position.z);

        //プレイヤを軸に回転
        if (Input.GetKey("left") && PlayerScript.Enemy2_Collision_Left == false)
        {
            Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, PlayerScript.speed * Time.deltaTime);
        }

        if (Input.GetKey("right") && PlayerScript.Enemy2_Collision_Right == false)
        {
            Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, PlayerScript.speed * Time.deltaTime);
        }
    }
}