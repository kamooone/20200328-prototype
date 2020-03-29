using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove : MonoBehaviour//敵の移動処理(本来はまとめてやる)
{
    public Transform target;//中心となるオブジェクト
    float speed = 10;//移動速度

    SpriteRenderer MainSpriteRenderer;//描画する画像

    int direction = 2;

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
        if(direction == 1)
        {
            MainSpriteRenderer.sprite = Right;
            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, speed * Time.deltaTime);
        }
        if (direction == 2)
        {
            MainSpriteRenderer.sprite = Left;
            Vector3 axis = transform.TransformDirection(Vector3.up);
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
