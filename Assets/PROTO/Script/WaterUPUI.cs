using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterUPUI : MonoBehaviour//水を上げる処理
{
    public GameObject gameobj;
    public float y;//上昇させる値

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameobj.transform.localScale.y > 0.5)//倍率が0.5以上になったら0.05にする
        {
            gameobj.transform.localScale = new Vector3(gameobj.transform.localScale.x, 0.5f, gameobj.transform.localScale.z);
        }
    }

    //ボタンをクリックした時の処理
    public void OnClick()
    {
        gameobj.transform.localScale += new Vector3(0, y, 0);
    }

}
