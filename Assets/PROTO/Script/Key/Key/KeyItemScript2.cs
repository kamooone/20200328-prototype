﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemScript2 : MonoBehaviour
{
    //鍵取得判定
    public static bool key = false;

    public GameObject Player;
    

    // Start is called before the first frame update
    void Start()
    {
        key = false;
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("鍵衝突");
            gameObject.SetActive(false);
            key = true;
            PlayerMove.PlayerKeyDraw = true;
        }
    }

}
