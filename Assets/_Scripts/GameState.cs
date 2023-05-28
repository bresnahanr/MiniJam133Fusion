using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public static class GameState
{
    public static Resource Money;
    public static Resource Uranium;
    public static Resource Wood;
    public static Resource Water;

    public static float UraniumMeter;
    public static float WoodMeter;
    public static float WaterMeter;

    public static float UraniumTickRate = 6;
    public static float WoodTickRate = 4;
    public static float WaterTickRate = 2;
}
