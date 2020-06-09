using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightMove1 : MonoBehaviour//カメラ移動処理
{
    public GameObject Enemy2;
    Enemy2Move Enemy2Script;

    float speed = 6.0f;

    public Transform target;//中心となるオブジェクト

    // Use this for initialization
    void Start()
    {
        Enemy2Script = Enemy2.GetComponent<Enemy2Move>();

        speed = 6.0f;
        FireGenerated2.WaterHight = 0.0f;
        Enemy2Move.walkFlag_Right = false;
        Enemy2Move.walkFlag_Left = false;
        Enemy2Move.TuiFlag = false;
        Enemy2Move.doorcollision = false;
        PlayerMove.GameClearFlag = false;
        PlayerMove.WaterAction = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.GameClearFlag == false && PlayerMove.WaterAction == false)
        {
            if (Enemy2Move.TuiFlag == true && Enemy2Move.doorcollision == false)
            {
                //==============================================================================================================
                //水ないとき、追従時のエネミーのスピード
                if (FireGenerated2.WaterHight == 0.0f || FireGenerated2.WaterHight == -0.11f)
                {
                    speed = 10.0f;
                }


                //水あるとき、追従時のエネミーのスピード
                if (FireGenerated2.WaterHight == 0.11f)
                {
                    speed = 6.0f;

                }
                //==============================================================================================================

                if (Enemy2Move.walkFlag_Right == true)
                {

                    Vector3 axis = Enemy2Script.transform.TransformDirection(Vector3.down);
                    transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                }

                if (Enemy2Move.walkFlag_Left == true)
                {

                    Vector3 axis = Enemy2Script.transform.TransformDirection(Vector3.up);
                    transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                }
            }

            if (Enemy2Move.TuiFlag == false)
            {


                //==============================================================================================================
                //水ないとき、普通時のエネミーのスピード
                if (FireGenerated2.WaterHight == 0.0f || FireGenerated2.WaterHight == -0.11f)
                {
                    speed = 6.0f;
                }


                //水あるとき、普通時のエネミーのスピード
                if (FireGenerated2.WaterHight == 0.11f)
                {
                    speed = 2.0f;
                }
                //==============================================================================================================


                if (Enemy2Move.direction == -1)
                {
                    Vector3 axis = Enemy2Script.transform.TransformDirection(Vector3.down);
                    transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                }

                if (Enemy2Move.direction == 1)
                {
                    Vector3 axis = Enemy2Script.transform.TransformDirection(Vector3.up);
                    transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                }
            }
        }
    }
}