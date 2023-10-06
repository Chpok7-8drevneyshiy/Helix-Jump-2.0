using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] public List<Material> Materials = new List<Material>();
    public int ColorCount= 3;
    public float TimeToChangeColor =5f;
    private void Awake()
    {
        TakeMaterial();
        StartCoroutine(ChangeColor());
    }
    private IEnumerator ChangeColor()
    {
        EventManager.DoColored(RandomMaterial());
        Debug.Log("sdelalasya");
        yield return new WaitForSeconds(TimeToChangeColor);
        StartCoroutine(ChangeColor());
    }

    private void TakeMaterial()
    {
        if (ColorCount > Materials.Count)
        {
            Debug.LogError("ColorCount>Materials");
        }
        while (Materials.Count > ColorCount)
        {
            Materials.Remove(Materials[Random.Range(0, Materials.Count)]);
        }
    }
    private Material RandomMaterial()
    {
        return Materials[Random.Range(0, Materials.Count)];
    }

}
