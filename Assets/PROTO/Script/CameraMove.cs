using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMove : MonoBehaviour//カメラ移動処理
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

        //L Stick
        float Left = Input.GetAxis("L");
        float Right = Input.GetAxis("R");


        //プレイヤを軸に回転
        if ((Left > 0 || Input.GetKey("left")) && PlayerScript.Enemy2_Collision_Left == false && PlayerMove.WaterAction == false && GoalDoor.GoalFlag == false)
        {
            Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, PlayerScript.speed * Time.deltaTime);
        }

        if ((Right > 0 || Input.GetKey("right")) && PlayerScript.Enemy2_Collision_Right == false && PlayerMove.WaterAction == false && GoalDoor.GoalFlag == false)
        {
            Vector3 axis = PlayerScript.transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, PlayerScript.speed * Time.deltaTime);
        }
    }
}