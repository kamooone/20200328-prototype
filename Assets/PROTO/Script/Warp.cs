using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour//上る処理
{
    GameObject PlayerObject;
    PlayerMove PlayerScript;

    GameObject CameraObject;
    CameraMove CameraScript;

    bool ClassUp_Flag = false;
    float up = 0.0f;

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
        if (ClassUp_Flag == true)
        {
            //上の階層へ
            ClassUp();
        }
    }

    void OnTriggerStay(Collider collision)//Enter(衝突した瞬間)からStay(触れている間)に変更
    {
        if (collision.gameObject.tag == "Player")//プレイヤータグとぶつかっている間
        {
            if (Input.GetKey("up"))//上キーを押したら
            {
                ClassUp_Flag = true;
            }
        }
    }


    void ClassUp()
    {
        Debug.Log("ワープ");

        PlayerObject.transform.position =
            new Vector3(PlayerScript.transform.position.x, PlayerScript.transform.position.y + up,
            PlayerScript.transform.position.z);
        if (up < 0.28f) { up += 0.04f; }
        if (up >= 0.28f)
        {
            up = 0.0f;
            ClassUp_Flag = false;
        }
    }

}
