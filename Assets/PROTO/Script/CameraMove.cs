using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMove : MonoBehaviour//カメラ移動処理
{
    public float speed = 10.0f;//移動速度
    private float move;//移動
    public Transform target;//中心となるオブジェクト

    // Use this for initialization
    void Start()
    {
        /*もしかしたらプレイヤーの動きに合わせてのカメラ移動の可能性もあるからひとまずはコマンド入力で移動するだけの処理にしてる
        //target = GameObject.FindWithTag("Player").transform;
        //Vector3 pos;
        //pos.x = target.position.x;
        //pos.y = target.position.y;
        //pos.z = target.position.z;
        //this.gameObject.transform.position = new Vector3(pos.x, pos.y, pos.z-5);
        */

    }

    // Update is called once per frame
    void Update()
    {
        /*移動処理*/
        if (move != 0)//もし移動が0以上だったら
        {
            move = 0;
        }

        if (Input.GetKey("right"))//右に移動
        {
            move = -speed;
        }

        if (Input.GetKey("left"))//左に移動
        {
            move = speed;
        }

        transform.RotateAround(target.position, Vector3.up, move * Time.deltaTime);//オブジェクト周りにY軸回転しながら移動

    }
}