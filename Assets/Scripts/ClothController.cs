using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClothController : MonoBehaviour
{
    public Cloth sail;
    public BoatController boat;

    public float windStrengthModifier = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sail.externalAcceleration = -windStrengthModifier * new Vector3(boat.windDirection.x, 0, boat.windDirection.y).normalized;
    }
}
