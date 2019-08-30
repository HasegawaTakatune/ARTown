using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    /// <summary>
    /// ゲームのステータス（列挙）
    /// </summary>
    public enum STATUS
    {
        /// <summary>
        /// タイトル
        /// </summary>
        TITLE,
        /// <summary>
        /// プレイ
        /// </summary>
        PLAY,
        /// <summary>
        /// ゲームオーバー
        /// </summary>
        GAMEOVER
    }

    /// <summary>
    /// ゲームステータス
    /// </summary>
    [SerializeField] private STATUS status;

    /// <summary>
    /// タイトル表示クラス
    /// </summary>
    [SerializeField] private ShowTitle showTitle;

    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        // ゲームステータス変更
        if(status == STATUS.TITLE)
            ChangeStatus(STATUS.TITLE);
    }


    void Update()
    {

    }

    /// <summary>
    /// ゲームステータス変更
    /// </summary>
    /// <param name="value"></param>
    public void ChangeStatus(STATUS value)
    {
        // ゲームステータス変更
        status = value;

        // ゲームステータスごとに処理を分岐
        switch (status)
        {
            case STATUS.TITLE:
                // タイトル表示を開始する
                showTitle.TitleStart();

                // タイトル表示が終わるのを監視する
                StartCoroutine(CheckShowTitle());
                break;

            case STATUS.PLAY:
                break;

            case STATUS.GAMEOVER:
                break;
        }
    }

    /// <summary>
    /// タイトル表示が終わるのを監視する
    /// </summary>
    /// <returns></returns>
    private IEnumerator CheckShowTitle()
    {
        // タイトル表示が終わるまでループ
        while (showTitle.GetActive())
        {
            yield return new WaitForSeconds(Time.deltaTime);
        }

        // ステータスをプレイに変更
        ChangeStatus(STATUS.PLAY);
    }


}
