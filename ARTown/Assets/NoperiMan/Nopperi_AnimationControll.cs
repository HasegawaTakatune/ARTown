using System.Collections;
using UnityEngine;

public class Nopperi_AnimationControll : MonoBehaviour
{

    /// <summary>
    /// アニメーター取得
    /// </summary>
    [SerializeField] private Animator animator;

    /// <summary>
    /// 最小待ち時間
    /// </summary>
    private const float MinWaitTime = 20;

    /// <summary>
    /// 最大待ち時間
    /// </summary>
    private const float MaxWaitTime = 60;

    /// <summary>
    /// 歩くアニメーション呼び出し
    /// </summary>
    public void PlayWalk()
    {
        animator.SetTrigger("Walk");
    }

    /// <summary>
    /// 座るアニメーション呼び出し
    /// </summary>
    public void PlaySit() 
    {
        animator.SetTrigger("Sit");
    }

    /// <summary>
    /// 座り一定時間待機→立ち上がるアニメーション呼び出し
    /// </summary>
    /// <returns></returns>
    private IEnumerator PlayWait2Standup()
    {
        yield return new WaitForSeconds(Random.Range(MinWaitTime,MaxWaitTime));
        PlayStandup();
    }

    /// <summary>
    /// 立ち上がるアニメーション呼び出し
    /// </summary>
    private void PlayStandup()
    {
        animator.SetTrigger("Standup");
    }

    /// <summary>
    /// 死亡アニメーション呼び出し
    /// </summary>
    public void PlayDying()
    {
        animator.SetTrigger("Dying");
    }

    /// <summary>
    /// 一定時間後に蘇るアニメーション呼び出し
    /// </summary>
    /// <returns></returns>
    private IEnumerator PlayRevival()
    {
        yield return new WaitForSeconds(Random.Range(MinWaitTime, MaxWaitTime));
        animator.SetTrigger("Revival");
    }
}
