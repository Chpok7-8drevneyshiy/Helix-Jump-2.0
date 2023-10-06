using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] public List<Material> Materials = new List<Material>();
    [SerializeField] private List<string> MaterialsName = new List<string>();
    private void Awake()
    {
        TakeColor();
        Debug.Log(MaterialsName);
        for (int i = 0; i < Materials.Count; i++)
        {
            MaterialsName.Add(Materials[i].name);
        }
        StartCoroutine(ChangeColor());
    }
    private IEnumerator ChangeColor()
    {
        EventManager.DoColored(RandomMaterial());
        Debug.Log("sdelalasya");
        yield return new WaitForSeconds(3f);
        StartCoroutine(ChangeColor());
    }

    private void TakeColor()
    {
        while (Materials.Count >3)
        {
            Materials.Remove(Materials[Random.Range(0, Materials.Count)]);
        }
    }
    private string RandomMaterial()
    {
        return MaterialsName[Random.Range(0, Materials.Count)];
    }

}
