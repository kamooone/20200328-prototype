using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//足音スクリプト
public class PlayerSound : MonoBehaviour
{
    // Start is called before the first frame update

    //鳴らしたいSEを入れておく変数
    public      AudioClip sound1;
    public      AudioClip sound2;
    AudioSource audiosource;

    //判定用変数
    bool        b_left = false;
    bool        b_right = false;

    //SEが変更されたのを感知するための変数
    int         presound = 0;   //サウンド番号管理用(元々のサウンド番号)
    int         sound = 1;      //サウンド番号管理用(変更がかかったサウンド番号) 
    
    //waterそのものが入る変数
    GameObject water;

    //VariableManagerスクリプトが入る変数
    VariableManager script; 

    void Start()
    {
        //コンポーネントを取得
        audiosource = GetComponent<AudioSource>();
        audiosource.clip = sound1;

        water = GameObject.Find("Water"); //Waterをオブジェクトの名前から取得して変数に格納する
        script = water.GetComponent<VariableManager>(); //Waterの中にあるVariableManagerを取得して変数に格納する
    }

    // Update is called once per frame
    void Update()
    {
        script = water.GetComponent<VariableManager>(); //Waterの中にあるVariableManagerを取得して変数に格納する

        presound = sound;   //元々のサウンド番号を覚えておく

        //足音の切り替え処理
        if (script.soundNo == 1)
        {
            //通常足音
            Debug.Log("通常"); // ログを表示する
            audiosource.clip = sound1;
            sound = 1;
        }

        if (script.soundNo == 2)
        {
            //水面足音
            Debug.Log("水面"); // ログを表示する
            audiosource.clip = sound2;
            sound = 2;
        }
        

        //AキーまたはDキーが押されたらSEを再生する
        if (Input.GetKeyDown("left"))
        {
            audiosource.Play(); //再生
            b_left = true;      //左キーが押されたtrueに
            
        }

        if (Input.GetKeyDown("right"))
        {
            audiosource.Play(); //再生
            b_right = true;     //右キーが押されたらtrueに
           
        }

        //サウンドが切り替わりなおかつキーが押された判定なら音を一旦停止させ再度再生する
        if (presound != sound && b_right == true || presound != sound && b_left == true) 
        {
            audiosource.Stop();
            Debug.Log("音声が変わったのでストップ"); // ログを表示する
            if (b_left == true || b_right == true)
            {
                audiosource.Play();
                Debug.Log("キーが押された判定なら再生"); // ログを表示する
            }

        }

        //AキーまたはDキーから手が離れたらSEを停止させる
        if (Input.GetKeyUp("left"))
        {
            b_left = false;
            audiosource.Stop();     //停止
            if (b_right == true)    //左キーが離れた際に右キーが押されていたら
            {
                audiosource.Play(); //再生
            }
        }

        if(Input.GetKeyUp("right"))
        {
            b_right = false;
            audiosource.Stop();     //停止
            if (b_left == true)     //右キーが離れた際に左キーが押されていたら
            {
                audiosource.Play(); //再生
            }
        }
    }
}
