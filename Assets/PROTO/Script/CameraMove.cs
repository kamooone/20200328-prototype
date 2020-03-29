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
        //プレイヤを軸に回転
        if (Input.GetKey("left"))
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, PlayerScript.speed * Time.deltaTime);
        }

        if (Input.GetKey("right"))
        {
            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, PlayerScript.speed * Time.deltaTime);
        }
    }
}