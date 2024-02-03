using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SailManager : MonoBehaviour
{

    public Transform sail;
    public Transform rotationPoint;

    [SerializeField]
    [Range(-70f,70f)]
    private float targetAngle = 0f;
    [SerializeField]
    private float normalRotationSpeed = 50f;
    [SerializeField]
    private float tackingRotationalSpeed = 150f;
    private float currentRotationSpeed;

    private bool tacking = false;

    // Start is called before the first frame update
    void Start()
    {
        currentRotationSpeed = normalRotationSpeed;
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
            sail.RotateAround(rotationPoint.position, rotationPoint.forward, currentRotationSpeed * Time.deltaTime);
        } else if (direction < 0)
        {
            sail.RotateAround(rotationPoint.position, rotationPoint.forward, -currentRotationSpeed * Time.deltaTime);
        }
        Debug.Log("Temp Target Angle = " + tempTargetAngle + " local euler angle = " + sail.localEulerAngles.y);
        if(tacking && Mathf.Abs(tempTargetAngle - sail.localEulerAngles.y) <1.5)
        {
            tacking = false;
            currentRotationSpeed = normalRotationSpeed;
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

    public void SetTargetAngle(float angle)
    {
        if (tacking) return;
        if (angle < -70f)
        {
            targetAngle = -70f;
        } else if (angle > 70f)
        {
            targetAngle = 70f;
        } else
        {
            targetAngle = angle;
        }
    }

    public void AddToSailAngle(float angle)
    {
        if (tacking) return;
        targetAngle += angle;
        if (targetAngle < -70f)
        {
            targetAngle = -70f;
        }
        else if (targetAngle > 70f)
        {
            targetAngle = 70f;
        }
       
    }

    public void Tack()
    {
        targetAngle*=-1;
        tacking= true;
        currentRotationSpeed = tackingRotationalSpeed;
    }

    public void SetSailRotationSpeed(float speed)
    {
       currentRotationSpeed = speed;
    }
}
