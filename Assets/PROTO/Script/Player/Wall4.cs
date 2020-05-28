using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall4 : MonoBehaviour
{
    public Transform target;//中心となるオブジェクト

    public static bool wallcollision4 = false;
    // Start is called before the first frame update
    void Start()
    {
        wallcollision4 = false;
    }

    // Update is called once per frame
    void Update()
    {
        //L Stick
        float Left = Input.GetAxis("L");
        float Right = Input.GetAxis("R");

        //左に移動  
        if ((Left > 0 || Input.GetKey("left")) && PlayerMove.Wall_Move4 == true && PlayerMove.PlayerDirection == 2 && PlayerMove.WallNo4 == true)
        {
            Vector3 axis = transform.TransformDirection(Vector3.up);
            transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
        }

        //右に移動
        if ((Right > 0 || Input.GetKey("right")) && PlayerMove.Wall_Move4 == true && PlayerMove.PlayerDirection == -1 && PlayerMove.WallNo4 == true)
        {
            Vector3 axis = transform.TransformDirection(Vector3.down);
            transform.RotateAround(target.position, axis, PlayerMove.wallspeed * Time.deltaTime);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Wall" || collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Enemy2")
        {
            wallcollision4 = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        wallcollision4 = false;
    }
}
