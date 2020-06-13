using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Number : MonoBehaviour
{
    public GameObject stage_object = null; // Textオブジェクト
    public GameObject world_object = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Text stage_text = stage_object.GetComponent<Text>();
        Text world_text = world_object.GetComponent<Text>();
        stage_text.text = "StageNo:" + Menu.StageNo;
        //world_text.text = "WorldNo:" + Menu.WorldNo;
    }
}
