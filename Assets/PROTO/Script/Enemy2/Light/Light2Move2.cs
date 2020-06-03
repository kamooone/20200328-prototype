using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Light2Move2 : MonoBehaviour//カメラ移動処理
{
    public GameObject Enemy2_3;
    Enemy2_3Move Enemy2_3Script;

    float speed = 7.0f;

    public Transform target;//中心となるオブジェクト

    // Use this for initialization
    void Start()
    {
        Enemy2_3Script = Enemy2_3.GetComponent<Enemy2_3Move>();

        speed = 6.0f;
        Enemy2_3Move.WaterHight = 0.0f;
        Enemy2_3Move.walkFlag_Right = false;
        Enemy2_3Move.walkFlag_Left = false;
        Enemy2_3Move.TuiFlag = false;
        Enemy2_3Move.doorcollision = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Enemy2_3Move.walkflag == true)
        {
            if (Enemy2_3Move.TuiFlag == false)
            {
                /*移動処理*/
                if (Enemy2_3Move.direction == 1)
                {
                    Vector3 axis = Enemy2_3Script.transform.TransformDirection(Vector3.up);
                    transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                }

                if (Enemy2_3Move.direction == -1)
                {
                    Vector3 axis = Enemy2_3Script.transform.TransformDirection(Vector3.down);
                    transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                }
            }

            if (Enemy2_3Move.TuiFlag == true && Enemy2_3Move.doorcollision == false)
            {
                /*移動処理*/
                if (Enemy2_3Move.walkFlag_Right == true)
                {
                    Vector3 axis = Enemy2_3Script.transform.TransformDirection(Vector3.down);
                    transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                }

                if (Enemy2_3Move.walkFlag_Left == true)
                {
                    Vector3 axis = Enemy2_3Script.transform.TransformDirection(Vector3.up);
                    transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                }
            }
        }
    }
}