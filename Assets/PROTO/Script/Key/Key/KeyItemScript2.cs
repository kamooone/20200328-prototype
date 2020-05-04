using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyItemScript2 : MonoBehaviour
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

    // Update is called once per frame
    void Update()
    {
        if (PlayerMove.PlayerDirection == 1)
        {
            position_x = -0.3f;
            position_z = -0.25f;
        }
        if (PlayerMove.PlayerDirection == -1)
        {
            position_x = 0.3f;
            position_z = 0.25f;
        }

        //位置は仮(マスターは子オブジェにして追従させる)
        if (key == true)
        {
            transform.position = new Vector3((Player.transform.position.x - position_x), (Player.transform.position.y + 0.3f), (Player.transform.position.z + position_z));
        }

        if (DoorRotate2.KeyDestroy == true)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("鍵衝突");
            key = true;
        }
    }

}
