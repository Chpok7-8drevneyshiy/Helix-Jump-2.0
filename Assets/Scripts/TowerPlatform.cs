using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlatform : MonoBehaviour
{

    public List<Material> materials = new List<Material>();

    private  void Start()
    {
        materials = new List<Material>(FindObjectOfType<ColorChanger>().Materials);
        for (int i = 0; i < FindObjectOfType<ColorChanger>().Materials.Count; i++)
        {
            materials.Add(FindObjectOfType<ColorChanger>().Materials[i]);
        }
        Color();
    }
    private void Color()
    {
        foreach (Transform child in transform)
        if (child.GetComponent<MeshRenderer>() && child.GetComponent<Plane>() == null)
        child.GetComponent<Renderer>().material = materials[Random.Range(0, materials.Count)];
    }
}
