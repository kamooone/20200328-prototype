
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement; //LoadSceneを使うために必要

public class AnimationStateController : MonoBehaviour
{
    GameObject CameraObject;
    CameraMove CameraScript;

    GameObject FadeObject;
    GameFade GameFadeScript;

    Rigidbody rigid3D;

    //float jumpForce = 400.0f;

    int key = 0;



    // 初期化
    void Start()
    {
        this.rigid3D = GetComponent<Rigidbody>();

        CameraObject = GameObject.Find("MainCamera");
        CameraScript = CameraObject.GetComponent<CameraMove>();

        FadeObject = GameObject.Find("Panel");
        GameFadeScript = FadeObject.GetComponent<GameFade>();
    }


    // 以下、メイン処理.リジッドボディと絡めるので、FixedUpdate内で処理を行う.
    void FixedUpdate()
    {
        
    }

    void Update()
    {
        if (GameFadeScript.GameFlag == true)
        {
            GameFadeScript.Fade_in();

            //ジャンプする
            //if (Input.GetKeyDown(KeyCode.Space) && this.rigid3D.velocity.y == 0)
            //{
            //    this.rigid3D.AddForce(transform.up * this.jumpForce);
            //}

            // 左右のキー入力でキャラクタを反転
            if (Input.GetKey(KeyCode.A) && CameraScript.CollisionFlag_Left == false)
            {
                key = -1;
                Vector3 axis = transform.TransformDirection(Vector3.up);
                transform.RotateAround(CameraScript.target.position, axis, CameraScript.speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D) && CameraScript.CollisionFlag_Right == false)
            {
                key = 1;
                Vector3 axis = transform.TransformDirection(Vector3.down);
                transform.RotateAround(CameraScript.target.position, axis, CameraScript.speed * Time.deltaTime);
            }

            //反射対策
            if (key != 0)
            {
                transform.localScale = new Vector3(key, 1, 1);
            }
        }

        //クリア画面へ(フェードアウト)
        if (GameFadeScript.GameFlag == false)
        {
            GameFadeScript.Fade_out_White();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Brock")
        {
            if (key == -1)
            {
                CameraScript.CollisionFlag_Left = true;
                CameraScript.Rotate_Left();
            }

            if (key == 1)
            {
                CameraScript.CollisionFlag_Right = true;
                CameraScript.Rotate_Right();
            }
            Debug.Log("コリジョン");
        }

        if (other.gameObject.tag == "ClearScene")
        {
            GameFadeScript.GameFlag = false;
        }
    }

    void OnCollisionExit(Collision other)
    {
        CameraScript.CollisionFlag_Right = false;
        CameraScript.CollisionFlag_Left = false;
        CameraScript.NoCollision();
        Debug.Log("NOコリジョン");
    }
}