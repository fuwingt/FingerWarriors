using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    private float baseWidth = 800;
    private float baseHeight = 1280;
    public float baseOrthographicSize = 5;


    void Awake()
    {
        float newOrthographicSize = (float)Screen.height / (float)Screen.width * this.baseWidth / this.baseHeight * this.baseOrthographicSize;
        GetComponent<Camera>().orthographicSize = Mathf.Max(newOrthographicSize, this.baseOrthographicSize);
    }
}
