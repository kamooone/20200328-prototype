using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour//上る処理
{
    public Transform Warptarget;//ワープする行き先
    private Vector3 pos;//ワープ先の座標

    // Start is called before the first frame update
    void Start()
    {
        /*ワープ先の座標取得*/
        pos.x = Warptarget.position.x;
        pos.y = Warptarget.position.y;
        pos.z = Warptarget.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")//プレイヤータグとぶつかったら
        {
            collision.gameObject.transform.position = new Vector3(pos.x, pos.y+0.28f, pos.z );//ワープ先まで座標変換
        }
    }
}
