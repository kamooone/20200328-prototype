using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallActive2 : MonoBehaviour
{
    GameObject PlayerObject;
    PlayerMove PlayerScript;

    public GameObject FallObject;

    //各層の水の高さ取得
    float WaterHight;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.Find("player");
        PlayerScript = PlayerObject.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        //一階の水の高さ取得
        WaterHight = PlayerScript.WaterHight2;


        //水の判定
        if (WaterHight == 0.11f)
        {
            FallObject.gameObject.SetActive(false);
        }

        if (WaterHight == 0.0f || WaterHight == -0.11f)
        {
            FallObject.gameObject.SetActive(true);
        }

    }
}
