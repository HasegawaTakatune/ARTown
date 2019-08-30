using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFace : MonoBehaviour
{
    public Transform neckBone;

    protected virtual void LateUpdate()
    {
        if (neckBone != null)
        {
            neckBone.Rotate(30f, 20f, 0f);
        }
    }
}
