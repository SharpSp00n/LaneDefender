using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public PlayerInput MyPlayerInput;
    public InputAction MoveAction;
    public InputAction restartAction;
    private Rigidbody2D rb2d;
    public InputAction ShootAction;
    public InputAction QuitAction;
    public GameObject Bullet;
    public Transform BulletSpawn;
    public GameObject explosion;
    public float Timer;

    public float fireRate = .5f; 
    private float fireTimer = 0f;
    private bool isShooting = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        MyPlayerInput.currentActionMap.Enable();
        MoveAction = MyPlayerInput.currentActionMap.FindAction("Move");
        MoveAction.canceled += Handle_MoveActionCanceled;
        ShootAction = MyPlayerInput.currentActionMap.FindAction("shoot");
        ShootAction.started += ShootAction_started;
        restartAction = MyPlayerInput.currentActionMap.FindAction("restart");
        restartAction.started += restartAction_started;
        QuitAction.started += QuitAction_started;
        ShootAction.canceled += Handle_ShootActionCanceled;


    }

    private void Handle_ShootActionCanceled(InputAction.CallbackContext context)
    {
        isShooting = false;
    }

    private void QuitAction_started(InputAction.CallbackContext context)
    {
        Application.Quit();
    }

    private void restartAction_started(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(0);
    }

    private void ShootAction_started(InputAction.CallbackContext context)
    {
        
        isShooting = true;

    }


    private void Handle_MoveActionCanceled(InputAction.CallbackContext context)
    {

    }

    private void ShotBullet()
    {
        Vector3 spawnPosition = new Vector3(BulletSpawn.position.x, BulletSpawn.position.y + .5f, BulletSpawn.position.z);
        Instantiate(Bullet, spawnPosition, Quaternion.identity);
        explosion.SetActive(true);
        Timer = 1;
       

    } 

    // Update is called once per frame
    void Update()
    {
        rb2d.linearVelocity = MoveAction.ReadValue<Vector2>() * 5f;
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            explosion.SetActive(false);
        }

        if (isShooting)
        {
            fireTimer -= Time.deltaTime;
            if (fireTimer <= 0f)
            {
                ShotBullet();
                fireTimer = fireRate;
            }
        }


    }

    private void OnDestroy()
    {
        restartAction.started -= restartAction_started;
        QuitAction.started -= QuitAction_started;
        ShootAction.canceled -= Handle_ShootActionCanceled;
        MoveAction.canceled -= Handle_MoveActionCanceled;
        ShootAction.started -= ShootAction_started;
    }

}
