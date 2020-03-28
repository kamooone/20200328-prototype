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

    void OnTriggerStay(Collider collision)//Enter(衝突した瞬間)からStay(触れている間)に変更
    {
        if (collision.gameObject.tag == "Player")//プレイヤータグとぶつかっている間
        {
            Debug.Log("ワープ");
            if (Input.GetKey("up"))//上キーを押したら
            {
                collision.gameObject.transform.position = new Vector3(pos.x, pos.y + 0.28f, pos.z);//ワープ先まで座標変換
            }
        }
    }
}
