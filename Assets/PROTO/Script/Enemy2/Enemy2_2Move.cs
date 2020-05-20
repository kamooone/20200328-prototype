using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2_2Move : MonoBehaviour//敵の移動処理(本来はまとめてやる)
{
    GameObject PlayerObject;
    PlayerMove PlayerScript;

    public Transform target;

    float speed = 7.0f;

    //エネミーの向き(1が左-1が右)
    int direction = -1;

    //方向チェンジ時の角度
    float radian = -180.0f;

    //各層の水の高さ取得
    float WaterHight;

    public static bool hasigocollisionUp = false;
    public static bool hasigocollisionDown = false;

    public static bool hasigocollisionUp1 = false;
    public static bool hasigocollisionDown1 = false;

    public static bool hasigocollisionUp2 = false;
    public static bool hasigocollisionDown2 = false;

    public static bool hasigocollisionUp3 = false;
    public static bool hasigocollisionDown3 = false;

    public static bool hasigocollisionUp4 = false;
    public static bool hasigocollisionDown4 = false;

    public static bool hasigocollisionUp5 = false;
    public static bool hasigocollisionDown5 = false;

    public static bool hasigocollisionUp6 = false;
    public static bool hasigocollisionDown6 = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.Find("player");
        PlayerScript = PlayerObject.GetComponent<PlayerMove>();

        hasigocollisionUp = false;
        hasigocollisionUp1 = false;
        hasigocollisionUp2 = false;
        hasigocollisionUp3 = false;
        hasigocollisionUp4 = false;
        hasigocollisionUp5 = false;
        hasigocollisionUp6 = false;

        hasigocollisionDown = false;
        hasigocollisionDown1 = false;
        hasigocollisionDown2 = false;
        hasigocollisionDown3 = false;
        hasigocollisionDown4 = false;
        hasigocollisionDown5 = false;
        hasigocollisionDown6 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //二階の水の高さ取得
        WaterHight = PlayerScript.WaterHight2;

        //水の判定
        if (WaterHight == 0.11f)
        {
            /*移動処理*/
            if (direction == 1)
            {
                if (radian != 180.0f)
                {
                    radian = 180.0f;
                    transform.Rotate(new Vector3(0f, radian, 0f));
                }

                Vector3 axis = transform.TransformDirection(Vector3.up);
                transform.RotateAround(target.position, axis, speed * Time.deltaTime);
            }

            if (direction == -1)
            {
                if (radian != -180.0f)
                {
                    radian = -180.0f;
                    transform.Rotate(new Vector3(0f, radian, 0f));
                }

                Vector3 axis = transform.TransformDirection(Vector3.down);
                transform.RotateAround(target.position, axis, speed * Time.deltaTime);
            }
        }
    }

    //当たり判定当たっている間
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "StageUp1" || collision.gameObject.tag == "Up1")
        {
            hasigocollisionUp = true;
        }
        if (collision.gameObject.tag == "StageUp1_1" || collision.gameObject.tag == "Up1_1")
        {
            hasigocollisionUp1 = true;
        }
        if (collision.gameObject.tag == "StageUp1_2" || collision.gameObject.tag == "Up1_2")
        {
            hasigocollisionUp2 = true;
        }
        if (collision.gameObject.tag == "StageUp1_3" || collision.gameObject.tag == "Up1_3")
        {
            hasigocollisionUp3 = true;
        }
        if (collision.gameObject.tag == "StageUp1_4" || collision.gameObject.tag == "Up1_4")
        {
            hasigocollisionUp4 = true;
        }
        if (collision.gameObject.tag == "StageUp1_5" || collision.gameObject.tag == "Up1_5")
        {
            hasigocollisionUp5 = true;
        }
        if (collision.gameObject.tag == "StageUp1_6" || collision.gameObject.tag == "Up1_6")
        {
            hasigocollisionUp6 = true;
        }




        if (collision.gameObject.tag == "StageDown1" || collision.gameObject.tag == "Down1")
        {
            hasigocollisionDown = true;
        }
        if (collision.gameObject.tag == "StageDown1_1" || collision.gameObject.tag == "Down1_1")
        {
            hasigocollisionDown1 = true;
        }
        if (collision.gameObject.tag == "StageDown1_2" || collision.gameObject.tag == "Down1_2")
        {
            hasigocollisionDown2 = true;
        }
        if (collision.gameObject.tag == "StageDown1_3" || collision.gameObject.tag == "Down1_3")
        {
            hasigocollisionDown3 = true;
        }
        if (collision.gameObject.tag == "StageDown1_4" || collision.gameObject.tag == "Down1_4")
        {
            hasigocollisionDown4 = true;
        }
        if (collision.gameObject.tag == "StageDown1_5" || collision.gameObject.tag == "Down1_5")
        {
            hasigocollisionDown5 = true;
        }
        if (collision.gameObject.tag == "StageDown1_6" || collision.gameObject.tag == "Down1_6")
        {
            hasigocollisionDown6 = true;
        }

    }

    //ノット当たり判定トリガー
    void OnTriggerExit(Collider collision)
    {
        hasigocollisionUp = false;
        hasigocollisionUp1 = false;
        hasigocollisionUp2 = false;
        hasigocollisionUp3 = false;
        hasigocollisionUp4 = false;
        hasigocollisionUp5 = false;
        hasigocollisionUp6 = false;

        hasigocollisionDown = false;
        hasigocollisionDown1 = false;
        hasigocollisionDown2 = false;
        hasigocollisionDown3 = false;
        hasigocollisionDown4 = false;
        hasigocollisionDown5 = false;
        hasigocollisionDown6 = false;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && WaterHight == 0.11f)
        {
            SceneManager.LoadScene("GameOverScene");
        }

        if (collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Enemy" && WaterHight == 0.11f)
        {
            direction *= -1;
        }

        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Door" && WaterHight == 0.11f)
        {
            direction *= -1;
        }
    }
}
