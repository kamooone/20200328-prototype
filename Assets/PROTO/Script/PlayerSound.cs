using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//足音スクリプト
public class PlayerSound : MonoBehaviour
{
    // Start is called before the first frame update

    //鳴らしたいSEを入れておく変数
    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audiosource;

    //判定用変数
    bool b_left = false;
    bool b_right = false;

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
    }

    // Update is called once per frame
    void Update()
    {
        script = water.GetComponent<VariableManager>(); //Waterの中にあるVariableManagerを取得して変数に格納する
        if (script.soundNo == 2)
        {
            audiosource.clip = sound2;
        }else
        {
            audiosource.clip = sound1;
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
