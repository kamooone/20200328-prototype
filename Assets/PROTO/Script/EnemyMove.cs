using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour//敵の移動処理(本来はまとめてやる)
{
    public Transform target;//中心となるオブジェクト
    public float speed;//移動速度

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
        if (speed <= 0)//右回りだったら
        {
            MainSpriteRenderer.sprite = Right;
        }
        else//左回りだったら
        {
            MainSpriteRenderer.sprite = Left;
        }

        transform.RotateAround(target.position, Vector3.up, speed * Time.deltaTime);//オブジェクト周りにY軸回転しながら移動

    }
}
