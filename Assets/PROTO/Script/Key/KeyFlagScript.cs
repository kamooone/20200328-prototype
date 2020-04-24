using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyFlagScript : MonoBehaviour
{
    public GameObject KeyObj;

    // Start is called before the first frame update
    void Start()
    {
        //keyobjコンポーネントの取得
        //KeyObj = GameObject.Find("player/Key").GetComponent<GameObject>();
        KeyItemScript.key = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (KeyItemScript.key==true)
        {
            KeyObj.gameObject.SetActive(true);
        }
    }
}
