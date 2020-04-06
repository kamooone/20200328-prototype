using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//変数管理スクリプト
public class VariableManager : MonoBehaviour
{
    public int soundNo = 1;

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
            soundNo = 2;
            //Debug.Log(collider.gameObject.name); // ログを表示する
        }else
        {
            soundNo = 1;
        }
    }
}
