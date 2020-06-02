using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 必要なコンポーネントの列記
[RequireComponent(typeof(Animator))]

public class Enemy2_2Move : MonoBehaviour//敵の移動処理(本来はまとめてやる)
{
    GameObject PlayerObject;
    PlayerMove PlayerScript;

    public Transform target;

    float speed = 7.0f;

    //エネミーの向き(1が左-1が右)
    public static int direction = -1;

    //方向チェンジ時の角度
    float radian = -180.0f;

    public static bool TuiFlag = false;
    public static bool walkFlag_Left = false;
    public static bool walkFlag_Right = false;

    public static bool doorcollision = false;

    // キャラにアタッチされるアニメーターへの参照
    private Animator anim;

    // base layerで使われる、アニメーターの現在の状態の参照
    private AnimatorStateInfo currentBaseState;


    // アニメーター各ステートへの参照
    static int locoState = Animator.StringToHash("Base Layer.up");
    static int jumpState = Animator.StringToHash("Base Layer.down");

    // アニメーション再生速度設定
    float animSpeed = 1.0f;

    public static bool walkflag = true;
    int walkflagTime = 0;

    //各層の水の高さ取得
    public static float WaterHight;

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

    public AudioClip WalkSE;
    AudioSource aud;
    int SETime = 0;

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

        // Animatorコンポーネントを取得する
        anim = GetComponent<Animator>();

        this.aud = GetComponent<AudioSource>();
        SETime = 0;

        TuiFlag = false;
        walkFlag_Left = false;
        walkFlag_Right = false;

        doorcollision = false;

        direction = -1;

        PlayerMove.GameOverFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Animatorのモーション再生速度に animSpeedを設定する
        anim.speed = animSpeed;

        // 参照用のステート変数にBase Layer (0)の現在のステートを設定する
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);



        //二階の水の高さ取得
        WaterHight = PlayerScript.WaterHight2;

        //水の判定
        if (WaterHight == 0.11f && walkflag == false)
        {
            anim.SetBool("up", true);
            if (walkflagTime == 600)
            {
                walkflag = true;
                walkflagTime = 0;
                anim.SetBool("up", false);
                anim.SetBool("down", false);
            }
            walkflagTime++;
        }

        if (walkflag == true)
        {
            if (TuiFlag == false)
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


            if (TuiFlag == true)
            {
                if (SETime == 0)
                {
                    this.aud.PlayOneShot(this.WalkSE);
                }
                if (SETime < 15)
                {
                    SETime++;
                }
                if (SETime == 15)
                {
                    SETime = 0;
                }
            }


            if (TuiFlag == true && doorcollision == false && PlayerMove.GameOverFlag == false)
            {
                /*移動処理*/
                if (walkFlag_Right == true)
                {
                    direction = -1;

                    if (radian != -180.0f)
                    {
                        radian = -180.0f;
                        transform.Rotate(new Vector3(0f, radian, 0f));
                    }

                    Vector3 axis = transform.TransformDirection(Vector3.down);
                    transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                }

                if (walkFlag_Left == true)
                {
                    direction = 1;

                    if (radian != 180.0f)
                    {
                        radian = 180.0f;
                        transform.Rotate(new Vector3(0f, radian, 0f));
                    }

                    Vector3 axis = transform.TransformDirection(Vector3.up);
                    transform.RotateAround(target.position, axis, speed * Time.deltaTime);
                }
            }
        }

        if (WaterHight == 0.0f || WaterHight == -0.11f)
        {
            walkflag = false;
            anim.SetBool("up", false);
            anim.SetBool("down", true);     // Animatorにジャンプに切り替えるフラグを送る
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

        if (collision.gameObject.tag == "Tui_L")
        {
            walkFlag_Left = true;
            TuiFlag = true;
        }

        if (collision.gameObject.tag == "Tui_R")
        {
            walkFlag_Right = true;
            TuiFlag = true;
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

        walkFlag_Left = false;
        walkFlag_Right = false;
        TuiFlag = false;
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && walkflag == true)
        {
            //Debug.Log("ゲームオーバー");
            //SceneManager.LoadScene("GameOverScene");
            PlayerMove.GameOverFlag = true;
        }

        if (collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Enemy" && WaterHight == 0.11f)
        {
            direction *= -1;
        }

        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Door" || collision.gameObject.tag == "MoveWall"
             || collision.gameObject.tag == "MoveWall1" || collision.gameObject.tag == "MoveWall2" || collision.gameObject.tag == "MoveWall3"
              || collision.gameObject.tag == "MoveWall4" || collision.gameObject.tag == "MoveWall5" || collision.gameObject.tag == "MoveWall6"
               || collision.gameObject.tag == "MoveWall7" || collision.gameObject.tag == "MoveWall8" && WaterHight == 0.11f)
        {
            direction *= -1;
            doorcollision = true;
        }
    }
    void OnCollisionExit(Collision collision)
    {
        doorcollision = false;
    }

}
