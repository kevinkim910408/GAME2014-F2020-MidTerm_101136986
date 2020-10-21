using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///Student name : Junho Kim
///Student ID : 101136986
///Source file name : BackgroundController.cs
///Date last modified : October, 21. 2020
///Program description : To controll the backgrounds (ex: scrolling)
///Revision history : October, 21. 2020 : Added the speed and boundary for horizontal mode, changed the functions' variables to horizontal mode, Inline comments
/// </summary>

public class BackgroundController : MonoBehaviour
{
    #region Variables
    //public float verticalSpeed;         // y - axis
    //public float verticalBoundary;

    [Header("Scrolling Speed")]
    public float horizontalSpeed;          // x - axis

    [Header("Boundary Check")]
    public float horizontalBoundary;

    #endregion

    #region Unity_Method
    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    #endregion

    #region Custom_Method

    // to reset background position
    private void _Reset()
    {
        transform.position = new Vector3(horizontalBoundary, 0.0f);
    }

    // background move horizontally. ( right side to left side)
    private void _Move()
    {
        transform.position -= new Vector3(horizontalSpeed, 0.0f) * Time.deltaTime;
    }

    // to check bounds. If backgrounds hit this bounds, reset their position.
    private void _CheckBounds()
    {
        // if the background is lower than the bottom of the screen then reset
        if (transform.position.x <= -horizontalBoundary)
        {
            _Reset();
        }
    }
    #endregion
}
