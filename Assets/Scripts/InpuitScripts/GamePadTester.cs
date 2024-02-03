using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePadTester : MonoBehaviour
{

    private PlayerInput inputs;
    int count;
    // Start is called before the first frame update
    void Start()
    {
        inputs = new PlayerInput();
        inputs.Player.Enable();
        count = 0;
        inputs.Player.SailUp.performed += debug => { count++;  Debug.Log("Sail Up Performed count = " + count); };
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rightStick = inputs.Player.SailUp.ReadValue<Vector2>();
        if (rightStick != Vector2.zero)
        {
            //Debug.Log("Right stick inputs = " + rightStick);
        }
    }
}
