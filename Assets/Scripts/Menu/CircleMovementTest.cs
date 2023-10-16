using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CircleMovementTest : MonoBehaviour
{
    public Vector2 Velocity = new Vector2(1, 0);

    // rotational direction
    public bool Clockwise = true;

    [Range(0, 5)]
    public float RotateSpeed = 1f;
    [Range(0, 500)]
    public float RotateRadiusX = 1f;
    [Range(0, 500)]
    public float RotateRadiusY = 1f;

    private Vector2 _centre;
    private float _angle;

    private void Start()
    {
        _centre = transform.position;
    }

    private void Update()
    {
        rotaryMenu();
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_centre, 0.1f);
        Gizmos.DrawLine(_centre, transform.position);
    }

    public void rotaryMenu()
    {
        _centre += Velocity * Time.deltaTime;
        //_angle += (Clockwise ? RotateSpeed : -RotateSpeed) * Time.deltaTime;

        _angle = 0.8f;
        var x = Mathf.Sin(_angle) * RotateRadiusX;
        var y = Mathf.Cos(_angle) * RotateRadiusY;
        transform.position = new Vector2(x, y);   //_centre + 
    }

    public void isScroling()
    {

    }
}
