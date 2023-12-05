﻿using System.Collections.Generic;
using System.Linq;

public static class Utilities
{
    // random thu tu 1 list
    public static List<T> RandomList<T>(List<T> list, int amount)
    {
        return list.OrderBy(_ => System.Guid.NewGuid()).Take(amount).ToList();
    }
    
    // lay ket qua theo ty le xac suat
    public static bool Chance(int rand, int max = 100)
    {
        return UnityEngine.Random.Range(0, max) < rand;
    }
    
    // random 1 gia tri enum trong 1 kieu enum
    private static System.Random _random = new System.Random();
    public static T RandomEnumValue<T>()
    {
        var v = System.Enum.GetValues(typeof(T));
        return (T) v.GetValue(_random.Next(v.Length));
    }
}