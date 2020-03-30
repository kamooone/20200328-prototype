using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIUp : MonoBehaviour
{
    GameObject PlayerObject;
    PlayerMove PlayerScript;

    [SerializeField]
    private Transform targetObject;
    private RectTransform uiImage;

    float alfa = 0.0f, red = 1.0f, green = 1.0f, blue = 1.0f;

    void Start()
    {
        uiImage = GetComponent<RectTransform>();

        PlayerObject = GameObject.Find("player");
        PlayerScript = PlayerObject.GetComponent<PlayerMove>();
    }

    void Update()
    {
        if (PlayerScript.UIUp_Flag == false) { alfa = 0.0f; }
        if (PlayerScript.UIUp_Flag == true) { alfa = 1.0f; }

        uiImage.position = RectTransformUtility.WorldToScreenPoint(Camera.main, targetObject.position);
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
    }
}