using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public void SetLength(int length)
    {
        var appliedPos = transform.localScale;
        appliedPos.z = length;
        transform.localScale = appliedPos;
    }
}
