using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy2_3Move : MonoBehaviour//敵の移動処理(本来はまとめてやる)
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

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.Find("player");
        PlayerScript = PlayerObject.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        //三階の水の高さ取得
        WaterHight = PlayerScript.WaterHight3;

        //水の判定
        if (WaterHight == 0.1f)
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

    //当たり判定トリガー
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Flip")
        {
            direction *= -1;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && WaterHight == 0.1f)
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
