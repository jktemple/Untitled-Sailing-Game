using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class GerstnerWaveManager : MonoBehaviour
{
    public static GerstnerWaveManager instance;
     Vector3 direction1;
     Vector3 direction2;
     Vector3 direction3;
     Vector3 direction4;
     float gravity;
     float depth;
     Vector4 amplitudes;
     float phase;
     Vector4 timescales;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            

        }
        else if (instance != this)
        {
            Debug.Log("Instance of GerstnerWaveManager Already exists, destroying object");
            Destroy(this);
        }
    }

    private void Start()
    {
        Material mat = GetComponent<Renderer>().material;
        if (mat != null)
        {
            direction1 = mat.GetVector("_Direction1");
            direction2 = mat.GetVector("_Direction2");
            direction3 = mat.GetVector("_Direction3");
            direction4 = mat.GetVector("_Direction4");
            gravity = mat.GetFloat("_Gravity");
            depth = mat.GetFloat("_Depth");
            amplitudes = mat.GetVector("_Amplitudes");
            phase = mat.GetFloat("_Phase");
            timescales = mat.GetVector("_Amplitudes");
            Debug.Log("direction1 " + direction1);
            Debug.Log("direction2 " + direction2);
            Debug.Log("direction3 " + direction3);
            Debug.Log("direction4 " + direction4);
            Debug.Log("gravity " + gravity);
            Debug.Log("depth " + depth);
            Debug.Log("amplitude " + amplitudes);
            Debug.Log("phase " + phase);
            Debug.Log("timescale " + timescales);
        }
        else
        {
            Debug.Log("mat is null");
        }
    }

    public float GetGerstnerWaveHeight(Vector3 position)
    {
        float wave1 = Mathf.Cos(Theta(position, direction1, gravity, depth, amplitudes.x, phase, timescales.x)) * amplitudes.x;
        float wave2 = Mathf.Cos(Theta(position, direction2, gravity, depth, amplitudes.y, phase, timescales.y)) * amplitudes.y;
        float wave3 = Mathf.Cos(Theta(position, direction3, gravity, depth, amplitudes.z, phase, timescales.z)) * amplitudes.z;
        float wave4 = Mathf.Cos(Theta(position, direction4, gravity, depth, amplitudes.w, phase, timescales.w)) * amplitudes.w;
        return (wave1 + wave2+ wave3 + wave4);
    }

    float Frequency(float gravity, float depth, Vector3 direction)
    {
        float length = direction.magnitude;
        float hyperbolicTan = (float)Math.Tanh(length * depth);
        return Mathf.Sqrt(length * gravity * hyperbolicTan);
    }

    float Theta(Vector3 position, Vector3 direction, float gravity, float depth, float amplitude, float phase, float timescale)
    {
        float t = Time.time * timescale;
        float vectorMath = position.x * direction.x + position.z * direction.z;
        float frequencyMath = Frequency(gravity, depth, direction) * t;
        return vectorMath - frequencyMath - phase;
    }
}
