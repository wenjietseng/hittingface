using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowHMD : MonoBehaviour
{
    public Transform hmd;
    public Vector3 dist;
    void Update()
    {
        this.transform.position = hmd.position + dist;
    }
}
