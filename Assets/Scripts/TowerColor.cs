using UnityEngine;
public class TowerColor : MonoBehaviour
{
    [SerializeField] private Tower _tower;
    private void Awake()
    {
        EventManager.Colored += GetColor;
    }
    private void GetColor(Material color)
    {   
        if (_tower == null)
            _tower = FindObjectOfType<Tower>();

        _tower.GetComponent<MeshRenderer>().material = color;
    }
    private void OnDestroy()
    {
        EventManager.Colored -= GetColor;
    }
}
