using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTracker : MonoBehaviour
{
    [SerializeField] private Vector3 _directionOffset;
    [SerializeField] private float _lenght;
    private Vector3 _cameraPostion;
    private Vector3 _minimalBallPosition;
    private Ball _ball;
    private Tower _tower;


    private void Start()
    {
        _ball = FindObjectOfType<Ball>();
        _tower = FindObjectOfType<Tower>();

        _cameraPostion = _ball.transform.position;
        _minimalBallPosition = _ball.transform.position;

        TrackBall();
    }
    private void Update()
    {
        if (_ball.transform.position.y < _minimalBallPosition.y) 
        {
            TrackBall();
            _minimalBallPosition = _ball.transform.position;
        }
    }
    private void TrackBall()
    {
        Vector3 towerPosition = _tower.transform.position;
        towerPosition.y = _ball.transform.position.y;
        _cameraPostion = _ball.transform.position;
        Vector3 direction = (towerPosition - _ball.transform.position).normalized + _directionOffset;
        _cameraPostion -= direction * _lenght;
        transform.position = _cameraPostion;
        transform.LookAt(_ball.transform);
    }
}
