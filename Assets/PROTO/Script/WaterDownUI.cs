using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDownUI : MonoBehaviour//水を下げる処理
{
    public GameObject gameobj;
    public float y;//減少させる値

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameobj.transform.localScale.y < 0.05)//倍率が0.05以下になったら0.05にする
        {
            gameobj.transform.localScale = new Vector3(gameobj.transform.localScale.x, 0.05f, gameobj.transform.localScale.z);
        }
    }

    //ボタンをクリックした時の処理
    public void OnClick()
    {
        gameobj.transform.localScale += new Vector3(0, y, 0);
    }
}
