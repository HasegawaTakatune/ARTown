using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField] private float speed = 1.0f;

    /// <summary>
    /// 頭のTransform（カメラ部分）
    /// </summary>
    [SerializeField] private Transform head;
    /// <summary>
    /// 体のTransform
    /// </summary>
    [SerializeField] private Transform body;

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        // UnityEditor以外では使わない
#if UNITY_EDITOR

#else
        enabled = false;
#endif
    }

    /// <summary>
    /// メインループ
    /// </summary>
    private void Update()
    {
        // 移動
        Move();

        // カメラ回転
        Rotate();
    }

    /// <summary>
    /// 移動処理
    /// </summary>
    private void Move()
    {
        // 速度取得
        float spd = speed * Time.deltaTime;

        // 入力キーによって移動する
        if (Input.GetKey(KeyCode.W)) transform.position += transform.forward * spd;
        if (Input.GetKey(KeyCode.S)) transform.position -= transform.forward * spd;
        if (Input.GetKey(KeyCode.A)) transform.position -= transform.right * spd;
        if (Input.GetKey(KeyCode.D)) transform.position += transform.right * spd;

        // 上下移動
        if (Input.GetKey(KeyCode.E)) transform.position += transform.up * spd;
        if (Input.GetKey(KeyCode.Q)) transform.position -= transform.up * spd;
    }

    /// <summary>
    /// カメラ回転処理
    /// </summary>
    private void Rotate()
    {
        // ※回転軸の問題でカメラ回転は頭と体に分けて回転させている

        // 頭を回転（カメラ部分）
        head.Rotate(-Input.GetAxis("Mouse Y"), 0, 0);

        // 体を回転
        body.Rotate(0, Input.GetAxis("Mouse X"), 0);

    }

}
