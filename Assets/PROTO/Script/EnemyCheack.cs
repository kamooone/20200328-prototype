using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyCheack : MonoBehaviour//敵の当たり判定処理
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")//プレイヤータグとぶつかったら
        {
            SceneManager.LoadScene("EndScene");//終了シーンへ移動
        }
    }
}
