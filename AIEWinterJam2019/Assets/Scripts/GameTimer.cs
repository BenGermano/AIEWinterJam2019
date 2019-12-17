using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour
{
    float startTime;
    public float ellapsedTime;

    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        ellapsedTime = Time.time - startTime;
    }
}
