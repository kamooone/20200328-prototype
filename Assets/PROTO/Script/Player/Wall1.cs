﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall1 : MonoBehaviour
{
    public Transform target;//中心となるオブジェクト

    public static bool wallcollision1 = false;
    // Start is called before the first frame update
    void Start()
    {
        wallcollision1 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //L Stick
        float Left = Input.GetAxis("L");
        float Right = Input.GetAxis("R");

        //左に移動  
        if ((Left > 0 || Input.GetKey("left")) && PlayerMove.Wall_Move1 == true && PlayerMove.PlayerDirection == 1 && PlayerMove.WallNo1 == true && wallcollision1 == false)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
        }

        //右に移動
        if ((Right > 0 || Input.GetKey("right")) && PlayerMove.Wall_Move1 == true && PlayerMove.PlayerDirection == -1 && PlayerMove.WallNo1 == true && wallcollision1 == false)
        {
            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "MoveWall" || collision.gameObject.tag == "MoveWall1" || collision.gameObject.tag == "MoveWall2" || collision.gameObject.tag == "MoveWall3"
            || collision.gameObject.tag == "MoveWall4" || collision.gameObject.tag == "MoveWall5" || collision.gameObject.tag == "MoveWall6" || collision.gameObject.tag == "MoveWall7"
             || collision.gameObject.tag == "MoveWall8" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Wall")
        {
            wallcollision1 = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        wallcollision1 = false;
    }
}
