using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    public float speed = 10.0f;

    public Transform target;//中心となるオブジェクト

    bool ClassUp_Flag = false;
    float up = 0.0f;

    bool ClassDown_Flag = false;
    float Down = 0.28f;

    public bool UIUp_Flag = false;
    public bool UIDown_Flag = false;

    //プレイヤーの左向き右向きを表す
    int PlayerDirection = 1;

    //方向チェンジ時の角度
    float radian = 180.0f;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //ポーズ画面になるとUpdate以外の処理も止める
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        //左に移動
        if (Input.GetKey("left"))
        {
            PlayerDirection = 1;
            if (radian != 180.0f)
            {
                radian = 180.0f;
                transform.Rotate(new Vector3(0f, radian, 0f));
            }
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, speed * Time.deltaTime);
        }

        //右に移動
        if (Input.GetKey("right"))
        {
            PlayerDirection = 2;
            if (radian != -180.0f)
            {
                radian = -180.0f;
                transform.Rotate(new Vector3(0f, radian, 0f));
            }
            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, speed * Time.deltaTime);
        }
        
        if (ClassUp_Flag == true)
        {
            //上の階層へ
            ClassUp();
        }

        if (ClassDown_Flag == true)
        {
            //下の階層へ
            ClassDown();
        }
    }
    

    //当たり判定トリガー
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "StageUp")
        {
            UIUp_Flag = true;
            
            if (Input.GetKey("up"))
            {
                ClassUp_Flag = true;
            }
        }

        if (collision.gameObject.tag == "StageDown")
        {
            UIDown_Flag = true;

            if (Input.GetKey("down"))
            {
                ClassDown_Flag = true;
            }
        }
    }

    //ノット当たり判定トリガー
    void OnTriggerExit(Collider collision)
    {
        UIUp_Flag = false;
        UIDown_Flag = false;
    }

    //当たり判定エンター
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene("ClearScene");
        }
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }

    void ClassUp()
    {
        Debug.Log("アップ");

        transform.position = new Vector3(transform.position.x, transform.position.y + up, transform.position.z);

        if (up < 0.28f) { up += 0.04f; }

        if (up >= 0.28f)
        {
            up = 0.0f;
            ClassUp_Flag = false;
            UIUp_Flag = false;
        }
    }

    void ClassDown()
    {
        Debug.Log("ダウン");

        transform.position = new Vector3(transform.position.x, transform.position.y - Down, transform.position.z);

        if (Down > 0.0f) { Down -= 0.04f; }

        if (Down <= 0.0f)
        {
            Down = 0.28f;
            ClassDown_Flag = false;
            UIDown_Flag = false;
        }
    }
}


