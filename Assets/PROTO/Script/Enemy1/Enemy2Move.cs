using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


// 必要なコンポーネントの列記
[RequireComponent(typeof(Animator))]


public class Enemy2Move : MonoBehaviour
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

    //エネミーの向き
    int direction = 1;

    //方向チェンジ時の角度
    float radian = 180.0f;

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

    // Start is called before the first frame update
    void Start()
    {
        // Animatorコンポーネントを取得する
        anim = GetComponent<Animator>();

        // Animatorのモーション再生速度に animSpeedを設定する
        anim.speed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        anim.speed = FireGenerated2.AnimSpeed;


        /*移動処理*/
        if (direction == 1)
        {
            if (radian != 180.0f)
            {
                radian = 180.0f;
                transform.Rotate(new Vector3(0f, radian, 0f));
            }

            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, FireGenerated2.speed * Time.deltaTime);
        }

        if (direction == -1)
        {
            if (radian != -180.0f)
            {
                radian = -180.0f;
                transform.Rotate(new Vector3(0f, radian, 0f));
            }

            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, FireGenerated2.speed * Time.deltaTime);
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




