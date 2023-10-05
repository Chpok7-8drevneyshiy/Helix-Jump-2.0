using System;

public class EventManager
{
    public static Action<string> Colored;
    public static void DoColored(string colorName)
    {
        Colored?.Invoke(colorName);
    }   
}