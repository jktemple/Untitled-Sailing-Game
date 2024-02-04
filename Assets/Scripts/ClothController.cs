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
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = new Vector3(boat.windDirection.x, 0, boat.windDirection.y).normalized;
        sail.externalAcceleration = new Vector3(-temp.x*windStrengthModifierX, 0, -temp.z*windStrengthModifierY);
    }
}
