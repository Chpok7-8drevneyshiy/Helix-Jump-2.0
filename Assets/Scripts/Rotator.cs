using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Rotator : MonoBehaviour
{
    [SerializeField] private float _rotaionSpeed;

    private Rigidbody _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.touchCount > 0 ) 
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float tortque = touch.deltaPosition.x * _rotaionSpeed * Time.deltaTime;
                _rigidbody.AddTorque(Vector3.up * -tortque);
            }
        }
    }
}
