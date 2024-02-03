using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SailManager : MonoBehaviour
{

    public Transform sail;
    public Transform rotationPoint;

    [Range(-70f,70f)]
    public float targetAngle = 0f;
    public float rotationSpeed = 20f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float direction = 0;
        float tempTargetAngle = targetAngle;
        if (targetAngle < 0f)
        {
            tempTargetAngle = 360 + targetAngle;
        }

        if (targetAngle>= 0f)
        {
            if(sail.localEulerAngles.y < 360f && sail.localEulerAngles.y > 270f)
            {
                direction= 1;
            } else if(sail.localEulerAngles.y < tempTargetAngle)
            {
                direction = 1;
            } else if(sail.localEulerAngles.y > tempTargetAngle)
            {
                direction = -1;
            }
        } else
        {
            if (sail.localEulerAngles.y < 90f)
            {
                direction = -1;
            } else if(sail.localEulerAngles.y > 270f && sail.localEulerAngles.y > tempTargetAngle)
            {
                direction = -1;
            } else if(sail.localEulerAngles.y > 270f && sail.localEulerAngles.y < tempTargetAngle)
            {
                direction = 1;
            }
        }

        
        if (direction > 0) 
        {
            sail.RotateAround(rotationPoint.position, rotationPoint.forward, rotationSpeed * Time.deltaTime);
        } else if (direction < 0)
        {
            sail.RotateAround(rotationPoint.position, rotationPoint.forward, -rotationSpeed * Time.deltaTime);
        }
        

    }

    public float GetSailAngleRaw()
    {
        return sail.localEulerAngles.y;
    }

    public float GetSailAngleRelativeToBoat()
    {
        if(sail.localEulerAngles.y < 90f)
        {
            return sail.localEulerAngles.y;
        } else
        {
            return 360 - sail.localEulerAngles.y;
        }
    }
}
