using System.Collections;
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
    public AudioClip NotCloseSE;
    public AudioClip KeyGet;

    AudioSource aud;

    bool NotCloseSE_Flag = false;
    bool GetKeyFlag = false;

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

    //動かせる壁
    public static float wallspeed = 4.0f;

    public static bool WallFlag0 = false;
    public static bool Wall_Move0 = false;
    public static bool WallNo0 = false;

    public static bool WallFlag1 = false;
    public static bool Wall_Move1 = false;
    public static bool WallNo1 = false;

    public static bool WallFlag2 = false;
    public static bool Wall_Move2 = false;
    public static bool WallNo2 = false;

    public static bool WallFlag3 = false;
    public static bool Wall_Move3 = false;
    public static bool WallNo3 = false;

    public static bool WallFlag4 = false;
    public static bool Wall_Move4 = false;
    public static bool WallNo4 = false;


    public static bool WallFlag5 = false;
    public static bool Wall_Move5 = false;
    public static bool WallNo5 = false;


    public static bool WallFlag6 = false;
    public static bool Wall_Move6 = false;
    public static bool WallNo6 = false;


    public static bool WallFlag7 = false;
    public static bool Wall_Move7 = false;
    public static bool WallNo7 = false;


    public static bool WallFlag8 = false;
    public static bool Wall_Move8 = false;
    public static bool WallNo8 = false;



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
        GetKeyFlag = false;


        WaterAction = false;
        WaterTime = 0;
        Water = false;

        PlayerKeyDraw = false;
        WalkStopTime = 11;

        

        if (Menu.StageNo >= 0)
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
        if ((Input.GetKeyDown("h") || Input.GetKeyDown("joystick button 2")) && WaterAction == false && GoalDoor.GoalFlag == false && Move == false && WaterTime == 0 && WalkStopTime == 11
             && Wall_Move0 == false && Wall_Move1 == false && Wall_Move2 == false && Wall_Move3 == false && Wall_Move4 == false && Wall_Move5 == false)
        {
            anim.SetBool("water", true);     // Animatorにジャンプに切り替えるフラグを送る
            WaterAction = true;
            WaterTime = 0;
        }
        if (WaterAction == true)
        {
            WaterTime++;
        }

        if (WaterAction == true && WaterTime == 79)
        {
            Water = true;
        }
        if (WaterAction == true && WaterTime == 80)
        {
            anim.SetBool("water", false);     // Animatorにジャンプに切り替えるフラグを送る
            Water = false;
        }
        if (WaterAction == true && WaterTime == 100)
        {
            WaterAction = false;
            WaterTime = 0;
        }


        //L Stick
        float Left = Input.GetAxis("L");
        float Right = Input.GetAxis("R");
        



        //左に移動  
        if ((Left > 0 || Input.GetKey("left")) && Enemy2_Collision_Left == false && WaterAction == false && GoalDoor.GoalFlag == false
            && Wall_Move0 == false && Wall_Move1 == false && Wall_Move2 == false && Wall_Move3 == false && Wall_Move4 == false && Wall_Move5 == false)
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
        if ((Right > 0 || Input.GetKey("right")) && Enemy2_Collision_Right == false && WaterAction == false && GoalDoor.GoalFlag == false
            && Wall_Move0 == false && Wall_Move1 == false && Wall_Move2 == false && Wall_Move3 == false && Wall_Move4 == false && Wall_Move5 == false)
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

        if (!Input.GetKey("right") && !Input.GetKey("left") && ((Right == 0) && (Left == 0)) || GoalDoor.GoalFlag == true || Enemy2_Collision_Right == true || Enemy2_Collision_Left == true
            && Wall_Move0 == false && Wall_Move1 == false && Wall_Move2 == false && Wall_Move3 == false && Wall_Move4 == false && Wall_Move5 == false)
        {
            anim.SetBool("walk", false);
            Move = false;

            if (WalkStopTime < 11)
            {
                WalkStopTime++;
            }
        }







        //壁を動かす================================================================================================
        if ((Input.GetKey("t") || Input.GetKeyDown("joystick button 0")) && WallFlag0 == true && Wall.wallcollision0 == false && WaterHight2 == 0.11f && Enemy1Move.TuiFlag == false && Enemy1Move.doorcollision == false
            && Enemy2Move.TuiFlag == false && Enemy2Move.doorcollision == false && Enemy3Move.TuiFlag == false && Enemy3Move.doorcollision == false &&
            Enemy2_1Move.TuiFlag == false && Enemy2_1Move.doorcollision == false && Enemy2_2Move.TuiFlag == false && Enemy2_2Move.doorcollision == false && Enemy2_3Move.TuiFlag == false && Enemy2_3Move.doorcollision == false)
        {
            anim.SetBool("wall", true);
            Wall_Move0 = true;
        }
        if (Input.GetKeyUp("t") || Input.GetKeyUp("joystick button 0"))
        {
            anim.SetBool("wall", false);
            Wall_Move0 = false;
        }
        //左に移動  
        if ((Left > 0 || Input.GetKey("left")) && Wall_Move0 == true && PlayerDirection == 1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }

        //右に移動
        if ((Right > 0 || Input.GetKey("right")) && Wall_Move0 == true && PlayerDirection == -1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }
        if(Wall.wallcollision0 == true)
        {
            Wall_Move0 = false;
            anim.SetBool("wall", false);
        }



        //壁を動かす================================================================================================
        if ((Input.GetKey("t") || Input.GetKeyDown("joystick button 0")) && WallFlag1 == true && Wall1.wallcollision1 == false && WaterHight2 == 0.11f && Enemy1Move.TuiFlag == false && Enemy1Move.doorcollision == false
            && Enemy2Move.TuiFlag == false && Enemy2Move.doorcollision == false && Enemy3Move.TuiFlag == false && Enemy3Move.doorcollision == false &&
            Enemy2_1Move.TuiFlag == false && Enemy2_1Move.doorcollision == false && Enemy2_2Move.TuiFlag == false && Enemy2_2Move.doorcollision == false && Enemy2_3Move.TuiFlag == false && Enemy2_3Move.doorcollision == false)
        {
            anim.SetBool("wall", true);
            Wall_Move1 = true;
        }
        if (Input.GetKeyUp("t") || Input.GetKeyUp("joystick button 0"))
        {
            anim.SetBool("wall", false);
            Wall_Move1 = false;
        }
        //左に移動  
        if ((Left > 0 || Input.GetKey("left")) && Wall_Move1 == true && PlayerDirection == 1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }

        //右に移動
        if ((Right > 0 || Input.GetKey("right")) && Wall_Move1 == true && PlayerDirection == -1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }
        if (Wall1.wallcollision1 == true)
        {
            Wall_Move1 = false;
            anim.SetBool("wall", false);
        }



        //壁を動かす================================================================================================
        if ((Input.GetKey("t") || Input.GetKeyDown("joystick button 0")) && WallFlag2 == true && Wall2.wallcollision2 == false && WaterHight1 == 0.11f && Enemy1Move.TuiFlag == false && Enemy1Move.doorcollision == false
            && Enemy2Move.TuiFlag == false && Enemy2Move.doorcollision == false && Enemy3Move.TuiFlag == false && Enemy3Move.doorcollision == false &&
            Enemy2_1Move.TuiFlag == false && Enemy2_1Move.doorcollision == false && Enemy2_2Move.TuiFlag == false && Enemy2_2Move.doorcollision == false && Enemy2_3Move.TuiFlag == false && Enemy2_3Move.doorcollision == false)
        {
            anim.SetBool("wall", true);
            Wall_Move2 = true;
        }
        if (Input.GetKeyUp("t") || Input.GetKeyUp("joystick button 0"))
        {
            anim.SetBool("wall", false);
            Wall_Move2 = false;
        }
        //左に移動  
        if ((Left > 0 || Input.GetKey("left")) && Wall_Move2 == true && PlayerDirection == 1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }

        //右に移動
        if ((Right > 0 || Input.GetKey("right")) && Wall_Move2 == true && PlayerDirection == -1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }
        if (Wall2.wallcollision2 == true)
        {
            Wall_Move2 = false;
            anim.SetBool("wall", false);
        }



        //壁を動かす================================================================================================
        if ((Input.GetKey("t") || Input.GetKeyDown("joystick button 0")) && WallFlag3 == true && Wall3.wallcollision3 == false && WaterHight3 == 0.11f && Enemy1Move.TuiFlag == false && Enemy1Move.doorcollision == false
            && Enemy2Move.TuiFlag == false && Enemy2Move.doorcollision == false && Enemy3Move.TuiFlag == false && Enemy3Move.doorcollision == false &&
            Enemy2_1Move.TuiFlag == false && Enemy2_1Move.doorcollision == false && Enemy2_2Move.TuiFlag == false && Enemy2_2Move.doorcollision == false && Enemy2_3Move.TuiFlag == false && Enemy2_3Move.doorcollision == false)
        {
            anim.SetBool("wall", true);
            Wall_Move3 = true;
        }
        if (Input.GetKeyUp("t") || Input.GetKeyUp("joystick button 0"))
        {
            anim.SetBool("wall", false);
            Wall_Move3 = false;
        }
        //左に移動  
        if ((Left > 0 || Input.GetKey("left")) && Wall_Move3 == true && PlayerDirection == 1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }

        //右に移動
        if ((Right > 0 || Input.GetKey("right")) && Wall_Move3 == true && PlayerDirection == -1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }
        if (Wall3.wallcollision3 == true)
        {
            Wall_Move3 = false;
            anim.SetBool("wall", false);
        }



        //壁を動かす================================================================================================
        if ((Input.GetKey("t") || Input.GetKeyDown("joystick button 0")) && WallFlag4 == true && Wall4.wallcollision4 == false && WaterHight3 == 0.11f && Enemy1Move.TuiFlag == false && Enemy1Move.doorcollision == false
            && Enemy2Move.TuiFlag == false && Enemy2Move.doorcollision == false && Enemy3Move.TuiFlag == false && Enemy3Move.doorcollision == false &&
            Enemy2_1Move.TuiFlag == false && Enemy2_1Move.doorcollision == false && Enemy2_2Move.TuiFlag == false && Enemy2_2Move.doorcollision == false && Enemy2_3Move.TuiFlag == false && Enemy2_3Move.doorcollision == false)
        {
            anim.SetBool("wall", true);
            Wall_Move4 = true;
        }
        if (Input.GetKeyUp("t") || Input.GetKeyUp("joystick button 0"))
        {
            anim.SetBool("wall", false);
            Wall_Move4 = false;
        }
        //左に移動  
        if ((Left > 0 || Input.GetKey("left")) && Wall_Move4 == true && PlayerDirection == 1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }

        //右に移動
        if ((Right > 0 || Input.GetKey("right")) && Wall_Move4 == true && PlayerDirection == -1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }
        if (Wall4.wallcollision4 == true)
        {
            Wall_Move4 = false;
            anim.SetBool("wall", false);
        }



        //壁を動かす================================================================================================
        if ((Input.GetKey("t") || Input.GetKeyDown("joystick button 0")) && WallFlag5 == true && Wall5.wallcollision5 == false && WaterHight1 == 0.11f && Enemy1Move.TuiFlag == false && Enemy1Move.doorcollision == false
             && Enemy2Move.TuiFlag == false && Enemy2Move.doorcollision == false && Enemy3Move.TuiFlag == false && Enemy3Move.doorcollision == false &&
            Enemy2_1Move.TuiFlag == false && Enemy2_1Move.doorcollision == false && Enemy2_2Move.TuiFlag == false && Enemy2_2Move.doorcollision == false && Enemy2_3Move.TuiFlag == false && Enemy2_3Move.doorcollision == false)
        {
            anim.SetBool("wall", true);
            Wall_Move5 = true;
        }
        if (Input.GetKeyUp("t") || Input.GetKeyUp("joystick button 0"))
        {
            anim.SetBool("wall", false);
            Wall_Move5 = false;
        }
        //左に移動  
        if ((Left > 0 || Input.GetKey("left")) && Wall_Move5 == true && PlayerDirection == 1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }

        //右に移動
        if ((Right > 0 || Input.GetKey("right")) && Wall_Move5 == true && PlayerDirection == -1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }
        if (Wall5.wallcollision5 == true)
        {
            Wall_Move5 = false;
            anim.SetBool("wall", false);
        }



        //壁を動かす================================================================================================
        if ((Input.GetKey("t") || Input.GetKeyDown("joystick button 0")) && WallFlag6 == true && Wall6.wallcollision6 == false && WaterHight1 == 0.11f && Enemy1Move.TuiFlag == false && Enemy1Move.doorcollision == false
             && Enemy2Move.TuiFlag == false && Enemy2Move.doorcollision == false && Enemy3Move.TuiFlag == false && Enemy3Move.doorcollision == false &&
            Enemy2_1Move.TuiFlag == false && Enemy2_1Move.doorcollision == false && Enemy2_2Move.TuiFlag == false && Enemy2_2Move.doorcollision == false && Enemy2_3Move.TuiFlag == false && Enemy2_3Move.doorcollision == false)
        {
            anim.SetBool("wall", true);
            Wall_Move6 = true;
        }
        if (Input.GetKeyUp("t") || Input.GetKeyUp("joystick button 0"))
        {
            anim.SetBool("wall", false);
            Wall_Move6 = false;
        }
        //左に移動  
        if ((Left > 0 || Input.GetKey("left")) && Wall_Move6 == true && PlayerDirection == 1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }

        //右に移動
        if ((Right > 0 || Input.GetKey("right")) && Wall_Move6 == true && PlayerDirection == -1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }
        if (Wall6.wallcollision6 == true)
        {
            Wall_Move6 = false;
            anim.SetBool("wall", false);
        }




        //壁を動かす================================================================================================
        if ((Input.GetKey("t") || Input.GetKeyDown("joystick button 0")) && WallFlag7 == true && Wall7.wallcollision7 == false && WaterHight2 == 0.11f && Enemy1Move.TuiFlag == false && Enemy1Move.doorcollision == false
             && Enemy2Move.TuiFlag == false && Enemy2Move.doorcollision == false && Enemy3Move.TuiFlag == false && Enemy3Move.doorcollision == false &&
            Enemy2_1Move.TuiFlag == false && Enemy2_1Move.doorcollision == false && Enemy2_2Move.TuiFlag == false && Enemy2_2Move.doorcollision == false && Enemy2_3Move.TuiFlag == false && Enemy2_3Move.doorcollision == false)
        {
            anim.SetBool("wall", true);
            Wall_Move7 = true;
        }
        if (Input.GetKeyUp("t") || Input.GetKeyUp("joystick button 0"))
        {
            anim.SetBool("wall", false);
            Wall_Move7 = false;
        }
        //左に移動  
        if ((Left > 0 || Input.GetKey("left")) && Wall_Move7 == true && PlayerDirection == 1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }

        //右に移動
        if ((Right > 0 || Input.GetKey("right")) && Wall_Move7 == true && PlayerDirection == -1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }
        if (Wall7.wallcollision7 == true)
        {
            Wall_Move7 = false;
            anim.SetBool("wall", false);
        }



        //壁を動かす================================================================================================
        if ((Input.GetKey("t") || Input.GetKeyDown("joystick button 0")) && WallFlag8 == true && Wall8.wallcollision8 == false && WaterHight3 == 0.11f && Enemy1Move.TuiFlag == false && Enemy1Move.doorcollision == false
             && Enemy2Move.TuiFlag == false && Enemy2Move.doorcollision == false && Enemy3Move.TuiFlag == false && Enemy3Move.doorcollision == false &&
            Enemy2_1Move.TuiFlag == false && Enemy2_1Move.doorcollision == false && Enemy2_2Move.TuiFlag == false && Enemy2_2Move.doorcollision == false && Enemy2_3Move.TuiFlag == false && Enemy2_3Move.doorcollision == false)
        {
            anim.SetBool("wall", true);
            Wall_Move8 = true;
        }
        if (Input.GetKeyUp("t") || Input.GetKeyUp("joystick button 0"))
        {
            anim.SetBool("wall", false);
            Wall_Move8 = false;
        }
        //左に移動  
        if ((Left > 0 || Input.GetKey("left")) && Wall_Move8 == true && PlayerDirection == 1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }

        //右に移動
        if ((Right > 0 || Input.GetKey("right")) && Wall_Move8 == true && PlayerDirection == -1)
        {
            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, wallspeed * Time.deltaTime);
        }
        if (Wall8.wallcollision8 == true)
        {
            Wall_Move8 = false;
            anim.SetBool("wall", false);
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

            if (GetKeyFlag == false)
            {
                this.aud.PlayOneShot(this.KeyGet);
                GetKeyFlag = true;
            }
        }
        if (PlayerKeyDraw == false)
        {
            Key.gameObject.SetActive(false);
            GetKeyFlag = false;
        }


    }


    //当たり判定トリガー
    void OnTriggerStay(Collider collision)
    {
        if (Move == false)
        {
            //================================================================================================================================================================================================
            if (collision.gameObject.tag == "Up")
            {
                UIUp_Flag = true;

                if ((Input.GetKey("up") || Input.GetKeyDown("joystick button 0")) && ClassUp_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageUpSE);
                    ClassUp_Flag = true;
                    StageNow++;
                }
            }
            if (collision.gameObject.tag == "Up_1")
            {
                UIUp_Flag = true;

                if ((Input.GetKey("up") || Input.GetKeyDown("joystick button 0")) && ClassUp_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageUpSE);
                    ClassUp_Flag = true;
                    StageNow++;
                }
            }
            if (collision.gameObject.tag == "Up_2")
            {
                UIUp_Flag = true;

                if ((Input.GetKey("up") || Input.GetKeyDown("joystick button 0")) && ClassUp_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageUpSE);
                    ClassUp_Flag = true;
                    StageNow++;
                }
            }
            if (collision.gameObject.tag == "Up_3")
            {
                UIUp_Flag = true;

                if ((Input.GetKey("up") || Input.GetKeyDown("joystick button 0")) && ClassUp_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageUpSE);
                    ClassUp_Flag = true;
                    StageNow++;
                }
            }
            if (collision.gameObject.tag == "Up_4")
            {
                UIUp_Flag = true;

                if ((Input.GetKey("up") || Input.GetKeyDown("joystick button 0")) && ClassUp_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageUpSE);
                    ClassUp_Flag = true;
                    StageNow++;
                }
            }
            if (collision.gameObject.tag == "Up_5")
            {
                UIUp_Flag = true;

                if ((Input.GetKey("up") || Input.GetKeyDown("joystick button 0")) && ClassUp_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageUpSE);
                    ClassUp_Flag = true;
                    StageNow++;
                }
            }
            if (collision.gameObject.tag == "Up_6")
            {
                UIUp_Flag = true;

                if ((Input.GetKey("up") || Input.GetKeyDown("joystick button 0")) && ClassUp_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageUpSE);
                    ClassUp_Flag = true;
                    StageNow++;
                }
            }
            //================================================================================================================================================================================================







            if (collision.gameObject.tag == "Up1")
            {
                UIUp_Flag = true;

                if ((Input.GetKey("up") || Input.GetKeyDown("joystick button 0")) && ClassUp_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageUpSE);
                    ClassUp_Flag = true;
                    StageNow++;
                }
            }
            if (collision.gameObject.tag == "Up1_1")
            {
                UIUp_Flag = true;

                if ((Input.GetKey("up") || Input.GetKeyDown("joystick button 0")) && ClassUp_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageUpSE);
                    ClassUp_Flag = true;
                    StageNow++;
                }
            }
            if (collision.gameObject.tag == "Up1_2")
            {
                UIUp_Flag = true;

                if ((Input.GetKey("up") || Input.GetKeyDown("joystick button 0")) && ClassUp_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageUpSE);
                    ClassUp_Flag = true;
                    StageNow++;
                }
            }
            if (collision.gameObject.tag == "Up1_3")
            {
                UIUp_Flag = true;

                if ((Input.GetKey("up") || Input.GetKeyDown("joystick button 0")) && ClassUp_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageUpSE);
                    ClassUp_Flag = true;
                    StageNow++;
                }
            }
            if (collision.gameObject.tag == "Up1_4")
            {
                UIUp_Flag = true;

                if ((Input.GetKey("up") || Input.GetKeyDown("joystick button 0")) && ClassUp_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageUpSE);
                    ClassUp_Flag = true;
                    StageNow++;
                }
            }
            if (collision.gameObject.tag == "Up1_5")
            {
                UIUp_Flag = true;

                if ((Input.GetKey("up") || Input.GetKeyDown("joystick button 0")) && ClassUp_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageUpSE);
                    ClassUp_Flag = true;
                    StageNow++;
                }
            }
            if (collision.gameObject.tag == "Up1_6")
            {
                UIUp_Flag = true;

                if ((Input.GetKey("up") || Input.GetKeyDown("joystick button 0")) && ClassUp_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageUpSE);
                    ClassUp_Flag = true;
                    StageNow++;
                }
            }







            //================================================================================================================================================================================================
            if (collision.gameObject.tag == "Down1")
            {
                UIDown_Flag = true;

                if ((Input.GetKey("down") || Input.GetKeyDown("joystick button 0")) && ClassDown_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageDownSE);
                    ClassDown_Flag = true;
                    StageNow--;
                }
            }
            if (collision.gameObject.tag == "Down1_1")
            {
                UIDown_Flag = true;

                if ((Input.GetKey("down") || Input.GetKeyDown("joystick button 0")) && ClassDown_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageDownSE);
                    ClassDown_Flag = true;
                    StageNow--;
                }
            }
            if (collision.gameObject.tag == "Down1_2")
            {
                UIDown_Flag = true;

                if ((Input.GetKey("down") || Input.GetKeyDown("joystick button 0")) && ClassDown_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageDownSE);
                    ClassDown_Flag = true;
                    StageNow--;
                }
            }
            if (collision.gameObject.tag == "Down1_3")
            {
                UIDown_Flag = true;

                if ((Input.GetKey("down") || Input.GetKeyDown("joystick button 0")) && ClassDown_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageDownSE);
                    ClassDown_Flag = true;
                    StageNow--;
                }
            }
            if (collision.gameObject.tag == "Down1_4")
            {
                UIDown_Flag = true;

                if ((Input.GetKey("down") || Input.GetKeyDown("joystick button 0")) && ClassDown_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageDownSE);
                    ClassDown_Flag = true;
                    StageNow--;
                }
            }
            if (collision.gameObject.tag == "Down1_5")
            {
                UIDown_Flag = true;

                if ((Input.GetKey("down") || Input.GetKeyDown("joystick button 0")) && ClassDown_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageDownSE);
                    ClassDown_Flag = true;
                    StageNow--;
                }
            }
            if (collision.gameObject.tag == "Down1_6")
            {
                UIDown_Flag = true;

                if ((Input.GetKey("down") || Input.GetKeyDown("joystick button 0")) && ClassDown_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageDownSE);
                    ClassDown_Flag = true;
                    StageNow--;
                }
            }

            //================================================================================================================================================================================================





            if (collision.gameObject.tag == "Down2")
            {
                UIDown_Flag = true;

                if ((Input.GetKey("down") || Input.GetKeyDown("joystick button 0")) && ClassDown_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageDownSE);
                    ClassDown_Flag = true;
                    StageNow--;
                }
            }
            if (collision.gameObject.tag == "Down2_1")
            {
                UIDown_Flag = true;

                if ((Input.GetKey("down") || Input.GetKeyDown("joystick button 0")) && ClassDown_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageDownSE);
                    ClassDown_Flag = true;
                    StageNow--;
                }
            }
            if (collision.gameObject.tag == "Down2_2")
            {
                UIDown_Flag = true;

                if ((Input.GetKey("down") || Input.GetKeyDown("joystick button 0")) && ClassDown_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageDownSE);
                    ClassDown_Flag = true;
                    StageNow--;
                }
            }
            if (collision.gameObject.tag == "Down2_3")
            {
                UIDown_Flag = true;

                if ((Input.GetKey("down") || Input.GetKeyDown("joystick button 0")) && ClassDown_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageDownSE);
                    ClassDown_Flag = true;
                    StageNow--;
                }
            }
            if (collision.gameObject.tag == "Down2_4")
            {
                UIDown_Flag = true;

                if ((Input.GetKey("down") || Input.GetKeyDown("joystick button 0")) && ClassDown_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageDownSE);
                    ClassDown_Flag = true;
                    StageNow--;
                }
            }
            if (collision.gameObject.tag == "Down2_5")
            {
                UIDown_Flag = true;

                if ((Input.GetKey("down") || Input.GetKeyDown("joystick button 0")) && ClassDown_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageDownSE);
                    ClassDown_Flag = true;
                    StageNow--;
                }
            }
            if (collision.gameObject.tag == "Down2_6")
            {
                UIDown_Flag = true;

                if ((Input.GetKey("down") || Input.GetKeyDown("joystick button 0")) && ClassDown_Flag == false && GroundCollision == true && WaterAction == false && GoalDoor.GoalFlag == false)
                {
                    this.aud.PlayOneShot(this.StageDownSE);
                    ClassDown_Flag = true;
                    StageNow--;
                }
            }
        }





        if (collision.gameObject.tag == "Goal")
        {
            GoalDoor.GoalFlag = true;
        }



        if (collision.gameObject.tag == "Normal" && KeyItemScript.key == false)
        {
            if (NotCloseSE_Flag == false)
            {
                this.aud.PlayOneShot(this.NotCloseSE);
                NotCloseSE_Flag = true;
            }
        }
        if (collision.gameObject.tag == "Normal" && KeyItemScript.key == true)
        {
            DoorRotate.RotateFlag = true;
            PlayerKeyDraw = false;
        }

        if (collision.gameObject.tag == "Reverse" && KeyItemScript.key == false)
        {
            if (NotCloseSE_Flag == false)
            {
                this.aud.PlayOneShot(this.NotCloseSE);
                NotCloseSE_Flag = true;
            }
        }
        if (collision.gameObject.tag == "Reverse" && KeyItemScript.key == true)
        {
            DoorRotate.RotateReverseFlag = true;
            PlayerKeyDraw = false;
        }



        if (collision.gameObject.tag == "Normal1" && KeyItemScript1.key == false)
        {
            if (NotCloseSE_Flag == false)
            {
                this.aud.PlayOneShot(this.NotCloseSE);
                NotCloseSE_Flag = true;
            }
        }
        if (collision.gameObject.tag == "Normal1" && KeyItemScript1.key == true)
        {
            DoorRotate1.RotateFlag = true;
            PlayerKeyDraw = false;
        }

        if (collision.gameObject.tag == "Reverse1" && KeyItemScript1.key == false)
        {
            if (NotCloseSE_Flag == false)
            {
                this.aud.PlayOneShot(this.NotCloseSE);
                NotCloseSE_Flag = true;
            }
        }
        if (collision.gameObject.tag == "Reverse1" && KeyItemScript1.key == true)
        {
            DoorRotate1.RotateReverseFlag = true;
            PlayerKeyDraw = false;
        }


        if (collision.gameObject.tag == "Normal2" && KeyItemScript2.key == false)
        {
            if (NotCloseSE_Flag == false)
            {
                this.aud.PlayOneShot(this.NotCloseSE);
                NotCloseSE_Flag = true;
            }
        }
        if (collision.gameObject.tag == "Normal2" && KeyItemScript2.key == true)
        {
            DoorRotate2.RotateFlag = true;
            PlayerKeyDraw = false;
        }

        if (collision.gameObject.tag == "Reverse2" && KeyItemScript2.key == false)
        {
            if (NotCloseSE_Flag == false)
            {
                this.aud.PlayOneShot(this.NotCloseSE);
                NotCloseSE_Flag = true;
            }
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
    }


    //ノット当たり判定トリガー
    void OnTriggerExit(Collider collision)
    {
        UIUp_Flag = false;
        UIDown_Flag = false;
        NoWaterMove = false;
        Text.gameObject.SetActive(false);
        FallDown = 0.0f;
        NotCloseSE_Flag = false;
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



        //MoveWall
        if ((collision.gameObject.tag == "MoveWall" && WallFlag0 == false) && PlayerDirection == 1)
        {
            Enemy2_Collision_Left = true;
            WallFlag0 = true;
            WallNo0 = true;
        }
        if ((collision.gameObject.tag == "MoveWall" && WallFlag0 == false) && PlayerDirection == -1)
        {
            Enemy2_Collision_Right = true;
            WallFlag0 = true;
            WallNo0 = true;
        }

        //MoveWall
        if ((collision.gameObject.tag == "MoveWall1" && WallFlag1 == false) && PlayerDirection == 1)
        {
            Enemy2_Collision_Left = true;
            WallFlag1 = true;
            WallNo1 = true;
        }
        if ((collision.gameObject.tag == "MoveWall1" && WallFlag1 == false) && PlayerDirection == -1)
        {
            Enemy2_Collision_Right = true;
            WallFlag1 = true;
            WallNo1 = true;
        }

        //MoveWall
        if ((collision.gameObject.tag == "MoveWall2" && WallFlag2 == false) && PlayerDirection == 1)
        {
            Enemy2_Collision_Left = true;
            WallFlag2 = true;
            WallNo2 = true;
        }
        if ((collision.gameObject.tag == "MoveWall2" && WallFlag2 == false) && PlayerDirection == -1)
        {
            Enemy2_Collision_Right = true;
            WallFlag2 = true;
            WallNo2 = true;
        }


        //MoveWall
        if ((collision.gameObject.tag == "MoveWall3" && WallFlag3 == false) && PlayerDirection == 1)
        {
            Enemy2_Collision_Left = true;
            WallFlag3 = true;
            WallNo3 = true;
        }
        if ((collision.gameObject.tag == "MoveWall3" && WallFlag3 == false) && PlayerDirection == -1)
        {
            Enemy2_Collision_Right = true;
            WallFlag3 = true;
            WallNo3 = true;
        }


        //MoveWall
        if ((collision.gameObject.tag == "MoveWall4" && WallFlag4 == false) && PlayerDirection == 1)
        {
            Enemy2_Collision_Left = true;
            WallFlag4 = true;
            WallNo4 = true;
        }
        if ((collision.gameObject.tag == "MoveWall4" && WallFlag4 == false) && PlayerDirection == -1)
        {
            Enemy2_Collision_Right = true;
            WallFlag4 = true;
            WallNo4 = true;
        }



        //MoveWall
        if ((collision.gameObject.tag == "MoveWall5" && WallFlag5 == false) && PlayerDirection == 1)
        {
            Enemy2_Collision_Left = true;
            WallFlag5 = true;
            WallNo5 = true;
        }
        if ((collision.gameObject.tag == "MoveWall5" && WallFlag5 == false) && PlayerDirection == -1)
        {
            Enemy2_Collision_Right = true;
            WallFlag5 = true;
            WallNo5 = true;
        }


        //MoveWall
        if ((collision.gameObject.tag == "MoveWall6" && WallFlag6 == false) && PlayerDirection == 1)
        {
            Enemy2_Collision_Left = true;
            WallFlag6 = true;
            WallNo6 = true;
        }
        if ((collision.gameObject.tag == "MoveWall6" && WallFlag6 == false) && PlayerDirection == -1)
        {
            Enemy2_Collision_Right = true;
            WallFlag6 = true;
            WallNo6 = true;
        }


        //MoveWall
        if ((collision.gameObject.tag == "MoveWall7" && WallFlag7 == false) && PlayerDirection == 1)
        {
            Enemy2_Collision_Left = true;
            WallFlag7 = true;
            WallNo7 = true;
        }
        if ((collision.gameObject.tag == "MoveWall7" && WallFlag7 == false) && PlayerDirection == -1)
        {
            Enemy2_Collision_Right = true;
            WallFlag7 = true;
            WallNo7 = true;
        }



        //MoveWall
        if ((collision.gameObject.tag == "MoveWall8" && WallFlag8 == false) && PlayerDirection == 1)
        {
            Enemy2_Collision_Left = true;
            WallFlag8 = true;
            WallNo8 = true;
        }
        if ((collision.gameObject.tag == "MoveWall8" && WallFlag8 == false) && PlayerDirection == -1)
        {
            Enemy2_Collision_Right = true;
            WallFlag8 = true;
            WallNo8 = true;
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

        WallFlag0 = false;
        WallNo0 = false;

        WallFlag1 = false;
        WallNo1 = false;

        WallFlag2 = false;
        WallNo2 = false;

        WallFlag3 = false;
        WallNo3 = false;

        WallFlag4 = false;
        WallNo4 = false;


        WallFlag5 = false;
        WallNo5 = false;


        WallFlag6 = false;
        WallNo6 = false;


        WallFlag7 = false;
        WallNo7 = false;


        WallFlag8 = false;
        WallNo8 = false;
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


