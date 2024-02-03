using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
#if UNITY_EDITOR
[InitializeOnLoad]
#endif
public class CircleInteraction : IInputInteraction<Vector2>
{
    [Tooltip("Determines how long the player has to complete the action")]
    public float duration = 0.2f;
    [Tooltip("Determines the required angle before registering that the action has been completed")]
    public float requiredAngle = 16f;
    [Tooltip("Maximum difference between the starting angle of the stick and current before action is cancled")]
    public float cullingAngle = 180f;
    [Tooltip("How far the stick must be from the origin to begin and maintain the circle input")]
    public float circleDistance = 0.75f;
    [Tooltip("For Determining the direction of circle input, default is clockwise")]
    public bool counterClockwise = false;

    private float startAngle = 0f;

    static CircleInteraction()
    {
        InputSystem.RegisterInteraction<CircleInteraction>();
    }


    [RuntimeInitializeOnLoadMethod]
    private static void Initialize() { }

    public void Process(ref InputInteractionContext context)
    {
        if (context.timerHasExpired)
        {
            context.Canceled();
            return;
        }

        switch(context.phase)
        {
            case InputActionPhase.Waiting:
                Vector2 inputVector = context.ReadValue<Vector2>();
                
                if ( inputVector.magnitude >= circleDistance)
                {
                    context.Started();
                    context.SetTimeout(duration);
                    startAngle = Mathf.Atan2(inputVector.y, inputVector.x)*Mathf.Rad2Deg;
                }
                break;
            case InputActionPhase.Started:
                Vector2 vector = context.ReadValue<Vector2>();
                float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
                float difference = angle - startAngle;
                float absDiff = Mathf.Abs(difference);
                if (vector.magnitude < circleDistance || absDiff > cullingAngle)
                {
                    context.Canceled();
                    return;
                }

                if (!counterClockwise && difference < 0 && absDiff >= requiredAngle)
                {
                    context.Performed();
                } else if(counterClockwise && difference > 0 && absDiff >= requiredAngle)
                {
                    context.Performed();
                }
                break;
        }
    }

    public void Reset()
    {
        startAngle = 0f;
    }
}
