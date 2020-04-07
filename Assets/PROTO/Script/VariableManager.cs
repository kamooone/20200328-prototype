using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//変数管理スクリプト
public class VariableManager : MonoBehaviour
{
    public int soundNo = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //重なり判定　重なっている間
    void OnTriggerStay(Collider collider)
    {
        //重なっているのが名前"player"なら
        if (collider.gameObject.name == "player")
        {
            soundNo = 2;    //水面足音
        }else
        {
            soundNo = 1;    //通常足音
        }
    }
}
