using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameCreator.Core.Hooks;

public class TextFaceCamera : MonoBehaviour
{
    
    
    private Vector3 rot;
    private Vector3 playerT;
    private void Start()
    {
        playerT = HookPlayer.Instance.transform.position;
        this.transform.position = new Vector3 (playerT.x, 1.5f,playerT.z);
        this.transform.rotation = HookCamera.Instance.transform.rotation;
        
    }


}
