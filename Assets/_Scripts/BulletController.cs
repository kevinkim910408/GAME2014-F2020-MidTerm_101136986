using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///Student name : Junho Kim
///Student ID : 101136986
///Source file name : BulletController.cs
///Date last modified : October, 21. 2020
///Program description : To controll the Bullets (ex: speed, checking boundary and damage )
///Revision history : October, 21. 2020 : Modify Bullets speed and boundary to vertical mode, inline comments
/// </summary>

public class BulletController : MonoBehaviour, IApplyDamage
{
    #region Variables
    // to use bullet manager
    public BulletManager bulletManager;

    [Header("Bullet Speed")]
    public float horizontalSpeed;
    //public float verticalSpeed;

    [Header("Bullet Boundary")]
    public float horizontalBoundary;
    //public float verticalBoundary;

    [Header("Bullet damage")]
    public int damage;


    #endregion

    #region Unity_Method
    // Start is called before the first frame update
    void Start()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }
    // Update is called once per frame
    void Update()
    {
        _Move();
        _CheckBounds();
    }

    #endregion

    #region Custom_Method
    // to move bullets
    private void _Move()
    {
        transform.position += new Vector3(horizontalSpeed, 0.0f, 0.0f) * Time.deltaTime;
    }

    // to check bounds and for the bullets
    private void _CheckBounds()
    {
        if (transform.position.x > horizontalBoundary)
        {
            bulletManager.ReturnBullet(gameObject);
        }
            
    }

    // to apply damage
    public int ApplyDamage()
    {
        return damage;
    }
    #endregion

    #region Trigger_Method
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Debug.Log(other.gameObject.name);
        bulletManager.ReturnBullet(gameObject);
    }
    #endregion
}
