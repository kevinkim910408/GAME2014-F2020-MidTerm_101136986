using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///Student name : Junho Kim
///Student ID : 101136986
///Source file name : BackgroundController.cs
///Date last modified : October, 21. 2020
///Program description : To controll the backgrounds (ex: scrolling)
///Revision history : October, 21. 2020 : Added the speed and boundary for horizontal mode, changed the functions' variables to horizontal mode
/// </summary>

public class BackgroundController : MonoBehaviour
{
    //public float verticalSpeed;         // y - axis
    //public float verticalBoundary;
    public float horizontalSpeed;          // x - axis
    public float horizontalBoundary;

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    private void _Reset()
    {
        transform.position = new Vector3(horizontalBoundary, 0.0f);
    }

    private void _Move()
    {
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
    }

    private void _CheckBounds()
    {
        // if the background is lower than the bottom of the screen then reset
        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
        }
    }
}
