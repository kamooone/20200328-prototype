using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyParticle : MonoBehaviour//パーティクルが終了したら自滅させる
{
    ParticleSystem particle;//パーティクル

    // Start is called before the first frame update
    void Start()
    {
        particle = this.GetComponent<ParticleSystem>();//情報取得
    }

    // Update is called once per frame
    void Update()
    {
        if (particle.isStopped) //パーティクルが終了したか判別
        {
            Destroy(this.gameObject);//パーティクル用ゲームオブジェクトを削除
        }
    }
}
