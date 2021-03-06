﻿using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEditor;
using UnityEngine;

/// <summary>
///Student name : Junho Kim
///Student ID : 101136986
///Source file name : PlayerController.cs
///Date last modified : October, 21. 2020
///Program description : To controll the Player (ex: movement with inputs, checking boundary, )
///Revision history : October, 21. 2020 : Touch Input change to vertical mode, Modify player speed and boundary to vertical mode, inline comments
/// </summary>

public class PlayerController : MonoBehaviour
{
    #region
    // to use bullet manager
    public BulletManager bulletManager;

    [Header("Boundary Check")]
    //public float horizontalBoundary;
    public float verticalBoundary;

    [Header("Player Speed")]
   // public float horizontalSpeed;
    public float verticalSpeed;
    public float maxSpeed;

    //public float horizontalTValue;
    public float verticalTValue;

    [Header("Bullet Firing")]
    public float fireDelay;

    // Private variables
    private Rigidbody2D m_rigidBody;
    private Vector3 m_touchesEnded;


    #endregion

    #region Unity_Method
    // Start is called before the first frame update
    void Start()
    {
        m_touchesEnded = new Vector3();
        m_rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
        _FireBullet();
    }

    #endregion

    #region Custom_Method

    // for firing bullets by frame count
    private void _FireBullet()
    {
        // delay bullet firing 
        if(Time.frameCount % 60 == 0 && bulletManager.HasBullets())
        {
            bulletManager.GetBullet(transform.position);
        }
    }

    // player movement with touch screen and keyboard
    private void _Move()
    {
        float direction = 0.0f;

        // touch input support
        foreach (var touch in Input.touches)
        {
            var worldTouch = Camera.main.ScreenToWorldPoint(touch.position);

            if (worldTouch.x > transform.position.y)
            {
                // direction is positive
                direction = 1.0f;
            }

            if (worldTouch.x < transform.position.y)
            {
                // direction is negative
                direction = -1.0f;
            }

            m_touchesEnded = worldTouch;

        }

        // keyboard support
        if (Input.GetAxis("Vertical") >= 0.1f) 
        {
            // direction is positive
            direction = 1.0f;
        }

        if (Input.GetAxis("Vertical") <= -0.1f)
        {
            // direction is negative
            direction = -1.0f;
        }

        if (m_touchesEnded.y != 0.0f)
        {
            transform.position = new Vector2(transform.position.x, Mathf.Lerp(transform.position.y, m_touchesEnded.y, verticalTValue));
        }
        else
        {
            Vector2 newVelocity = m_rigidBody.velocity + new Vector2(0.0f, direction * verticalSpeed);
            m_rigidBody.velocity = Vector2.ClampMagnitude(newVelocity, maxSpeed);
            m_rigidBody.velocity *= 0.99f;
        }
    }

    // player boundary check, so player cannot go out of the screen
    private void _CheckBounds()
    {
        // check right bounds
        if (transform.position.y >= verticalBoundary)
        {
            //transform.position = new Vector3(verticalBoundary, transform.position.y, 0.0f);
            transform.position = new Vector3(transform.position.x, verticalBoundary, 0.0f);
        }

        // check left bounds
        if (transform.position.y <= -verticalBoundary)
        {
            //transform.position = new Vector3(-verticalBoundary, transform.position.y, 0.0f);
            transform.position = new Vector3(transform.position.x, -verticalBoundary, 0.0f);
        }

    }

    #endregion
}
