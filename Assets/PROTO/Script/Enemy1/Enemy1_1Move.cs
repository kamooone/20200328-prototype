using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy1_1Move : MonoBehaviour
{
    public Transform target;

    GameObject Enemy;

    float speed = 10.0f;

    //エネミーの向き
    int direction = 1;

    //方向チェンジ時の角度
    float radian = 180.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("GameOverScene");
        }

        if (collision.gameObject.tag == "Enemy2")
        {
            gameObject.SetActive(false);
        }
    }

}




