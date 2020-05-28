using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toumei2 : MonoBehaviour
{
    private Material material;
    public float F = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        this.material = this.GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //F = F - 10.0f;
        //if (F <= 0)//透明になったら戻す
        //{
        //    F = 100.0f;
        //}
        Color color = new Color(1.0f, 1.0f,1.0f, F);

        material.SetColor("_HorizonColor", color);
    }
}
