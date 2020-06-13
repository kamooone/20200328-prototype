using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialHit : MonoBehaviour//チュートリアルの物と当たり判定
{
    public GameObject Title;//タイトル
    public GameObject Text;//テキスト

    /*オブジェクトオンオフ*/
    public GameObject Tutorial1;
    public GameObject Tutorial2;
    public GameObject Tutorial3;
    public GameObject Tutorial4;

    int No;

    public GameObject Key;//鍵


    // Start is called before the first frame update
    void Start()
    {
        No = 0;//最初のチュートリアル

        Tutorial1.SetActive(true);
        Tutorial2.SetActive(false);
        Tutorial3.SetActive(false);
        Tutorial4.SetActive(false);

        Key.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (No == 1)
        {
            Tutorial1.SetActive(false);
            Tutorial2.SetActive(true);
        }

        if (No == 2)
        {
            Tutorial2.SetActive(false);
            Tutorial3.SetActive(true);
        }

        if (No == 3)
        {
            Tutorial3.SetActive(false);
            Tutorial4.SetActive(true);
            Key.SetActive(true);
        }

        if (No == 4)
        {
            Tutorial4.SetActive(false);
            Key.SetActive(false);
            
        }

    }

    void OnTriggerEnter(Collider collision)
    {
       if(collision.gameObject.tag=="Tutorial")
        {
            //番号変更
            Title.GetComponent<TutorialTitleChange>().NunberTitleChange();//
            Text.GetComponent<TutorialTextChange>().NunberTextChange();//

            No++;//次の当たり判定表示
        }


    }

}
