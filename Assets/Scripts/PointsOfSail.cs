using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PointOfSail
{
    public string name;
    public float speedModifier;
    public float angle;
    public Sail id;

    public PointOfSail(string name, float speedModifier, float angle, Sail id)
    {

        this.name = name;
        this.speedModifier = speedModifier;
        this.angle = angle;
        this.id = id;
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

    private PointsOfSail()
    {
        dict = new Dictionary<Sail, PointOfSail>();
        PointOfSail irons = new("In Irons", 0f, 45f, Sail.Irons);
        PointOfSail closeHauled = new("Close Hauled", 0.25f, 55, Sail.CloseHauled);
        PointOfSail closeReach = new("Close Reach", 0.5f, 75f, Sail.CloseReach);
        PointOfSail beamReach = new("Beam Reach", 0.75f, 105f, Sail.BeamReach);
        PointOfSail broadReach = new("Broad Reach", 0.9f, 140, Sail.BroadReach);
        PointOfSail run = new("Run", 0.6f, 180, Sail.Run);
        dict.Add(Sail.Irons, irons);
        dict.Add(Sail.CloseHauled, closeHauled);
        dict.Add(Sail.CloseReach, closeReach);
        dict.Add(Sail.BeamReach, beamReach);
        dict.Add(Sail.BroadReach, broadReach);
        dict.Add(Sail.Run, run);
    }

    public static PointsOfSail Instance
    {
        get
        {
            instance ??= new PointsOfSail();
            return instance;
        }
    }

    public Sail GetPointOfSailFromAngle(float angle)
    {
        if (angle < dict[Sail.Irons].angle)
        {
            return Sail.Irons;
        }
        else if (angle < dict[Sail.CloseHauled].angle)
        {
            return Sail.CloseHauled;
        }
        else if (angle < dict[Sail.CloseReach].angle)
        {
            return Sail.CloseReach;
        }
        else if (angle < dict[Sail.BeamReach].angle)
        {
            return Sail.BeamReach;
        }
        else if (angle < dict[Sail.BroadReach].angle)
        {
            return Sail.BroadReach;
        }
        else if (angle < dict[Sail.Run].angle)
        {
            return Sail.Run;
        } else
        {
            return Sail.Unknown;
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


}
