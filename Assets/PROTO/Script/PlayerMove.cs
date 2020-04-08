using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    GameObject W_Machine1;
    GameObject W_Machine2;
    GameObject W_Machine3;
    GameObject W_Machine4;
    GameObject W_Machine5;

    public float speed = 10.0f;

    public Transform target;//中心となるオブジェクト

    bool ClassUp_Flag = false;
    float up = 0.12f;

    bool ClassDown_Flag = false;
    float Down = 0.32f;

    public bool UIUp_Flag = false;
    public bool UIDown_Flag = false;

    bool key = false;

    //水増し機1
    public float WaterHight1 = 0.0f;
    bool WaterUp1_Flag = false;
    bool WaterUp1 = false;

    bool WaterDown1_Flag = true;
    bool WaterDown1 = false;

    //水増し機2
    public float WaterHight2 = 0.0f;
    bool WaterUp2_Flag = false;
    bool WaterUp2 = false;

    bool WaterDown2_Flag = true;
    bool WaterDown2 = false;

    //水増し機3
    public float WaterHight3 = 0.0f;
    bool WaterUp3_Flag = false;
    bool WaterUp3 = false;

    public bool WaterDown3_Flag = true;
    bool WaterDown3 = false;

    //水増し機4
    public float WaterHight4 = 0.0f;
    bool WaterUp4_Flag = false;
    bool WaterUp4 = false;

    bool WaterDown4_Flag = true;
    bool WaterDown4 = false;

    //水増し機3
    public float WaterHight5 = 0.0f;
    bool WaterUp5_Flag = false;
    bool WaterUp5 = false;

    bool WaterDown5_Flag = true;
    bool WaterDown5 = false;



    //プレイヤーの左向き右向きを表す
    int PlayerDirection = 1;

    //方向チェンジ時の角度
    float radian = 180.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        // Watermachineコンポーネントの取得
        W_Machine1 = GameObject.Find("Water/WaterProNighttime1");
        W_Machine2 = GameObject.Find("Water/WaterProNighttime2");
        W_Machine3 = GameObject.Find("Water/WaterProNighttime3");
        W_Machine4 = GameObject.Find("Water/WaterProNighttime4");
        W_Machine5 = GameObject.Find("Water/WaterProNighttime5");
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


        //一階の水増し機
        if (WaterUp1 == true)
        {
            //一階の水増し
            WaterGain1();
        }
        if (WaterDown1 == true)
        {
            //一階の水減
            WaterLoss1();
        }


        //二階の水増し機
        if (WaterUp2 == true)
        {
            //二階の水増し
            WaterGain2();
        }
        if (WaterDown2 == true)
        {
            //二階の水減
            WaterLoss2();
        }


        //三階の水増し機
        if (WaterUp3 == true)
        {
            //三階の水増し
            WaterGain3();
        }
        if (WaterDown3 == true)
        {
            //三階の水減
            WaterLoss3();
        }


        //四階の水増し機
        if (WaterUp4 == true)
        {
            //三階の水増し
            WaterGain4();
        }
        if (WaterDown4 == true)
        {
            //三階の水減
            WaterLoss4();
        }


        //五階の水増し機
        if (WaterUp5 == true)
        {
            //三階の水増し
            WaterGain5();
        }
        if (WaterDown5 == true)
        {
            //三階の水減
            WaterLoss5();
        }
    }
    

    //当たり判定トリガー
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "StageUp" && gameObject.tag == "Player")
        {
            UIUp_Flag = true;
            
            if (Input.GetKey("up") && ClassUp_Flag == false && key == false)
            {
                ClassUp_Flag = true;
                key = true;
            }
        }

        if (collision.gameObject.tag == "StageDown")
        {
            UIDown_Flag = true;

            if (Input.GetKey("down") && ClassDown_Flag == false && key == false)
            {
                ClassDown_Flag = true;
                key = true;
            }
        }

        //水増し機１との判定
        if (collision.gameObject.tag == "Water1")
        {
            if (WaterHight1 == 0.0f || WaterHight1 == -0.1f)
            {
                WaterUp1_Flag = true;
                UIUp_Flag = true;
            }
            if (WaterHight1 == 0.1f)
            {
                WaterDown1_Flag = true;
                UIDown_Flag = true;
            }

            if (Input.GetKey("down") && WaterDown1_Flag == true)
            {
                WaterDown1 = true;
            }
            if (Input.GetKey("up") && WaterUp1_Flag == true)
            {
                WaterUp1 = true;
            }
        }

        //水増し機2との判定
        if (collision.gameObject.tag == "Water2")
        {
            if (WaterHight2 == 0.0f || WaterHight2 == -0.1f)
            {
                WaterUp2_Flag = true;
                UIUp_Flag = true;
            }
            if (WaterHight2 == 0.1f)
            {
                WaterDown2_Flag = true;
                UIDown_Flag = true;
            }

            if (Input.GetKey("down") && WaterDown2_Flag == true)
            {
                WaterDown2 = true;
            }
            if (Input.GetKey("up") && WaterUp2_Flag == true)
            {
                WaterUp2 = true;
            }
        }

        //水増し機3との判定
        if (collision.gameObject.tag == "Water3")
        {
            if (WaterHight3 == 0.0f || WaterHight3 == -0.1f)
            {
                WaterUp3_Flag = true;
                UIUp_Flag = true;
            }
            if (WaterHight3 == 0.1f)
            {
                WaterDown3_Flag = true;
                UIDown_Flag = true;
            }

            if (Input.GetKey("down") && WaterDown3_Flag == true)
            {
                WaterDown3 = true;
            }
            if (Input.GetKey("up") && WaterUp3_Flag == true)
            {
                WaterUp3 = true;
            }
        }

        //水増し機4との判定
        if (collision.gameObject.tag == "Water4")
        {
            if (WaterHight4 == 0.0f || WaterHight4 == -0.1f)
            {
                WaterUp4_Flag = true;
                UIUp_Flag = true;
            }
            if (WaterHight4 == 0.1f)
            {
                WaterDown4_Flag = true;
                UIDown_Flag = true;
            }

            if (Input.GetKey("down") && WaterDown4_Flag == true)
            {
                WaterDown4 = true;
            }
            if (Input.GetKey("up") && WaterUp4_Flag == true)
            {
                WaterUp4 = true;
            }
        }

        //水増し機5との判定
        if (collision.gameObject.tag == "Water5")
        {
            if (WaterHight5 == 0.0f || WaterHight5 == -0.1f)
            {
                WaterUp5_Flag = true;
                UIUp_Flag = true;
            }
            if (WaterHight5 == 0.1f)
            {
                WaterDown5_Flag = true;
                UIDown_Flag = true;
            }

            if (Input.GetKey("down") && WaterDown5_Flag == true)
            {
                WaterDown5 = true;
            }
            if (Input.GetKey("up") && WaterUp5_Flag == true)
            {
                WaterUp5 = true;
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
        Debug.Log("階層アップ");

        transform.position = new Vector3(transform.position.x, transform.position.y + up, transform.position.z);

        if (up < 0.32f) { up += 0.04f; }

        if (up >= 0.32f)
        {
            up = 0.12f;
            ClassUp_Flag = false;
            UIUp_Flag = false;
            key = false;
        }
    }

    void ClassDown()
    {
        Debug.Log("階層ダウン");

        transform.position = new Vector3(transform.position.x, transform.position.y - Down, transform.position.z);

        if (Down > 0.24f) { Down -= 0.04f; }

        if (Down < 0.24f)
        {
            Down = 0.32f;
            ClassDown_Flag = false;
            UIDown_Flag = false;
            key = false;
        }
    }


    //一階の水増し機
    void WaterGain1()
    {
        Debug.Log("水アップ");

        WaterHight1 = 0.1f;
        
        W_Machine1.transform.position = new Vector3(W_Machine1.transform.position.x, W_Machine1.transform.position.y + WaterHight1, W_Machine1.transform.position.z);

        WaterUp1_Flag = false;

        WaterUp1 = false;

        UIUp_Flag = false;
    }

    void WaterLoss1()
    {
        Debug.Log("水ダウン");

        WaterHight1 = -0.1f;

        W_Machine1.transform.position = new Vector3(W_Machine1.transform.position.x, W_Machine1.transform.position.y + WaterHight1, W_Machine1.transform.position.z);

        WaterDown1_Flag = false;

        WaterDown1 = false;

        UIDown_Flag = false;
    }



    //二階の水増し機
    void WaterGain2()
    {
        Debug.Log("水アップ");

        WaterHight2 = 0.1f;

        W_Machine2.transform.position = new Vector3(W_Machine2.transform.position.x, W_Machine2.transform.position.y + WaterHight2, W_Machine2.transform.position.z);

        WaterUp2_Flag = false;

        WaterUp2 = false;

        UIUp_Flag = false;
    }

    void WaterLoss2()
    {
        Debug.Log("水ダウン");

        WaterHight2 = -0.1f;

        W_Machine2.transform.position = new Vector3(W_Machine2.transform.position.x, W_Machine2.transform.position.y + WaterHight2, W_Machine2.transform.position.z);

        WaterDown2_Flag = false;

        WaterDown2 = false;

        UIDown_Flag = false;
    }


    //三階の水増し機
    void WaterGain3()
    {
        Debug.Log("水アップ");

        WaterHight3 = 0.1f;

        W_Machine3.transform.position = new Vector3(W_Machine3.transform.position.x, W_Machine3.transform.position.y + WaterHight3, W_Machine3.transform.position.z);

        WaterUp3_Flag = false;

        WaterUp3 = false;

        UIUp_Flag = false;
    }

    void WaterLoss3()
    {
        Debug.Log("水ダウン");

        WaterHight3 = -0.1f;

        W_Machine3.transform.position = new Vector3(W_Machine3.transform.position.x, W_Machine3.transform.position.y + WaterHight3, W_Machine3.transform.position.z);

        WaterDown3_Flag = false;

        WaterDown3 = false;

        UIDown_Flag = false;
    }


    //四階の水増し機
    void WaterGain4()
    {
        Debug.Log("水アップ");

        WaterHight4 = 0.1f;

        W_Machine4.transform.position = new Vector3(W_Machine4.transform.position.x, W_Machine4.transform.position.y + WaterHight4, W_Machine4.transform.position.z);

        WaterUp4_Flag = false;

        WaterUp4 = false;

        UIUp_Flag = false;
    }

    void WaterLoss4()
    {
        Debug.Log("水ダウン");

        WaterHight4 = -0.1f;

        W_Machine4.transform.position = new Vector3(W_Machine4.transform.position.x, W_Machine4.transform.position.y + WaterHight4, W_Machine4.transform.position.z);

        WaterDown4_Flag = false;

        WaterDown4 = false;

        UIDown_Flag = false;
    }


    //五階の水増し機
    void WaterGain5()
    {
        Debug.Log("水アップ");

        WaterHight5 = 0.1f;

        W_Machine5.transform.position = new Vector3(W_Machine5.transform.position.x, W_Machine5.transform.position.y + WaterHight5, W_Machine5.transform.position.z);

        WaterUp5_Flag = false;

        WaterUp5 = false;

        UIUp_Flag = false;
    }

    void WaterLoss5()
    {
        Debug.Log("水ダウン");

        WaterHight5 = -0.1f;

        W_Machine5.transform.position = new Vector3(W_Machine5.transform.position.x, W_Machine5.transform.position.y + WaterHight5, W_Machine5.transform.position.z);

        WaterDown5_Flag = false;

        WaterDown5 = false;

        UIDown_Flag = false;
    }
}


