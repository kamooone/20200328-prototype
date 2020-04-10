using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyMove2 : MonoBehaviour//敵の移動処理(本来はまとめてやる)
{
    GameObject PlayerObject;
    PlayerMove PlayerScript;

    int EnemyMax = 3;
    GameObject[] Enemy = new GameObject[3];

    public Transform target;

    float[] speed = new float[3];

    //エネミーの向き
    int[] direction = new int[3];

    //方向チェンジ時の角度
    float[] radian = new float[3];

    //各層の水の高さ取得
    float[] WaterHight = new float[5];

    // Start is called before the first frame update
    void Start()
    {
        PlayerObject = GameObject.Find("player");
        PlayerScript = PlayerObject.GetComponent<PlayerMove>();

        //各エネミーコンポーネントの取得
        Enemy[0] = GameObject.Find("EnemyObj/enemy2");
        Enemy[1] = GameObject.Find("EnemyObj/enemy2(1)");
        Enemy[2] = GameObject.Find("EnemyObj/enemy2(2)");

        for(int i=0;i< EnemyMax; i++)
        {
            speed[i] = 10.0f;
            direction[i] = 1;
            radian[i] = 180.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //各層の水の高さ取得
        WaterHight[0] = PlayerScript.WaterHight2;
        WaterHight[1] = PlayerScript.WaterHight1;
        WaterHight[2] = PlayerScript.WaterHight3;
        WaterHight[3] = PlayerScript.WaterHight4;
        WaterHight[4] = PlayerScript.WaterHight5;

        if (Input.GetKey("left"))
        {
            for (int i = 0; i < EnemyMax; i++)
            {
                direction[i] = 1;
            }
        }
        if (Input.GetKey("right"))
        {
            for (int i = 0; i < EnemyMax; i++)
            {
                direction[i] = -1;
            }
        }

        for (int i=0;i< EnemyMax; i++)
        {
            //水の判定
            if (WaterHight[i] == 0.1f)
            {
                /*移動処理*/
                if (direction[i] == 1)
                {
                    if (radian[i] != 180.0f)
                    {
                        radian[i] = 180.0f;
                        Enemy[i].transform.Rotate(new Vector3(0f, radian[i], 0f));
                    }

                    Vector3 axis = transform.TransformDirection(Vector3.up);
                    Enemy[i].transform.RotateAround(target.position, axis, speed[i] * Time.deltaTime / EnemyMax);
                }

                if (direction[i] == -1)
                {
                    if (radian[i] != -180.0f)
                    {
                        radian[i] = -180.0f;
                        Enemy[i].transform.Rotate(new Vector3(0f, radian[i], 0f));
                    }

                    Vector3 axis = transform.TransformDirection(Vector3.down);
                    Enemy[i].transform.RotateAround(target.position, axis, speed[i] * Time.deltaTime / EnemyMax);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("GameOverScene");
        }
    }
}
