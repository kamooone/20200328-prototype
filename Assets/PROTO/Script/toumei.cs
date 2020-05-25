using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toumei : MonoBehaviour
{

    //Renderer render;

    ////float d = 1.0f;
    //float a =1.0f;

    //// Use this for initialization
    //void Start()
    //{
    //    GetComponent<Renderer>().material.color = new Color(1.0f, 0.0f, 0.0f, a);
    //    //render.material.color = new Color(1.0f, 0.0f, 0.0f, a);
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    transform.Rotate(new Vector3(1.0f, 1.0f, 0f));

    //    if (a >= 0)

    //        a -=0.05f;

    //}
    //float alfa;
    //float red;
    //float green, blue;
    //void Start()
    //{
        
    //    red = GetComponent<Renderer>().material.color.r;
    //    green = GetComponent<Renderer>().material.color.g;
    //    blue = GetComponent<Renderer>().material.color.b;
    //}
    //    void Update()
    //{
        
    //    GetComponent<Renderer>().material.color = new Color(red, green, blue, alfa);
    //    alfa = alfa - 0.01f;
    //    if (alfa <= -2)//透明になったら戻す
    //    {
    //        alfa = 1.0f;
    //    }
    //}
    void Start()
    {
        
        //color.a = 0.6f;
       
    }
    void Update()
    {
        Color color = gameObject.GetComponent<Renderer>().material.color;
        color.a = color.a - 0.01f;
        if (color.a <= 0)//透明になったら戻す
        {
            color.a = 1.0f;
        }

        gameObject.GetComponent<Renderer>().material.color = color;
    }
}