using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterUPUI : MonoBehaviour//水を上げる処理
{
    public GameObject gameobj;//上昇させたいオブジェクト
    public GameObject next_gameobj;//目標のゲームオブジェクト(次の階層のゲームオブジェクト)
    Transform myTransform;//transform取得

    // Start is called before the first frame update
    void Start()
    {
        myTransform = gameobj.transform;//初期座標取得
    }

    // Update is called once per frame
    void Update()
    {
        myTransform = gameobj.transform;///更新座標
    }

    //ボタンをクリックした時の処理
    public void OnClick()
    {
        Vector3 localpos = myTransform.localPosition;//ローカル座標

        if (localpos.y!=next_gameobj.transform.position.y)//上昇してなかったら
        {
            localpos.y = next_gameobj.transform.position.y;//目標のオブジェクトのy座標に移動
            myTransform.localPosition = localpos;//座標を設定
        }
        else//上昇してたら変更なし
        {

        }
    }

}
