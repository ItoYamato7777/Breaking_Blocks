using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ball : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody myRigid;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigid = this.GetComponent<Rigidbody>();
        // ランダムな方向を生成
        Vector3 randomDirection = GetRandomDirection();
        // ボールにランダムな方向の力を加える
        myRigid.AddForce(randomDirection * speed, ForceMode.VelocityChange);
    }

    // Update is called once per frame
    void Update()
    {

    }

    // x-z 平面上のランダムな方向を返すメソッド
    private Vector3 GetRandomDirection()
    {
        // ランダムな角度を生成 (0 ~ 360度)
        float randomAngle = Random.Range(0f, 360f);

        // ランダムな角度を使って単位ベクトルを計算 (y成分は0に固定, z成分は1に固定)
        float x = Mathf.Cos(randomAngle * Mathf.Deg2Rad);

        return new Vector3(x, 0f, 1f).normalized; // 正規化して一定の大きさを維持
    }
}
