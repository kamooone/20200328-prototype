using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemScript1 : MonoBehaviour
{
    //鍵取得判定
    public static bool key = false;

    public GameObject Player;

    float position_x = 0.3f;
    float position_z = 0.25f;

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
