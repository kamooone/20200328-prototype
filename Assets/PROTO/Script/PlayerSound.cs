using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    // Start is called before the first frame update

    //鳴らしたいSEを入れておく変数
    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audiosource;

    void Start()
    {
        //コンポーネントを取得
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = sound1;
    }

    void OnCollisionStay(Collision collision)
    {
        Debug.Log(collision.gameObject.name); // ログを表示する
    }

    // Update is called once per frame
    void Update()
    {
        //AキーまたはDキーが押されたらSEを再生する
        if (Input.GetKeyDown("left")|| Input.GetKeyDown("right"))
        {
            audiosource.Play();
        }

        //AキーまたはDキーから手が離れたらSEを停止させる
        if (Input.GetKeyUp("left")|| Input.GetKeyUp("right"))
        {
            audiosource.Stop();
        }
    }
}
