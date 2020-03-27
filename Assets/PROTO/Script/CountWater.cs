using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountWater : MonoBehaviour//水の高さを図り画面内に表示するもの
{
    public GameObject target;//水のオブジェクト
    private Vector3 position;//表示するための変数

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*水の座標を更新*/
        position.y = target.transform.position.y;

        this.GetComponent<Text>().text = "現在の水の数値:" + position.y.ToString();//値を表示
    }
}
