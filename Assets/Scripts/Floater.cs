using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floater : MonoBehaviour
{

    
    public Rigidbody rb;
    public float depthBeforeSubmerged = 1f;
    public float displacementAmount = 3f;
    public int floaterCount = 1;

    public float waterDrag = 0.99f;
    public float waterAngularDrag = 0.5f;

    private void FixedUpdate()
    {
        rb.AddForceAtPosition(Physics.gravity/floaterCount, transform.position, ForceMode.Acceleration);

        float waveHeight = GerstnerWaveManager.instance.GetGerstnerWaveHeight(transform.position);
        if (transform.position.y < waveHeight)
        {
            float displacmentMultiplier = Mathf.Clamp01((waveHeight-transform.position.y)/depthBeforeSubmerged) * displacementAmount;
            rb.AddForceAtPosition(new Vector3(0f, Mathf.Abs(Physics.gravity.y) * displacmentMultiplier, 0f), transform.position, ForceMode.Acceleration);
            rb.AddForce(displacmentMultiplier * Time.fixedDeltaTime * waterDrag * -rb.velocity, ForceMode.Force);
            rb.AddTorque(displacmentMultiplier * Time.fixedDeltaTime * waterAngularDrag * -rb.angularVelocity, ForceMode.VelocityChange);
        
        }
    }
}
