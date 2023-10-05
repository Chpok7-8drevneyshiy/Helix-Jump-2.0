using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlatform : MonoBehaviour
{

    [SerializeField] private List<Material> materials = new List<Material>();

    private void Start()
    {
        Color();
    }
    private void Color()
    {
        foreach (Transform child in transform)
        child.GetComponent<Renderer>().material = materials[Random.Range(0, materials.Count)];
    }
}
