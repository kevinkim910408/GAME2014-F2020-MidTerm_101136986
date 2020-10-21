using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///Student name : Junho Kim
///Student ID : 101136986
///Source file name : EnemyController.cs
///Date last modified : October, 21. 2020
///Program description : To controll the Enemies (ex: movement, checking boundary, )
///Revision history : October, 21. 2020 : Modify Enemy speed and boundary to vertical mode, inline comments
/// </summary>

public class EnemyController : MonoBehaviour
{
    #region Variables
    [Header("Enemy Speed")]
    public float verticalSpeed;
    //public float horizontalSpeed;

    [Header("Enemy Boundary")]
    public float verticalBoundary;
    //public float horizontalBoundary;

    [Header("Enemy Direction")]
    public float direction;

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
    private void _Move()
    {
        transform.position += new Vector3(0.0f, verticalSpeed * direction * Time.deltaTime, 0.0f);
    }

    private void _CheckBounds()
    {
        // check right boundary
        if (transform.position.y >= verticalBoundary)
        {
            direction = -1.0f;
        }

        // check left boundary
        if (transform.position.y <= -verticalBoundary)
        {
            direction = 1.0f;
        }
    }
    #endregion
}
