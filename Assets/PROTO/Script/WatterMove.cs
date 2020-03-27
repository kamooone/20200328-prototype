using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatterMove : MonoBehaviour //水の処理
{
    public float speed = 0.0005f;//自動で上に上がってくるスピード
    public float downspeed=-0.001f;//下げるときの距離

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*α版では特定のボタンを押したら水を下げる処理を入れるため(β版とかではなくす)*/
        if (Input.GetKey("down"))//右に移動
        {
            transform.Translate(0, downspeed, 0);//
        }
        else
        {
            transform.Translate(0, speed, 0);//自動上昇
        }
    }
}
