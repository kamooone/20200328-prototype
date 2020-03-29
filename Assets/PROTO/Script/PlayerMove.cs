using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour//プレイヤー移動処理(現在は2Dなので画像切り替えの処理のみ)
{

    public float speed = 10.0f;

    public Transform target;//中心となるオブジェクト

    SpriteRenderer MainSpriteRenderer;//描画する画像

    public Sprite Right;//右向き画像
    public Sprite Left;//左向き画像

    // Start is called before the first frame update
    void Start()
    {
        MainSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();//
    }

    // Update is called once per frame
    void Update()
    {
        /*画像切り替え処理*/
        if (Input.GetKey("left"))//左に移動
        {
            MainSpriteRenderer.sprite = Left;
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, speed * Time.deltaTime);
        }
        if (Input.GetKey("right"))//右に移動
        {
            MainSpriteRenderer.sprite = Right;
            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, speed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")//プレイヤータグとぶつかったら
        {
            SceneManager.LoadScene("EndScene");//終了シーンへ移動
        }
    }
}


