using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPlatform : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _spawnPoint;


    private void Awake()
    {
        Instantiate(_ball, _spawnPoint.transform.position, Quaternion.Euler(-90,0,0));
    }
}
