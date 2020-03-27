using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour//プレイヤー移動処理(現在は2Dなので画像切り替えの処理のみ)
{
    //public float speed = 10.0f;//移動速度
    //private float move;//移動
   // public Transform target;//中心となるオブジェクト
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
        /*移動処理*/
        //if (move != 0)//もし移動が0以上だったら
        //{
        //    move = 0;
        //}

        /*画像切り替え処理*/
        if (Input.GetKey("right"))//右に移動
        {
           // move = -speed;
            MainSpriteRenderer.sprite = Right;
        }

        if (Input.GetKey("left"))//左に移動
        {
           // move = speed;
            MainSpriteRenderer.sprite = Left;
        }

      //  transform.RotateAround(target.position, Vector3.up, move * Time.deltaTime);//オブジェクト周りにY軸回転しながら移動

    }
    

}


