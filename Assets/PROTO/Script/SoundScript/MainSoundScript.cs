using UnityEngine;
using System.Collections;

public class MainSoundScript : MonoBehaviour
{
    public GameObject TitleObj;
    public bool DontDestroyEnabled = true;
    

    // Use this for initialization
    void Start()
    {
        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする(次のsceneでもBGMを鳴らすため)
            DontDestroyOnLoad(TitleObj);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}