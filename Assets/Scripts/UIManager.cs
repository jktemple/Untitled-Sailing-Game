using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{
    public BoatController boat;
    public SailManager sail;
    Label pointOfSail;
    Label angle;
    Label sailAngle;

    // Start is called before the first frame update
    private void OnEnable()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        angle = root.Q<Label>("Angle");
        pointOfSail = root.Q<Label>("PointOfSail");
        sailAngle = root.Q<Label>("SailAngle");
    }

    private void Update()
    {
        int boatAngle = (int) boat.GetBoatAngleToWind();
        int sailAngleInt = (int) sail.GetSailAngleRelativeToBoat();
        angle.text = boatAngle.ToString("G9");
        pointOfSail.text = PointsOfSail.Instance.GetPointOfSailFromAngleString(boatAngle);
        sailAngle.text = sailAngleInt.ToString();
    }
}
