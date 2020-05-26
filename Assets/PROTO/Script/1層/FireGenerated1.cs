using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGenerated1 : MonoBehaviour//炎パーティクル生成と消滅
{
    GameObject PlayerObject;
    PlayerMove PlayerScript;

    public AudioClip WalkSE;
    AudioSource aud;
    int SETime = 0;

    public static float speed = 4.0f;

    // アニメーション再生速度設定
    public static float AnimSpeed = 1.0f;

    //水の高さ取得
    float WaterHight;

    /*パーティクル関係宣言*/
    private GameObject Particle;//出現させる炎のパーティクル(prefab科しているためGameObject宣言)

    [SerializeField]
    private GameObject EnemyObj;//親になる透明な敵
    private GameObject ChildObj;//実際の炎のパーティクルの場所

    private bool Generated;//出現してるか


    // Start is called before the first frame update
    void Start()
    {
        Particle = (GameObject)Resources.Load("Particle/Fire");//ResourcesフォルダのFireパーティクルを出現する
        Generated = false;//出現していない


        PlayerObject = GameObject.Find("player");
        PlayerScript = PlayerObject.GetComponent<PlayerMove>();

        this.aud = GetComponent<AudioSource>();
        SETime = 0;

        speed = 1.5f;

        AnimSpeed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //ポーズ画面になるとUpdate以外の処理も止める
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }

        //二階の水の高さ取得
        WaterHight = PlayerScript.WaterHight1;

        //水の判定
        if (WaterHight == 0.0f || WaterHight == -0.11f)
        {
            if (Generated == false)//出現していなかったら生成する
            {
                ChildObj = Instantiate(Particle, this.transform.position, Quaternion.identity); //パーティクル用ゲームオブジェクト生成
                //ChildObj = (GameObject)Instantiate(Particle);
                ChildObj.transform.parent = EnemyObj.transform;//指定したオブジェクトと親子関係

                Generated = true;//出現している

                speed = 3.0f;

                AnimSpeed = 2.0f;

                /*直接代入(追加)*/
                ChildObj.transform.localPosition = new Vector3(0.0f, 0.03f, 0.0f);
                Vector3 rotationVector = new Vector3(-90, 0, 0);
                ChildObj.transform.rotation = Quaternion.Euler(rotationVector);
                ChildObj.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);

            }
        }

        //水の判定
        if (WaterHight == 0.11f)
        {
            if (Generated)//出現していたら消す
            {
                Destroy(gameObject.transform.Find("Fire(Clone)").gameObject);//Fireという子オブジェクトを削除(なぜかFire(clone)になる)
                Generated = false;//出現していない

                speed = 1.5f;

                AnimSpeed = 1.0f;
            }

            if (SETime == 0)
            {
                this.aud.PlayOneShot(this.WalkSE);
            }
            if (SETime < 102)
            {
                SETime++;
            }
            if (SETime == 102)
            {
                SETime = 0;
            }
        }
        if (Enemy1Move.TuiFlag == false)
        {
            speed = 6.0f;

            AnimSpeed = 4.0f;
        }
        if (Enemy1Move.TuiFlag == true)
        {
            speed = 10.0f;

            AnimSpeed = 8.0f;
        }
    }
}
