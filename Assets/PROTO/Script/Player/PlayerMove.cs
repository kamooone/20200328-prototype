﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 必要なコンポーネントの列記
[RequireComponent(typeof(Animator))]

public class PlayerMove : MonoBehaviour
{
    GameObject W_Machine1;
    GameObject W_Machine2;
    GameObject W_Machine3;

    public GameObject Key;

    public AudioClip WaterUpSE;
    public AudioClip WaterDownSE;
    public AudioClip StageUpSE;
    public AudioClip StageDownSE;

    AudioSource aud;

    // キャラにアタッチされるアニメーターへの参照
    private Animator anim;

    // base layerで使われる、アニメーターの現在の状態の参照
    private AnimatorStateInfo currentBaseState;


    // アニメーター各ステートへの参照
    static int locoState = Animator.StringToHash("Base Layer.walk");
    static int jumpState = Animator.StringToHash("Base Layer.climb");
    static int restState = Animator.StringToHash("Base Layer.water");

    // アニメーション再生速度設定
    float animSpeed = 1.0f;

    public GameObject Text;

    public float speed = 10.0f;

    //プレイヤー速度管理用
    public bool PlayerSpeed_Flag = false;

    public Transform target;//中心となるオブジェクト

    bool ClassUp_Flag = false;
    float up = 0.0f;

    bool ClassDown_Flag = false;
    float Down = 0.0f;
    float FallDown = 0.0f;

    public bool UIUp_Flag = false;
    public bool UIDown_Flag = false;

    bool GroundCollision = true;

    int StageNow = 1;

    bool NoWaterMove = false;


    public static bool WaterAction = false;
    int WaterTime = 0;
    bool Water = false;

    //プレイヤー移動中かどうか
    bool Move = false;

    int WalkStopTime = 0;

    //水増し機1
    public float WaterHight1 = 0.0f;
    bool WaterUp1_Flag = false;
    bool WaterUp1 = false;

    bool WaterDown1_Flag = false;
    bool WaterDown1 = false;

    //水増し機2
    public float WaterHight2 = 0.0f;
    bool WaterUp2_Flag = false;
    bool WaterUp2 = false;

    bool WaterDown2_Flag = false;
    bool WaterDown2 = false;

    //水増し機3
    public float WaterHight3 = 0.0f;
    bool WaterUp3_Flag = false;
    bool WaterUp3 = false;

    public bool WaterDown3_Flag = false;
    bool WaterDown3 = false;


    //プレイヤーの左向き右向きを表す
    public static int PlayerDirection = 1;

    //方向チェンジ時の角度
    float radian = 180.0f;

    //エネミー2とのコリジョン判定(水位ゼロの時はゲームオーバーにならず、壁と同じ状態)
    public bool Enemy2_Collision_Left = false;
    public bool Enemy2_Collision_Right = false;


    //プレイヤー追従キー描画フラグ
    public static bool PlayerKeyDraw = false;



    // Start is called before the first frame update
    void Start()
    {
        // Watermachineコンポーネントの取得
        W_Machine1 = GameObject.Find("Ground/Ground(1)/Water");
        W_Machine2 = GameObject.Find("Ground/Ground(2)/Water");
        W_Machine3 = GameObject.Find("Ground/Ground(3)/Water");

        // Animatorコンポーネントを取得する
        anim = GetComponent<Animator>();

        this.aud = GetComponent<AudioSource>();


        WaterAction = false;
        WaterTime = 0;
        Water = false;

        PlayerKeyDraw = false;
        WalkStopTime = 11;


        if (Menu.StageNo <=10)
        {
            WaterHight1 = 0.11f;

            W_Machine1.transform.position = new Vector3(W_Machine1.transform.position.x, W_Machine1.transform.position.y + WaterHight1, W_Machine1.transform.position.z);

            WaterHight2 = 0.11f;

            W_Machine2.transform.position = new Vector3(W_Machine2.transform.position.x, W_Machine2.transform.position.y + WaterHight2, W_Machine2.transform.position.z);

            WaterHight3 = 0.11f;

            W_Machine3.transform.position = new Vector3(W_Machine3.transform.position.x, W_Machine3.transform.position.y + WaterHight3, W_Machine3.transform.position.z);
        }

        if (Menu.StageNo >= 11)
        {
            WaterHight1 = 0.0f;

            W_Machine1.transform.position = new Vector3(W_Machine1.transform.position.x, W_Machine1.transform.position.y + WaterHight1, W_Machine1.transform.position.z);

            WaterHight2 = 0.0f;

            W_Machine2.transform.position = new Vector3(W_Machine2.transform.position.x, W_Machine2.transform.position.y + WaterHight2, W_Machine2.transform.position.z);

            WaterHight3 = 0.0f;

            W_Machine3.transform.position = new Vector3(W_Machine3.transform.position.x, W_Machine3.transform.position.y + WaterHight3, W_Machine3.transform.position.z);
        }
    }


