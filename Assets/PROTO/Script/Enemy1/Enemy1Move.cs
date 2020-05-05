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

    //エネミーの向き
    int direction = 1;

    //方向チェンジ時の角度
    float radian = 180.0f;

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
        anim.speed = FireGenerated1.AnimSpeed;

        /*移動処理*/
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
    }

    //当たり判定トリガー
    void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Flip")
        {
            direction *= -1;
        }
    }


    //当たり判定当たっている間
    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Fall")
        {
            Debug.Log("階層ダウン");

            transform.position = new Vector3(transform.position.x, transform.position.y + Down, transform.position.z);

            Down -= 0.01f; 
            
        }
    }



    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
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




