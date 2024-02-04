using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{

    public Vector2 windDirection;
    public float windSpeed;
    [Range(0f, 25f)]
    public float sailStep = 5f;
    public float keyboardSailSpeed = 20f;

    public float rotationSpeed = 20f;

    public Rigidbody rb;
    public SailManager sail;

 
    private PlayerInput inputs;

    
    // Start is called before the first frame update
    void Start()
    {
        inputs = new PlayerInput();
        inputs.Player.Enable();
        inputs.Player.SailUp.performed += sailUpAction => { sail.AddToSailAngle(sailStep); };
        inputs.Player.SailDown.performed += sailDownAction => { sail.AddToSailAngle(-sailStep); };
        inputs.Player.Tack.performed += tackAction => { sail.Tack(); };
    }

    private void Update()
    {
        if (inputs.Player.KeyboardSailUP.ReadValue<float>() !=0)
        {
            sail.AddToSailAngle(sailStep*Time.deltaTime*keyboardSailSpeed);
        } else if (inputs.Player.KeyboardSailDown.ReadValue<float>() !=0)
        {
            sail.AddToSailAngle(-sailStep*Time.deltaTime*keyboardSailSpeed);
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float inputValue = inputs.Player.Steer.ReadValue<float>();
        Vector3 currentRotation = rb.rotation.eulerAngles;
        Vector3 targetRotation = new Vector3(currentRotation.x, currentRotation.y + (inputValue*Time.fixedDeltaTime*rotationSpeed), currentRotation.z);
        rb.MoveRotation(Quaternion.Euler(targetRotation));
        float boatAngle = GetBoatAngleToWind();
        float sailAngle = sail.GetSailAngleRelativeToBoat();
        PointOfSail point = PointsOfSail.Instance.GetPointOfSailFromAngle(boatAngle);
        float sailModifier = PointsOfSail.Instance.GetSailSpeedModifier(point.id, sailAngle);
        Debug.Log("SailModifier = " + sailModifier);
        Debug.Log("Point.SpeedModifier = " + point.speedModifier);
        rb.AddForce(point.speedModifier * sailModifier * windSpeed * transform.forward *Time.fixedDeltaTime, ForceMode.Force);
        /**
         * float boatAngleModifier = ...
         * float sailAngleModifier = ...
         * Vector3 direction = new(transform.forward.x, 0, transform.forward.z);
         * rb.AddForce(direction*windSpeed*boatAngleModifier*sailAngleModifier*Time.FixedDeltaTime, ForceMode.Force);
         * 
         */
    }

    public float GetBoatAngleToWind()
    {
        Vector2 boatDirection = new Vector2(transform.forward.x, transform.forward.z);
        float angletowind = Mathf.Acos(Vector2.Dot(windDirection.normalized, boatDirection.normalized)) * Mathf.Rad2Deg;
        //Debug.Log("boat Angle to wind = " + angletowind);
        return angletowind;
        
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.red;
        Vector3 direction = transform.forward * 50;
        Gizmos.DrawRay(transform.position, direction);
        Gizmos.color = Color.green;
        Vector3 windD = new(windDirection.x, 0, windDirection.y);
        Gizmos.DrawRay(transform.position, windD.normalized*50);
    }
}
