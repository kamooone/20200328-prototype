using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Light2Move0 : MonoBehaviour//カメラ移動処理
{
    public GameObject Enemy2_1;
    Enemy2_1Move Enemy2_1Script;

    float speed = 7.0f;

    public Transform target;//中心となるオブジェクト

    // Use this for initialization
    void Start()
    {
        Enemy2_1Script = Enemy2_1.GetComponent<Enemy2_1Move>();

        speed = 6.0f;
        Enemy2_1Move.WaterHight = 0.0f;
        Enemy2_1Move.walkFlag_Right = false;
        Enemy2_1Move.walkFlag_Left = false;
        Enemy2_1Move.TuiFlag = false;
        Enemy2_1Move.doorcollision = false;
        PlayerMove.GameClearFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.GameClearFlag == false)
        {
            if (Enemy2_1Move.walkflag == true)
            {
                if (Enemy2_1Move.TuiFlag == false)
                {
                    /*移動処理*/
                    if (Enemy2_1Move.direction == 1)
                    {
                        Vector3 axis = Enemy2_1Script.transform.TransformDirection(Vector3.up);
                        transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                    }

                    if (Enemy2_1Move.direction == -1)
                    {
                        Vector3 axis = Enemy2_1Script.transform.TransformDirection(Vector3.down);
                        transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                    }
                }

                if (Enemy2_1Move.TuiFlag == true && Enemy2_1Move.doorcollision == false)
                {
                    /*移動処理*/
                    if (Enemy2_1Move.walkFlag_Right == true)
                    {
                        Vector3 axis = Enemy2_1Script.transform.TransformDirection(Vector3.down);
                        transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                    }

                    if (Enemy2_1Move.walkFlag_Left == true)
                    {
                        Vector3 axis = Enemy2_1Script.transform.TransformDirection(Vector3.up);
                        transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                    }
                }
            }
        }
    }
}