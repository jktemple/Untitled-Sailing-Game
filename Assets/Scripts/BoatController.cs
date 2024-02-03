using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{

    public Vector2 windDirection;
    public float windSpeed;

    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
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
