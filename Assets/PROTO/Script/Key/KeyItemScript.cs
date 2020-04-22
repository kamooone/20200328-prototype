using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemScript : MonoBehaviour
{
    //鍵取得判定
    public static bool key = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameObject.SetActive(false);
            key = true;
        }
    }

}
