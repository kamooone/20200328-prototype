using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 必要なコンポーネントの列記
[RequireComponent(typeof(Animator))]

public class Enemy2_3Move : MonoBehaviour//敵の移動処理(本来はまとめてやる)
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

    public static bool hasigocollision = false;
    public static bool hasigocollision1 = false;
    public static bool hasigocollision2 = false;
    public static bool hasigocollision3 = false;
    public static bool hasigocollision4 = false;
    public static bool hasigocollision5 = false;
    public static bool hasigocollision6 = false;

    public AudioClip WalkSE;
    AudioSource aud;
    int SETime = 0;

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
        PlayerMove.GameClearFlag = false;
        PlayerMove.WaterAction = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Animatorのモーション再生速度に animSpeedを設定する
        anim.speed = animSpeed;

        // 参照用のステート変数にBase Layer (0)の現在のステートを設定する
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);

        //三階の水の高さ取得
        WaterHight = PlayerScript.WaterHight3;

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

        if (PlayerMove.GameClearFlag == false && PlayerMove.WaterAction == false)
        {
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
        if (collision.gameObject.tag == "StageDown2" || collision.gameObject.tag == "Down2")
        {
            hasigocollision = true;
        }
        if (collision.gameObject.tag == "StageDown2_1" || collision.gameObject.tag == "Down2_1")
        {
            hasigocollision1 = true;
        }
        if (collision.gameObject.tag == "StageDown2_2" || collision.gameObject.tag == "Down2_2")
        {
            hasigocollision2 = true;
        }
        if (collision.gameObject.tag == "StageDown2_3" || collision.gameObject.tag == "Down2_3")
        {
            hasigocollision3 = true;
        }
        if (collision.gameObject.tag == "StageDown2_4" || collision.gameObject.tag == "Down2_4")
        {
            hasigocollision4 = true;
        }
        if (collision.gameObject.tag == "StageDown2_5" || collision.gameObject.tag == "Down2_5")
        {
            hasigocollision5 = true;
        }
        if (collision.gameObject.tag == "StageDown2_6" || collision.gameObject.tag == "Down2_6")
        {
            hasigocollision6 = true;
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
        hasigocollision = false;
        hasigocollision1 = false;
        hasigocollision2 = false;
        hasigocollision3 = false;
        hasigocollision4 = false;
        hasigocollision5 = false;
        hasigocollision6 = false;

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

        if (collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Enemy" && WaterHight == 0.11f && doorcollision == false)
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
