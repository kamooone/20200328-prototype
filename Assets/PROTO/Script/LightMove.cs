using System.Collections;
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

        PlayerMove.GameOverFlag = false;
    }

    // Update is called once per frame
    void Update()
    {

        //L Stick
        float Left = Input.GetAxis("L");
        float Right = Input.GetAxis("R");


        transform.position = new Vector3(transform.position.x, PlayerScript.transform.position.y, transform.position.z);

        if (PlayerMove.GameOverFlag == false)
        {
            //プレイヤを軸に回転
            if ((Left > 0 || Input.GetKey("left")) && PlayerScript.Enemy2_Collision_Left == false && PlayerMove.WaterAction == false && GoalDoor.GoalFlag == false && PlayerMove.Wall_Move0 == false
             && PlayerMove.Wall_Move1 == false && PlayerMove.Wall_Move2 == false && PlayerMove.Wall_Move3 == false && PlayerMove.Wall_Move4 == false && PlayerMove.Wall_Move5 == false
              && PlayerMove.Wall_Move6 == false && PlayerMove.Wall_Move7 == false && PlayerMove.Wall_Move8 == false)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.up);
                transform.RotateAround(target.position, axis, PlayerScript.speed * Time.deltaTime);
            }

            if ((Right > 0 || Input.GetKey("right")) && PlayerScript.Enemy2_Collision_Right == false && PlayerMove.WaterAction == false && GoalDoor.GoalFlag == false && PlayerMove.Wall_Move0 == false
                 && PlayerMove.Wall_Move1 == false && PlayerMove.Wall_Move2 == false && PlayerMove.Wall_Move3 == false && PlayerMove.Wall_Move4 == false && PlayerMove.Wall_Move5 == false
                  && PlayerMove.Wall_Move6 == false && PlayerMove.Wall_Move7 == false && PlayerMove.Wall_Move8 == false)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.down);
                transform.RotateAround(target.position, axis, PlayerScript.speed * Time.deltaTime);
            }





            //左に移動  
            if ((Left > 0 || Input.GetKey("left")) && PlayerMove.Wall_Move0 == true && PlayerMove.PlayerDirection == 1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.up);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }

            //右に移動
            if ((Right > 0 || Input.GetKey("right")) && PlayerMove.Wall_Move0 == true && PlayerMove.PlayerDirection == -1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.down);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }


            //左に移動  
            if ((Left > 0 || Input.GetKey("left")) && PlayerMove.Wall_Move1 == true && PlayerMove.PlayerDirection == 1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.up);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }

            //右に移動
            if ((Right > 0 || Input.GetKey("right")) && PlayerMove.Wall_Move1 == true && PlayerMove.PlayerDirection == -1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.down);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }


            //左に移動  
            if ((Left > 0 || Input.GetKey("left")) && PlayerMove.Wall_Move2 == true && PlayerMove.PlayerDirection == 1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.up);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }

            //右に移動
            if ((Right > 0 || Input.GetKey("right")) && PlayerMove.Wall_Move2 == true && PlayerMove.PlayerDirection == -1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.down);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }


            //左に移動  
            if ((Left > 0 || Input.GetKey("left")) && PlayerMove.Wall_Move3 == true && PlayerMove.PlayerDirection == 1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.up);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }

            //右に移動
            if ((Right > 0 || Input.GetKey("right")) && PlayerMove.Wall_Move3 == true && PlayerMove.PlayerDirection == -1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.down);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }



            //左に移動  
            if ((Left > 0 || Input.GetKey("left")) && PlayerMove.Wall_Move4 == true && PlayerMove.PlayerDirection == 1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.up);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }
            //右に移動
            if ((Right > 0 || Input.GetKey("right")) && PlayerMove.Wall_Move4 == true && PlayerMove.PlayerDirection == -1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.down);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }



            //左に移動  
            if ((Left > 0 || Input.GetKey("left")) && PlayerMove.Wall_Move5 == true && PlayerMove.PlayerDirection == 1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.up);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }
            //右に移動
            if ((Right > 0 || Input.GetKey("right")) && PlayerMove.Wall_Move5 == true && PlayerMove.PlayerDirection == -1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.down);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }


            //左に移動  
            if ((Left > 0 || Input.GetKey("left")) && PlayerMove.Wall_Move6 == true && PlayerMove.PlayerDirection == 1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.up);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }
            //右に移動
            if ((Right > 0 || Input.GetKey("right")) && PlayerMove.Wall_Move6 == true && PlayerMove.PlayerDirection == -1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.down);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }


            //左に移動  
            if ((Left > 0 || Input.GetKey("left")) && PlayerMove.Wall_Move7 == true && PlayerMove.PlayerDirection == 1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.up);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }
            //右に移動
            if ((Right > 0 || Input.GetKey("right")) && PlayerMove.Wall_Move7 == true && PlayerMove.PlayerDirection == -1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.down);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }


            //左に移動  
            if ((Left > 0 || Input.GetKey("left")) && PlayerMove.Wall_Move8 == true && PlayerMove.PlayerDirection == 1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.up);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }
            //右に移動
            if ((Right > 0 || Input.GetKey("right")) && PlayerMove.Wall_Move8 == true && PlayerMove.PlayerDirection == -1)
            {
                Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.down);
                transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
            }
        }
    }
}