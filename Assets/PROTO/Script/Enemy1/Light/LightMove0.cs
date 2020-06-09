using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LightMove0 : MonoBehaviour//カメラ移動処理
{
    public GameObject Enemy1;
    Enemy1Move Enemy1Script;

    float speed = 6.0f;

    public Transform target;//中心となるオブジェクト

    // Use this for initialization
    void Start()
    {
        Enemy1Script = Enemy1.GetComponent<Enemy1Move>();

        speed = 6.0f;
        FireGenerated1.WaterHight = 0.0f;
        Enemy1Move.walkFlag_Right = false;
        Enemy1Move.walkFlag_Left = false;
        Enemy1Move.TuiFlag = false;
        Enemy1Move.doorcollision = false;
        PlayerMove.GameClearFlag = false;
        PlayerMove.WaterAction = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.GameClearFlag == false && PlayerMove.WaterAction == false)
        {
            if (Enemy1Move.TuiFlag == true && Enemy1Move.doorcollision == false)
            {
                //==============================================================================================================
                //水ないとき、追従時のエネミーのスピード
                if (FireGenerated1.WaterHight == 0.0f || FireGenerated1.WaterHight == -0.11f)
                {
                    speed = 10.0f;
                }


                //水あるとき、追従時のエネミーのスピード
                if (FireGenerated1.WaterHight == 0.11f)
                {
                    speed = 6.0f;

                }
                //==============================================================================================================

                if (Enemy1Move.walkFlag_Right == true)
                {

                    Vector3 axis = Enemy1Script.transform.TransformDirection(Vector3.down);
                    transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                }

                if (Enemy1Move.walkFlag_Left == true)
                {

                    Vector3 axis = Enemy1Script.transform.TransformDirection(Vector3.up);
                    transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                }
            }

            if (Enemy1Move.TuiFlag == false)
            {


                //==============================================================================================================
                //水ないとき、普通時のエネミーのスピード
                if (FireGenerated1.WaterHight == 0.0f || FireGenerated1.WaterHight == -0.11f)
                {
                    speed = 6.0f;
                }


                //水あるとき、普通時のエネミーのスピード
                if (FireGenerated1.WaterHight == 0.11f)
                {
                    speed = 2.0f;
                }
                //==============================================================================================================


                if (Enemy1Move.direction == -1)
                {
                    Vector3 axis = Enemy1Script.transform.TransformDirection(Vector3.down);
                    transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                }

                if (Enemy1Move.direction == 1)
                {
                    Vector3 axis = Enemy1Script.transform.TransformDirection(Vector3.up);
                    transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                }
            }
        }
    }
}