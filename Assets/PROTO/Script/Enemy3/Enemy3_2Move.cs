﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy3_2Move : MonoBehaviour
{
    public Transform target;

    GameObject Enemy;

    //float speed = 10.0f;

    float Down = 0.0f;

    //エネミーの向き
    int direction = 1;

    //方向チェンジ時の角度
    float radian = 180.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*移動処理*/
        if (direction == 1)
        {
            /*
            if (radian != 180.0f)
            {
                radian = 180.0f;
                transform.Rotate(new Vector3(0f, radian, 0f));
            }*/

            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, FireGenerated2.speed * Time.deltaTime);
        }

        /*
        if (direction == -1)
        {
            if (radian != -180.0f)
            {
                radian = -180.0f;
                transform.Rotate(new Vector3(0f, radian, 0f));
            }

            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, FireGenerated2.speed * Time.deltaTime);
        }
        */
    }

    //当たり判定トリガー
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Flip")
        {
            direction *= -1;
        }
    }


    //当たり判定当たっている間
    void OnTriggerStay(Collider collision)
    {
        //if (collision.gameObject.tag == "Fall")
        //{
        //    Debug.Log("階層ダウン");
        //
        //    transform.position = new Vector3(transform.position.x, transform.position.y + Down, transform.position.z);
        //
        //    Down -= 0.01f; 
        //    
        //}
    }


    /*
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("ゲームオーバー");
            SceneManager.LoadScene("GameOverScene");
        }

        
        if (collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Enemy")
        {
            direction *= -1;
        }

        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Door")
        {
            direction *= -1;
        }
        
    }*/

}




