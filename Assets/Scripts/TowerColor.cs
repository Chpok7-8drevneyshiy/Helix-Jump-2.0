using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerColor : MonoBehaviour
{
    [SerializeField] Color _color;

    private void Initialize()
    {
        EventManager.Colored += GetColor;
    }

    private void GetColor(string color)
    {

    }
}
