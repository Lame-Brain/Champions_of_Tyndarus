using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardSprite : MonoBehaviour
{
    private Transform camera_transform;
    private void Start()
    {
        camera_transform = Camera.main.transform;
    }
    void LateUpdate()
    {
        this.transform.forward = camera_transform.forward;
    }
}
