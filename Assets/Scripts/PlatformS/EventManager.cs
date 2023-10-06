using System;
using UnityEngine;

public class EventManager
{
    public static Action<Material> Colored;
    public static void DoColored(Material colorName)
    {
        Colored?.Invoke(colorName);
    }   
}