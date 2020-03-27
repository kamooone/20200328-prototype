using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emptyobjectmove : MonoBehaviour//3Dのオブジェクトの移動処理(3D同士の当たり判定を行うため(プロトタイプなどはプレイヤーが2Dであったため))あとこちらで実際には動かしている
{
    public float speed = 10.0f;//移動速度
    private float move;//移動
    public Transform target;//中心となるオブジェクト
   

    // Start is called before the first frame update
    void Start()
    {
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
