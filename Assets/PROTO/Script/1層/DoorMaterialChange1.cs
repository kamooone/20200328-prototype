using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorMaterialChange1 : MonoBehaviour
{
    GameObject PlayerObject;
    PlayerMove PlayerScript;

    //水の高さ取得
    float WaterHight;

    /*マテリアル関係宣言*/
    public Material[] material;           // マテリアル(0は光るマテリアル,1は普通のマテリアルをいれてください) 
    private int No;                         //現在のマテリアルの番号(0は光るマテリアル,1は普通のマテリアルをいれてください)


    // Start is called before the first frame update
    void Start()
    {
        No = 1;//普通のマテリアルを指定

        PlayerObject = GameObject.Find("player");
        PlayerScript = PlayerObject.GetComponent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        //1階の水の高さ取得
        WaterHight = PlayerScript.WaterHight1;

        //水の判定
        if (WaterHight == 0.11f)
        {
            No = 0;
        }

        //水の判定
        if (WaterHight == 0.0f || WaterHight == -0.11f)
        {
            No = 1;
        }

        this.GetComponent<Renderer>().sharedMaterial = material[No];//割り当てのマテリアルを表現(0は普通,1は透明)


    }
}
