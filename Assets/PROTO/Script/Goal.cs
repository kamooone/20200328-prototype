using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour//プレイヤーがゴールに当たったらクリアシーンへ遷移
{

    // Start is called before the first frame update
    void Start()
    {
       // gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
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
