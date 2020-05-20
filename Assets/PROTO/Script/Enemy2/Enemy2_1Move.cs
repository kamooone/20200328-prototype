using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2_1Move : MonoBehaviour//敵の移動処理(本来はまとめてやる)
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

    
    public static bool hasigocollision = false;
    public static bool hasigocollision1 = false;
    public static bool hasigocollision2 = false;
    public static bool hasigocollision3 = false;
    public static bool hasigocollision4 = false;
    public static bool hasigocollision5 = false;
    public static bool hasigocollision6 = false;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.Find("player");
        PlayerScript = PlayerObject.GetComponent<PlayerMove>();

        hasigocollision = false;
        hasigocollision1 = false;
        hasigocollision2 = false;
        hasigocollision3 = false;
        hasigocollision4 = false;
        hasigocollision5 = false;
        hasigocollision6 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //一階の水の高さ取得
        WaterHight = PlayerScript.WaterHight1;

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
        if (collision.gameObject.tag == "StageUp" || collision.gameObject.tag == "Up")
        {
            hasigocollision = true;
        }
        if (collision.gameObject.tag == "StageUp_1" || collision.gameObject.tag == "Up_1")
        {
            hasigocollision1 = true;
        }
        if (collision.gameObject.tag == "StageUp_2" || collision.gameObject.tag == "Up_2")
        {
            hasigocollision2 = true;
        }
        if (collision.gameObject.tag == "StageUp_3" || collision.gameObject.tag == "Up_3")
        {
            hasigocollision3 = true;
        }
        if (collision.gameObject.tag == "StageUp_4" || collision.gameObject.tag == "Up_4")
        {
            hasigocollision4 = true;
        }
        if (collision.gameObject.tag == "StageUp_5" || collision.gameObject.tag == "Up_5")
        {
            hasigocollision5 = true;
        }
        if (collision.gameObject.tag == "StageUp_6" || collision.gameObject.tag == "Up_6")
        {
            hasigocollision6 = true;
        }
    }


    //ノット当たり判定トリガー
    void OnTriggerExit(Collider collision)
    {
        hasigocollision = false;
        hasigocollision1 = false;
        hasigocollision2 = false;
        hasigocollision3 = false;
        hasigocollision4 = false;
        hasigocollision5 = false;
        hasigocollision6 = false;
    }

    void OnCollisionEnter(Collision collision)
    {
        //水がある時だけ判定
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
