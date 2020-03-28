using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp2 : MonoBehaviour//上る処理
{
    public Transform Warptarget2;//ワープする行き先
    private Vector3 pos2;//ワープ先の座標

    // Start is called before the first frame update
    void Start()
    {
        /*ワープ先の座標取得*/
        pos2.x = Warptarget2.position.x;
        pos2.y = Warptarget2.position.y;
        pos2.z = Warptarget2.position.z;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionStay(Collision collision)//Enter(衝突した瞬間)からStay(触れている間)に変更
    {
        if (collision.gameObject.tag == "Player")//プレイヤータグとぶつかっている間
        {
            if (Input.GetKey("down"))//下キーを押したら
            {
                collision.gameObject.transform.position = new Vector3(pos2.x, pos2.y+0.28f, pos2.z);//ワープ先まで座標変換
            }
        }
    }
}