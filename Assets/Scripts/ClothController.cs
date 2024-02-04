using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothController : MonoBehaviour
{
    public Cloth sail;
    public BoatController boat;

    public float windStrengthModifierX = 100f;
    public float windStrengthModifierY = 100f;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 temp = new Vector3(boat.windDirection.x, 0, boat.windDirection.y).normalized;
        sail.externalAcceleration = new Vector3(-temp.x * windStrengthModifierX, 0, -temp.z * windStrengthModifierY);
    }

    // Update is called once per frame
    void Update()
    {
        //This code here for editor testing purposes - remove at some point
        Vector3 temp = new Vector3(boat.windDirection.x, 0, boat.windDirection.y).normalized;
        sail.externalAcceleration = new Vector3(-temp.x*windStrengthModifierX, 0, -temp.z*windStrengthModifierY);
    }

    public void SetRandomAcceleration(float accelertaion)
    {
        sail.randomAcceleration = new Vector3(accelertaion,0,0);
    }
}
