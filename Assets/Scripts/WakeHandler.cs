using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WakeHandler : MonoBehaviour
{

    [SerializeField]
    float wakeHeightMax;
    [SerializeField]
    float wakeHeightMin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float waveHeight = GerstnerWaveManager.instance.GetGerstnerWaveHeight(transform.position);
        Vector3 worldSpaceTarget = new(transform.position.x, waveHeight, transform.position.z);
       Vector3 localSpaceTarget = transform.InverseTransformPoint(worldSpaceTarget);
        if(localSpaceTarget.y >= wakeHeightMin && localSpaceTarget.y<=wakeHeightMax)
        {
            transform.position = worldSpaceTarget;
        }
    }
}
