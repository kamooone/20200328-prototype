using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashesGenerated3 : MonoBehaviour//水しぶき生成と消滅
{
    GameObject PlayerObject;
    PlayerMove PlayerScript;

    //水の高さ取得
    float WaterHight;

    /*パーティクル関係宣言*/
    private GameObject Particle;//出現させる水しぶきのパーティクル(prefab科しているためGameObject宣言)

    [SerializeField]
    private GameObject EnemyObj;//親になる透明な敵
    private GameObject ChildObj;//実際の水しぶきのパーティクルの場所

    private bool Generated;//出現してるか


    // Start is called before the first frame update
    void Start()
    {
        Particle = (GameObject)Resources.Load("Particle/Splashes");//ResourcesフォルダのFireパーティクルを出現する
        Generated = false;//出現していない

        PlayerObject = GameObject.Find("player");
        PlayerScript = PlayerObject.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        //二階の水の高さ取得
        WaterHight = PlayerScript.WaterHight3;

        //水の判定
        if (WaterHight == 0.11f)
        {
            if (Generated == false)//出現していなかったら生成する
            {
                //ChildObj = Instantiate(Particle, this.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
                ChildObj = (GameObject)Instantiate(Particle);
                ChildObj.transform.parent = EnemyObj.transform;//指定したオブジェクトと親子関係
                Generated = true;//出現している
            }
        }

        //水の判定
        if (WaterHight == 0.0f || WaterHight == -0.11f)
        {
            if (Generated)//出現していたら消す
            {
                Destroy(gameObject.transform.Find("Splashes(Clone)").gameObject);//Fireという子オブジェクトを削除(なぜかFire(clone)になる)
                Generated = false;//出現していない
            }
        }
    }
}
