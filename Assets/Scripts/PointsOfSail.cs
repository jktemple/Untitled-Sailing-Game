using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PointOfSail
{
    public string name;
    public float speedModifier;
    public float angle;
    public Sail id;
    public float sailAngleMin;
    public float sailAngleMax;

    public PointOfSail(string name, float speedModifier, float angle, Sail id, float sailAngleMin, float sailAngleMax)
    {

        this.name = name;
        this.speedModifier = speedModifier;
        this.angle = angle;
        this.id = id;
        this.sailAngleMin= sailAngleMin;
        this.sailAngleMax= sailAngleMax;
    }
}

public enum Sail
{
    Irons,
    CloseHauled,
    CloseReach,
    BeamReach,
    BroadReach,
    Run,
    Unknown
}

public sealed class PointsOfSail
{
    private static PointsOfSail instance = null;
    public Dictionary<Sail, PointOfSail> dict;


    //Need to update once figured out what the sail angle mins and max are
    private PointsOfSail()
    {
        dict = new Dictionary<Sail, PointOfSail>();
        PointOfSail irons = new("In Irons", 0f, 45f, Sail.Irons,0f,70f);
        PointOfSail closeHauled = new("Close Hauled", 0.25f, 55, Sail.CloseHauled,8f,13f);
        PointOfSail closeReach = new("Close Reach", 0.5f, 75f, Sail.CloseReach, 20f, 25f);
        PointOfSail beamReach = new("Beam Reach", 0.75f, 105f, Sail.BeamReach, 33f, 38f);
        PointOfSail broadReach = new("Broad Reach", 0.9f, 140, Sail.BroadReach, 47f, 52f);
        PointOfSail run = new("Run", 0.6f, 180, Sail.Run, 60f, 70f);
        PointOfSail error = new("Error", 0, 0, Sail.Unknown, 0, 0);
        dict.Add(Sail.Irons, irons);
        dict.Add(Sail.CloseHauled, closeHauled);
        dict.Add(Sail.CloseReach, closeReach);
        dict.Add(Sail.BeamReach, beamReach);
        dict.Add(Sail.BroadReach, broadReach);
        dict.Add(Sail.Run, run);
        dict.Add(Sail.Unknown, error);
    }

    public static PointsOfSail Instance
    {
        get
        {
            instance ??= new PointsOfSail();
            return instance;
        }
    }

    public PointOfSail GetPointOfSailFromAngle(float angle)
    {
        if (angle < dict[Sail.Irons].angle)
        {
            return dict[Sail.Irons];
        }
        else if (angle < dict[Sail.CloseHauled].angle)
        {
            return dict[Sail.CloseHauled];
        }
        else if (angle < dict[Sail.CloseReach].angle)
        {
            return dict[Sail.CloseReach];
        }
        else if (angle < dict[Sail.BeamReach].angle)
        {
            return dict[Sail.BeamReach];
        }
        else if (angle < dict[Sail.BroadReach].angle)
        {
            return dict[Sail.BroadReach];
        }
        else if (angle < dict[Sail.Run].angle)
        {
            return dict[Sail.Run];
        } else
        {
            return dict[Sail.Unknown];
        }
    }

    public string GetPointOfSailFromAngleString(float angle)
    {
        if (angle < dict[Sail.Irons].angle)
        {
            return dict[Sail.Irons].name;
        }
        else if (angle < dict[Sail.CloseHauled].angle)
        {
            return dict[Sail.CloseHauled].name;
        }
        else if (angle < dict[Sail.CloseReach].angle)
        {
            return dict[Sail.CloseReach].name;
        }
        else if (angle < dict[Sail.BeamReach].angle)
        {
            return dict[Sail.BeamReach].name;
        }
        else if (angle < dict[Sail.BroadReach].angle)
        {
            return dict[Sail.BroadReach].name;
        }
        else if (angle < dict[Sail.Run].angle)
        {
            return dict[Sail.Run].name;
        }
        else
        {
            return "Unknown";
        }
    }

    public float GetSpeedModifierFromAngle(float angle)
    {
        if (angle < dict[Sail.Irons].angle)
        {
            return dict[Sail.Irons].speedModifier;
        }
        else if (angle < dict[Sail.CloseHauled].angle)
        {
            return dict[Sail.CloseHauled].speedModifier;
        }
        else if (angle < dict[Sail.CloseReach].angle)
        {
            return dict[Sail.CloseReach].speedModifier;
        }
        else if (angle < dict[Sail.BeamReach].angle)
        {
            return dict[Sail.BeamReach].speedModifier;
        }
        else if (angle < dict[Sail.BroadReach].angle)
        {
            return dict[Sail.BroadReach].speedModifier;
        }
        else if (angle < dict[Sail.Run].angle)
        {
            return dict[Sail.Run].speedModifier;
        }
        else
        {
            return 0f;
        }
    }

    public float GetSailSpeedModifier(Sail point, float sailAngle)
    {
        float sailMin = dict[point].sailAngleMin;
        float sailMax = dict[point].sailAngleMax;
        if(sailAngle > sailMin && sailAngle < sailMax)
        {
            return 1;
        } else if(sailAngle < sailMin)
        {
            return Mathf.InverseLerp(0f, sailMin, sailAngle);
        }
        else
        {
            return 1-Mathf.InverseLerp(sailMax, 70f, sailAngle);
        }
    }
}