    // Update is called once per frame
    void Update()
    {

        // Animatorのモーション再生速度に animSpeedを設定する
        anim.speed = animSpeed;

        // 参照用のステート変数にBase Layer (0)の現在のステートを設定する
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);


        //ポーズ画面になるとUpdate以外の処理も止める
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }



        //水アクション
        if (Input.GetKeyDown("h") && WaterAction == false && GoalDoor.GoalFlag == false && Move == false && WaterTime == 0 && WalkStopTime == 11)
        {
            anim.SetBool("water", true);     // Animatorにジャンプに切り替えるフラグを送る
            WaterAction = true;
            WaterTime = 0;
        }
        if (WaterAction == true)
        {
            WaterTime++;
        }

        if(WaterAction == true && WaterTime == 79)
        {
            Water = true;
        }
        if(WaterAction == true && WaterTime == 80)
        {
            anim.SetBool("water", false);     // Animatorにジャンプに切り替えるフラグを送る
            Water = false;
        }
        if (WaterAction == true && WaterTime == 100)
        {
            WaterAction = false;
            WaterTime = 0;

        }

        
        //左に移動  
        if (Input.GetKey("left") && Enemy2_Collision_Left == false && WaterAction == false && GoalDoor.GoalFlag == false)
        {
            PlayerDirection = 1;
            Move = true;
            WalkStopTime = 0;
            anim.SetBool("walk", true);     // Animatorにジャンプに切り替えるフラグを送る

            if (radian != 180.0f && radian != 90.0f && radian != -90.0f)
            {
                radian = 180.0f;
                transform.Rotate(new Vector3(0f, radian, 0f));
            }

            if (radian == 90.0f)
            {
                radian = -90.0f;
                transform.Rotate(new Vector3(0f, radian, 0f));
                radian = 180.0f;
            }

            if (radian == -90.0f)
            {
                transform.Rotate(new Vector3(0f, radian, 0f));
                radian = 180.0f;
            }

            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, speed * Time.deltaTime);
        }

        //右に移動
        if (Input.GetKey("right") && Enemy2_Collision_Right == false && WaterAction == false && GoalDoor.GoalFlag == false)
        {
            PlayerDirection = -1;
            Move = true;
            WalkStopTime = 0;
            anim.SetBool("walk", true);     // Animatorにジャンプに切り替えるフラグを送る

            if (radian != -180.0f && radian != 90.0f && radian != -90.0f)
            {
                radian = -180.0f;
                transform.Rotate(new Vector3(0f, radian, 0f));
            }

            if (radian == 90.0f)
            {
                transform.Rotate(new Vector3(0f, radian, 0f));
                radian = -180.0f;
            }

            if (radian == -90.0f)
            {
                radian = -90.0f;
                transform.Rotate(new Vector3(0f, radian, 0f));
                radian = 180.0f;
            }

            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, speed * Time.deltaTime);
        }

        if (!(Input.GetKey("right")) && !(Input.GetKey("left")) || GoalDoor.GoalFlag == true)
        {
            anim.SetBool("walk", false);
            Move = false;

            if(WalkStopTime < 11)
            {
                WalkStopTime++;
            }
        }




        ////水増し機１との判定
        //if (collision.gameObject.tag == "Water1")
        //{
        if (StageNow == 1 && Water == true)
        {
            if (WaterHight1 == 0.0f || WaterHight1 == -0.11f)
            {
                WaterUp1_Flag = true;
                UIUp_Flag = true;
            }
            if (WaterHight1 == 0.11f)
            {
                WaterDown1_Flag = true;
                UIDown_Flag = true;
            }


            if (WaterDown1_Flag == true)
            {
                this.aud.PlayOneShot(this.WaterDownSE);
                WaterDown1 = true;
            }
            if (WaterUp1_Flag == true)
            {
                this.aud.PlayOneShot(this.WaterUpSE);
                WaterUp1 = true;
            }
        }
        //}
        //
        ////水増し機2との判定
        //if (collision.gameObject.tag == "Water2")
        //{
        if (StageNow == 2 && Water == true)
        {
            if (WaterHight2 == 0.0f || WaterHight2 == -0.11f)
            {
                WaterUp2_Flag = true;
                UIUp_Flag = true;
            }
            if (WaterHight2 == 0.11f)
            {
                WaterDown2_Flag = true;
                UIDown_Flag = true;
            }

            if (WaterDown2_Flag == true)
            {
                this.aud.PlayOneShot(this.WaterDownSE);
                WaterDown2 = true;
            }
            if (WaterUp2_Flag == true)
            {
                this.aud.PlayOneShot(this.WaterUpSE);
                WaterUp2 = true;
            }
        }
        //}
        //
        ////水増し機3との判定
        //if (collision.gameObject.tag == "Water3")
        //{
        if (StageNow == 3 && Water == true)
        {
            if (WaterHight3 == 0.0f || WaterHight3 == -0.11f)
            {
                WaterUp3_Flag = true;
                UIUp_Flag = true;
            }
            if (WaterHight3 == 0.11f)
            {
                WaterDown3_Flag = true;
                UIDown_Flag = true;
            }

            if (WaterDown3_Flag == true)
            {
                this.aud.PlayOneShot(this.WaterDownSE);
                WaterDown3 = true;
            }
            if (WaterUp3_Flag == true)
            {
                this.aud.PlayOneShot(this.WaterUpSE);
                WaterUp3 = true;
            }
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


        //鍵追従
        if (PlayerKeyDraw == true)
        {
            Key.gameObject.SetActive(true);
        }
        if (PlayerKeyDraw == false)
        {
            Key.gameObject.SetActive(false);
        }


        //プレイヤー速度管理
        if (PlayerSpeed_Flag == true)
        {
            Invoke("PlayerSpeed_cnt", 5);
        }

    }

    void PlayerSpeed_cnt()
    {
        speed = 10.0f;
        PlayerSpeed_Flag = false;
    }

    //当たり判定トリガー
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "StageUp" && (StageNow != 3))
        {
            UIUp_Flag = true;
            //NoWaterMove = true;

            if (Input.GetKey("up") && ClassUp_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
            {
                this.aud.PlayOneShot(this.StageUpSE);
                ClassUp_Flag = true;
                StageNow++;
            }
        }

        if (collision.gameObject.tag == "StageDown")
        {
            UIDown_Flag = true;
            //NoWaterMove = true;

            if (Input.GetKey("down") && ClassDown_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
            {
                this.aud.PlayOneShot(this.StageDownSE);
                ClassDown_Flag = true;
                StageNow--;
            }
        }

        if (collision.gameObject.tag == "Goal")
        {
            GoalDoor.GoalFlag = true;
        }



        if (collision.gameObject.tag == "Normal" && KeyItemScript.key == false)
        {
            Text.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "Normal" && KeyItemScript.key == true)
        {
            DoorRotate.RotateFlag = true;
            PlayerKeyDraw = false;
        }

        if (collision.gameObject.tag == "Reverse" && KeyItemScript.key == false)
        {
            Text.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "Reverse" && KeyItemScript.key == true)
        {
            DoorRotate.RotateReverseFlag = true;
            PlayerKeyDraw = false;
        }



        if (collision.gameObject.tag == "Normal1" && KeyItemScript1.key == false)
        {
            Text.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "Normal1" && KeyItemScript1.key == true)
        {
            DoorRotate1.RotateFlag = true;
            PlayerKeyDraw = false;
        }

        if (collision.gameObject.tag == "Reverse1" && KeyItemScript1.key == false)
        {
            Text.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "Reverse1" && KeyItemScript1.key == true)
        {
            DoorRotate1.RotateReverseFlag = true;
            PlayerKeyDraw = false;
        }


        if (collision.gameObject.tag == "Normal2" && KeyItemScript2.key == false)
        {
            Text.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "Normal2" && KeyItemScript2.key == true)
        {
            DoorRotate2.RotateFlag = true;
            PlayerKeyDraw = false;
        }

        if (collision.gameObject.tag == "Reverse2" && KeyItemScript2.key == false)
        {
            Text.gameObject.SetActive(true);
        }
        if (collision.gameObject.tag == "Reverse2" && KeyItemScript2.key == true)
        {
            DoorRotate2.RotateReverseFlag = true;
            PlayerKeyDraw = false;
        }
    }


    //当たり判定トリガー
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Fall")
        {
            FallDown -= 0.6f;
            transform.position = new Vector3(transform.position.x, transform.position.y + FallDown, transform.position.z);
        }

        //エネミー3に当たったらプレイヤーの速度低下
        if (collision.gameObject.tag == "Enemy3")
        {
            if (PlayerSpeed_Flag == false)
            {
                speed = 0.1f;
                PlayerSpeed_Flag = true;
            }
        }

    }


    //ノット当たり判定トリガー
    void OnTriggerExit(Collider collision)
    {
        UIUp_Flag = false;
        UIDown_Flag = false;
        NoWaterMove = false;
        Text.gameObject.SetActive(false);
        FallDown = 0.0f;
    }

    //コリジョン当たり判定
    void OnCollisionEnter(Collision collision)
    {
        if ((collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Door") && PlayerDirection == 1)
        {
            Enemy2_Collision_Left = true;
        }
        if ((collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Door") && PlayerDirection == -1)
        {
            Enemy2_Collision_Right = true;
        }

    }


    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Ground3")
        {
            GroundCollision = true;
            StageNow = 3;
        }

        if (collision.gameObject.tag == "Ground2")
        {
            GroundCollision = true;
            StageNow = 2;
        }

        if (collision.gameObject.tag == "Ground1")
        {
            GroundCollision = true;
            StageNow = 1;
        }
    }

    //ノットコリジョン当たり判定
    void OnCollisionExit(Collision collision)
    {
        Enemy2_Collision_Left = false;
        Enemy2_Collision_Right = false;
        Text.gameObject.SetActive(false);
    }

    void OnCollisionStayExit(Collision collision)
    {
        GroundCollision = false;
    }

    void ClassUp()
    {
        Debug.Log("階層アップ");

        if (ClassUp_Flag == true)
        {

            up += 2.0f;
            transform.position = new Vector3(transform.position.x, transform.position.y + up, transform.position.z);

            if (radian != 90.0f && radian == 180.0f)
            {
                radian = 90.0f;
                transform.Rotate(new Vector3(0f, radian, 0f));
            }

            if (radian != 90.0f && radian == -180.0f)
            {
                radian = -90.0f;
                transform.Rotate(new Vector3(0f, radian, 0f));
            }
            //anim.SetBool("climb", true);     // Animatorにジャンプに切り替えるフラグを送る
        }

        if (up == 2.0f)
        {
            up = 0.0f;
            ClassUp_Flag = false;
            UIUp_Flag = false;

           // anim.SetBool("climb", false);     // Animatorにジャンプに切り替えるフラグを送る
        }
    }

    void ClassDown()
    {
        Debug.Log("階層ダウン");

        if (ClassDown_Flag == true)
        {

            Down -= 2.0f;
            transform.position = new Vector3(transform.position.x, transform.position.y + Down, transform.position.z);


            if (radian != 90.0f && radian == 180.0f)
            {
                radian = 90.0f;
                transform.Rotate(new Vector3(0f, radian, 0f));
            }

            if (radian != 90.0f && radian == -180.0f)
            {
                radian = -90.0f;
                transform.Rotate(new Vector3(0f, radian, 0f));
            }
            //anim.SetBool("climb", true);     // Animatorにジャンプに切り替えるフラグを送る
        }


        if (Down == -2.0f)
        {
            Down = 0.0f;
            ClassDown_Flag = false;
            UIDown_Flag = false;

           // anim.SetBool("climb", false);     // Animatorにジャンプに切り替えるフラグを送る
        }
    }


    //一階の水増し機
    void WaterGain1()
    {
        Debug.Log("水アップ");

        WaterHight1 = 0.11f;

        W_Machine1.transform.position = new Vector3(W_Machine1.transform.position.x, W_Machine1.transform.position.y + WaterHight1, W_Machine1.transform.position.z);

        WaterUp1_Flag = false;

        WaterUp1 = false;

        UIUp_Flag = false;
    }

    void WaterLoss1()
    {
        Debug.Log("水ダウン");

        WaterHight1 = -0.11f;

        W_Machine1.transform.position = new Vector3(W_Machine1.transform.position.x, W_Machine1.transform.position.y + WaterHight1, W_Machine1.transform.position.z);

        WaterDown1_Flag = false;

        WaterDown1 = false;

        UIDown_Flag = false;
    }



    //二階の水増し機
    void WaterGain2()
    {
        Debug.Log("水アップ");

        WaterHight2 = 0.11f;

        W_Machine2.transform.position = new Vector3(W_Machine2.transform.position.x, W_Machine2.transform.position.y + WaterHight2, W_Machine2.transform.position.z);

        WaterUp2_Flag = false;

        WaterUp2 = false;

        UIUp_Flag = false;
    }

    void WaterLoss2()
    {
        Debug.Log("水ダウン");

        WaterHight2 = -0.11f;

        W_Machine2.transform.position = new Vector3(W_Machine2.transform.position.x, W_Machine2.transform.position.y + WaterHight2, W_Machine2.transform.position.z);

        WaterDown2_Flag = false;

        WaterDown2 = false;

        UIDown_Flag = false;
    }


    //三階の水増し機
    void WaterGain3()
    {
        Debug.Log("水アップ");

        WaterHight3 = 0.11f;

        W_Machine3.transform.position = new Vector3(W_Machine3.transform.position.x, W_Machine3.transform.position.y + WaterHight3, W_Machine3.transform.position.z);

        WaterUp3_Flag = false;

        WaterUp3 = false;

        UIUp_Flag = false;
    }

    void WaterLoss3()
    {
        Debug.Log("水ダウン");

        WaterHight3 = -0.11f;

        W_Machine3.transform.position = new Vector3(W_Machine3.transform.position.x, W_Machine3.transform.position.y + WaterHight3, W_Machine3.transform.position.z);

        WaterDown3_Flag = false;

        WaterDown3 = false;

        UIDown_Flag = false;
    }

}


