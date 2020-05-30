using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_X : MonoBehaviour
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
        if (PlayerScript.UI_X_Flag == false) { alfa = 0.0f; }
        if (PlayerScript.UI_X_Flag == true) { alfa = 1.0f; }

        uiImage.position = RectTransformUtility.WorldToScreenPoint(Camera.main, targetObject.position);
        uiImage.position = new Vector3(uiImage.position.x + 0.0f, uiImage.position.y + 80.0f, uiImage.position.z);
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
    }
}