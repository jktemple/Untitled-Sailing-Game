using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public BoatController boat;
    Label pointOfSail;
    Label angle;

    // Start is called before the first frame update
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        angle = root.Q<Label>("Angle");
        pointOfSail = root.Q<Label>("PointOfSail");
    }

    private void Update()
    {
        int boatAngle = (int) boat.GetBoatAngleToWind();
        angle.text = boatAngle.ToString("G9");
        pointOfSail.text = PointsOfSail.Instance.GetPointOfSailFromAngleString(boatAngle);
    }
}
