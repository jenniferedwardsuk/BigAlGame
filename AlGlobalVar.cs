using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AlGlobalVar {

    public static double Alfierceness;
    public static double Alagility;
    public static double Alhealth;
    public static double algrowspeed;
    public static int level1choice = 0;
    public static int level2choice = 0;
    public static int level3choice = 0;

    private static System.Random rng = new System.Random();
    static string _currFF;
    static int _score;
    static int _lastlvlScore;
    static double _level;
    static double _weight;
    static double _energy;
    static double _fitness;
    static int _lastlvlcloc1;
    static int _lastlvlcloc2;

    public static void Shuffle<T>(this IList<T> list) // from stackoverflow
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
    
    // Access routines for global variables.
    public static string currFF { get { return _currFF; } set { _currFF = value; } }
    public static int ScoreValue { get { return _score; } set { _score = value; } }
    public static int lastlvlScore { get { return _lastlvlScore; } set { _lastlvlScore = value; } }
    public static double LevelValue { get { return _level; } set { _level = value; } }
    public static double WeightValue { get { return _weight; } set { _weight = value; } }
    public static double EnergyValue { get { return _energy; } set { _energy = value; } }
    public static double FitnessValue { get { return _fitness; } set { _fitness = value; } }
    public static int lastlvlcloc1 { get { return _lastlvlcloc1; } set { _lastlvlcloc1 = value; } }
    public static int lastlvlcloc2 { get { return _lastlvlcloc2; } set { _lastlvlcloc2 = value; } }

    public static double GetAlGrowSpeed()
    {
        if (AlGlobalVar.LevelValue == 2)
        {
            switch (level2choice) // al grows at different speeds depending on player's choice at start of stage 2
            {
                case 0: return 1;
                case 1: return 2;
                case 2: return 0.5;
                default: return 1;
            }
        }
        else
        {
            return 1;
        }
    }

    public static GameObject FindObject(GameObject parent, string name)
    {
        Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
        foreach (Transform t in trs)
        {
            if (t.name == name)
            {
                return t.gameObject;
            }
        }
        return null;
    }
}
