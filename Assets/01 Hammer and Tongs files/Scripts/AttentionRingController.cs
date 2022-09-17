using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttentionRingController : MonoBehaviour
{

    Vector3 rot = new Vector3 (0, 0, 0.1f);
    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(rot);
    }
}
