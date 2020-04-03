using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour//プレイヤー移動処理(現在は2Dなので画像切り替えの処理のみ)
{

    public float speed = 10.0f;

    public Transform target;//中心となるオブジェクト

    SpriteRenderer MainSpriteRenderer;//描画する画像

    public Sprite Right;//右向き画像
    public Sprite Left;//左向き画像

    bool ClassUp_Flag = false;
    float up = 0.0f;

    bool ClassDown_Flag = false;
    float Down = 0.28f;

    public bool UIUp_Flag = false;
    public bool UIDown_Flag = false;

    // Start is called before the first frame update
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();//
    }

    // Update is called once per frame
    void Update()
    {
        //ポーズ画面になるとUpdate以外の処理も止める
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        /*画像切り替え処理*/
        if (Input.GetKey("left"))//左に移動
        {
            MainSpriteRenderer.sprite = Left;
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, speed * Time.deltaTime);
        }
        if (Input.GetKey("right"))//右に移動
        {
            MainSpriteRenderer.sprite = Right;
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
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("EndScene");//終了シーンへ移動
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


