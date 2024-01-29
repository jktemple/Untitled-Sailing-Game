using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UIElements;

public class WaveManager : MonoBehaviour
{
    public static WaveManager instance;

    public float amplitude = 1.0f;
    public float length = 2f;
    public float speed = 1f;
    public float offset = 0f;


    private void Awake()
    {
        if (instance == null) 
        { 
            instance = this; 
        } else if (instance != this)
        {
            Debug.Log("Instance of WaveManager Already exists, destroying object");
            Destroy(this);
        }
    }

    private void Update()
    {
        offset += Time.deltaTime * speed;

    }

    public float GetWaveHeight(float _x)
    {
        return amplitude * Mathf.Sin(_x/length + offset);
    }


}
