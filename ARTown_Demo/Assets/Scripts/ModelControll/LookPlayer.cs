using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookPlayer : MonoBehaviour
{    
    /// <summary>
    /// ターゲット
    /// </summary>
    [SerializeField] private Transform target;

    /// <summary>
    /// ヘッドパーツ
    /// </summary>
    [SerializeField] private Transform head;

    /// <summary>
    /// ボディパーツ
    /// </summary>
    [SerializeField] private Transform body;

    /// <summary>
    /// 体の回転を一時格納
    /// </summary>
    private float bodyRotaX;

    /// <summary>
    /// 最小角度
    /// </summary>
    private const float MIN = 40.0f;

    /// <summary>
    /// 最大角度
    /// </summary>
    private const float MAX = 320.0f;

    /// <summary>
    /// 回転スピード
    /// </summary>
    [SerializeField] private float rotaSpeed = 1;   

    /// <summary>
    /// すべてのUpdate処理が呼ばれた後に呼ばれる処理
    /// アニメーション処理後に呼び出される処理でもあるので、モデルのRotationを再設定できる
    /// </summary>
    private void LateUpdate()
    {
        // ターゲットに向く
        LookTarget();
    }

    /// <summary>
    /// ターゲットに向く
    /// </summary>
    private void LookTarget()
    {
        // from:自分 to:ターゲット
        Vector3 from = transform.position, to = target.position;

        // ターゲットの向きを格納
        float x = GetAngle(new Vector2(from.x, from.z), new Vector2(to.x, to.z));
        float z = GetHeigthAngle(from, to);

        // ヘッドが限界まで回った場合、ボディを回転させる
        if (Mathf.Abs(x - body.eulerAngles.y) > MIN && Mathf.Abs(x - body.eulerAngles.y) < MAX)
        {
            bodyRotaX = x;
        }

        // ヘッド・ボディを回転させる
        body.rotation = Quaternion.Slerp(body.rotation, Quaternion.Euler(0, bodyRotaX, 0), rotaSpeed * Time.deltaTime);
        head.localRotation = (Quaternion.Euler( new Vector3(-(x - body.eulerAngles.y), 0, -z)));
    }

    /// <summary>
    /// 2点間の角度取得
    /// </summary>
    /// <param name="from">スタート地点</param>
    /// <param name="to">ゴール地点</param>
    /// <returns>角度</returns>
    private float GetAngle(Vector2 from, Vector2 to)
    {
        Vector2 dt = new Vector2(to.x - from.x, to.y - from.y);
        float rad = Mathf.Atan2(dt.x, dt.y);
        float degree = rad * Mathf.Rad2Deg;

        if (degree < 0) degree += 360;

        return degree;
    }

    /// <summary>
    /// ２点間の角度（高さ）
    /// </summary>
    /// <param name="from">スタート地点</param>
    /// <param name="to">ゴール地点</param>
    /// <returns>角度</returns>
    private float GetHeigthAngle(Vector3 from, Vector3 to)
    {
        // new Vector2(from・toのx,y座標で２点間の距離を取得,from・toのy座標から距離を取得)
        Vector2 dt = new Vector2(Vector2.Distance(new Vector2(to.x, to.z), new Vector2(from.x, from.z)), to.y - from.y);
        // 基準となる角度
        float baseAngle = 90;

        float rad = Mathf.Atan2(dt.x, dt.y);
        float degree = rad * Mathf.Rad2Deg - baseAngle;

        if (degree < 0) degree += 360;

        return degree;
    }
}
