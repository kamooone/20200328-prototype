using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{
    GameObject Player;
    GameObject mainCamera;

    GameObject FadeObject;
    GameFade GameFadeScript;

    /// <summary>
    /// 他スクリプトと共有する場合はpublicに
    /// </summary>


    //移動フラグ
    public bool CollisionFlag_Right = false;
    public bool CollisionFlag_Left = false;

    // 回転の中心になるオブジェクト
    public Transform target;

    // 回転速度
    public float speed = 30.0f;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.Find("Player");
        mainCamera = GameObject.Find("MainCamera");

        FadeObject = GameObject.Find("Panel");
        GameFadeScript = FadeObject.GetComponent<GameFade>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameFadeScript.GameFlag == true)
        {
            // カメラ追従
            if (Input.GetKey(KeyCode.A) && CollisionFlag_Left == false)
            {
                Vector3 axis = transform.TransformDirection(Vector3.up);
                transform.RotateAround(target.position, axis, speed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.D) && CollisionFlag_Right == false)
            {
                Vector3 axis = transform.TransformDirection(Vector3.down);
                transform.RotateAround(target.position, axis, speed * Time.deltaTime);
            }
        }

        mainCamera.transform.position = new Vector3
            (mainCamera.transform.position.x, mainCamera.transform.position.y,
             mainCamera.transform.position.z);

    }


    //当たり判定検知
    public void Rotate_Right()
    {
        CollisionFlag_Right = true;
    }
    public void Rotate_Left()
    {
        CollisionFlag_Left = true;
    }

    //当たっていないとき検知
    public void NoCollision()
    {
        CollisionFlag_Right = false;
        CollisionFlag_Left = false;
    }
}