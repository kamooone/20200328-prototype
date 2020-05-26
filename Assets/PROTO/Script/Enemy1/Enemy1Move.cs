using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 必要なコンポーネントの列記
[RequireComponent(typeof(Animator))]

public class Enemy1Move : MonoBehaviour
{
    // キャラにアタッチされるアニメーターへの参照
    private Animator anim;

    // base layerで使われる、アニメーターの現在の状態の参照
    private AnimatorStateInfo currentBaseState;


    // アニメーター各ステートへの参照
    //static int locoState = Animator.StringToHash("Base Layer.walk");
    //static int jumpState = Animator.StringToHash("Base Layer.climb");
    //static int restState = Animator.StringToHash("Base Layer.Rest");

    // アニメーション再生速度設定
    //float FastSpeed = 4.0f;
    //float SlowSpeed = 1.0f;

    public Transform target;

    GameObject Enemy;

    //float speed = 10.0f;

    float Down = 0.0f;

    public static bool TuiFlag = false;
    bool walkFlag_Left = false;
    bool walkFlag_Right = false;

    //エネミーの向き
    int direction = 1;

    //方向チェンジ時の角度
    float radian = 180.0f;

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
        // Animatorコンポーネントを取得する
        anim = GetComponent<Animator>();

        // Animatorのモーション再生速度に animSpeedを設定する
        anim.speed = 1.0f;

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
        anim.speed = FireGenerated1.AnimSpeed;

        /*移動処理*/
        if (TuiFlag == true)
        {
            if (walkFlag_Right == true)
            {
                direction = -1;
                if (radian != -180.0f)
                {
                    radian = -180.0f;
                    transform.Rotate(new Vector3(0f, radian, 0f));
                }

                Vector3 axis = transform.TransformDirection(Vector3.down);
                transform.RotateAround(target.position, axis, FireGenerated1.speed * Time.deltaTime);
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
                transform.RotateAround(target.position, axis, FireGenerated1.speed * Time.deltaTime);
            }
        }



        if (TuiFlag == false)
        {
            if (direction == -1)
            {
                if (radian != -180.0f)
                {
                    radian = -180.0f;
                    transform.Rotate(new Vector3(0f, radian, 0f));
                }

                Vector3 axis = transform.TransformDirection(Vector3.down);
                transform.RotateAround(target.position, axis, FireGenerated1.speed * Time.deltaTime);
            }

            if (direction == 1)
            {
                if (radian != 180.0f)
                {
                    radian = 180.0f;
                    transform.Rotate(new Vector3(0f, radian, 0f));
                }

                Vector3 axis = transform.TransformDirection(Vector3.up);
                transform.RotateAround(target.position, axis, FireGenerated1.speed * Time.deltaTime);
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
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("ゲームオーバー");
            SceneManager.LoadScene("GameOverScene");
        }

        if (collision.gameObject.tag == "Enemy2" || collision.gameObject.tag == "Enemy")
        {
            direction *= -1;
        }

        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Door")
        {
            direction *= -1;
        }
    }

}




