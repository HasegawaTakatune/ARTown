using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ShowTitle : MonoBehaviour
{
    /// <summary>
    /// 背景のパネル
    /// </summary>
    [SerializeField] private Image panel;

    /// <summary>
    /// タイトルテキスト
    /// </summary>
    [SerializeField] private Text title;

    /// <summary>
    /// タイトルテキストの最大濃度(アルファ値)
    /// </summary>
    private const float TitleMaxAlpha = 0.7f;

    /// <summary>
    /// フェードインの表示する尺度
    /// </summary>
    [SerializeField] private float fadeInValue = 0.01f;

    /// <summary>
    /// フェードアウトの消える尺度
    /// </summary>
    [SerializeField] private float fadeOutValue = 0.02f;

    /// <summary>
    /// タイトル表示時間
    /// </summary>
    [SerializeField] private float showTitleTime = 1.0f;

    /// <summary>
    /// 初期化
    /// </summary>
    public void TitleStart()
    {
        // フェードインを呼び出す
        StartCoroutine(TitleFadeIn());
    }

    /// <summary>
    /// タイトルフェードイン
    /// </summary>
    /// <returns></returns>
    private IEnumerator TitleFadeIn()
    {
        // タイトルのRGB値を取得
        float r = title.color.r, g = title.color.g, b = title.color.b;

        // アルファ値が一定値以上になったらループを抜ける
        while (title.color.a < TitleMaxAlpha)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            // タイトルをフェードインする
            title.color = new Color(r, g, b, title.color.a + fadeInValue);
        }

        // 一定時間表示したままにする
        yield return new WaitForSeconds(showTitleTime);

        // フェードアウトを呼び出す
        StartCoroutine(TitleFadeOut());

    }

    /// <summary>
    /// タイトルフェードアウト
    /// </summary>
    /// <returns></returns>
    private IEnumerator TitleFadeOut()
    {
        float tR = title.color.r, tG = title.color.g, tB = title.color.b;
        float pR = panel.color.r, pG = panel.color.g, pB = panel.color.b;

        // 消えきったらループを抜ける
        while (title.color.a > 0)
        {
            yield return new WaitForSeconds(Time.deltaTime);
            // タイトル・パネルをフェードアウトする
            title.color = new Color(tR, tG, tB, title.color.a - fadeOutValue);
            panel.color = new Color(pR, pG, pB, panel.color.a - fadeOutValue);
        }

        // オブジェクトを非表示にする
        gameObject.SetActive(false);
    }

    /// <summary>
    /// アクティブ状態を取得
    /// </summary>
    /// <returns>ゲームオブジェクトのアクティブ状態</returns>
    public bool GetActive() { return gameObject.activeInHierarchy; }
}
