using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightMove2 : MonoBehaviour//カメラ移動処理
{
    public GameObject Enemy3;
    Enemy3Move Enemy3Script;

    float speed = 6.0f;

    public Transform target;//中心となるオブジェクト

    // Use this for initialization
    void Start()
    {
        Enemy3Script = Enemy3.GetComponent<Enemy3Move>();

        speed = 6.0f;
        FireGenerated3.WaterHight = 0.0f;
        Enemy3Move.walkFlag_Right = false;
        Enemy3Move.walkFlag_Left = false;
        Enemy3Move.TuiFlag = false;
        Enemy3Move.doorcollision = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Enemy3Move.TuiFlag == true && Enemy3Move.doorcollision == false)
        {
            //==============================================================================================================
            //水ないとき、追従時のエネミーのスピード
            if (FireGenerated3.WaterHight == 0.0f || FireGenerated3.WaterHight == -0.11f)
            {
                speed = 10.0f;
            }


            //水あるとき、追従時のエネミーのスピード
            if (FireGenerated3.WaterHight == 0.11f)
            {
                speed = 6.0f;

            }
            //==============================================================================================================

            if (Enemy3Move.walkFlag_Right == true)
            {

                Vector3 axis = Enemy3Script.transform.TransformDirection(Vector3.down);
                transform.RotateAround(target.position, axis, speed * Time.deltaTime);
            }

            if (Enemy3Move.walkFlag_Left == true)
            {

                Vector3 axis = Enemy3Script.transform.TransformDirection(Vector3.up);
                transform.RotateAround(target.position, axis, speed * Time.deltaTime);
            }
        }

        if (Enemy3Move.TuiFlag == false)
        {


            //==============================================================================================================
            //水ないとき、普通時のエネミーのスピード
            if (FireGenerated3.WaterHight == 0.0f || FireGenerated3.WaterHight == -0.11f)
            {
                speed = 6.0f;
            }


            //水あるとき、普通時のエネミーのスピード
            if (FireGenerated3.WaterHight == 0.11f)
            {
                speed = 2.0f;
            }
            //==============================================================================================================


            if (Enemy3Move.direction == -1)
            {
                Vector3 axis = Enemy3Script.transform.TransformDirection(Vector3.down);
                transform.RotateAround(target.position, axis, speed * Time.deltaTime);
            }

            if (Enemy3Move.direction == 1)
            {
                Vector3 axis = Enemy3Script.transform.TransformDirection(Vector3.up);
                transform.RotateAround(target.position, axis, speed * Time.deltaTime);
            }
        }
    }
}