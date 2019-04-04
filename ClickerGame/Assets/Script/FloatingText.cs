﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour
{
    public float DestroyTime = 1;
    public Vector3 Offset = new Vector3(0, 1, 0);
    public Vector3 RandomIntensity = new Vector3(1f, 0.5f, 0);

    void Start()
    {
        Destroy(gameObject, DestroyTime);
        transform.localPosition += Offset;
        transform.localPosition += new Vector3(Random.Range(-RandomIntensity.x, RandomIntensity.x),
        Random.Range(-RandomIntensity.y, RandomIntensity.y),
        Random.Range(-RandomIntensity.z, RandomIntensity.z));
    }

}
