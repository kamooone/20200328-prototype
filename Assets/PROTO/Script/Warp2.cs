using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp2 : MonoBehaviour//上る処理
{
    GameObject PlayerObject;
    PlayerMove PlayerScript;

    GameObject CameraObject;
    CameraMove CameraScript;

    bool ClassDown_Flag = false;
    float Down = 0.28f;

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.Find("player");
        PlayerScript = PlayerObject.GetComponent<PlayerMove>();

        CameraObject = GameObject.Find("MainCamera");
        CameraScript = CameraObject.GetComponent<CameraMove>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ClassDown_Flag == true)
        {
            //下の階層へ
            ClassDown();
        }
    }

    void OnTriggerStay(Collider collision)//Enter(衝突した瞬間)からStay(触れている間)に変更
    {
        if (collision.gameObject.tag == "Player")//プレイヤータグとぶつかっている間
        {
            if (Input.GetKey("down"))
            {
                ClassDown_Flag = true;
            }
        }
    }


    void ClassDown()
    {
        Debug.Log("ワープ");

        PlayerObject.transform.position =
            new Vector3(PlayerScript.transform.position.x, PlayerScript.transform.position.y - Down,
            PlayerScript.transform.position.z);
        if (Down > 0.0f) { Down -= 0.04f; }
        if (Down <= 0.0f)
        {
            Down = 0.28f;
            ClassDown_Flag = false;
        }
    }

}
