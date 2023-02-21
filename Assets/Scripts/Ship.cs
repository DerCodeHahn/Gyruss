using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Ship : CircularObject
{
    [SerializeField] InputActionReference MoveCW;
    [SerializeField] InputActionReference MoveCCW;
    [SerializeField] InputActionReference ShootInput;
    [SerializeField] GameObject ShotPrefab;
    [SerializeField] Transform ShotsParent;

    [SerializeField] float shootingSpeed;

    float shotTimer;
    bool shooting = false;

    void Start()
    {
        MoveCW.action.Enable();
        MoveCCW.action.Enable();
        ShootInput.action.Enable();
    }


    void Update()
    {
        ReadUserInput();

        shotTimer += Time.deltaTime;
        if (shotTimer >= shootingSpeed && shooting)
        {
            Shoot();
            shotTimer = 0;
        }
    }


    private void ReadUserInput()
    {
        if (MoveCW.action.IsPressed())
            RotateCW();

        if (MoveCCW.action.IsPressed())
            RotateCCW();

        shooting = ShootInput.action.IsPressed();
    }

    private void Shoot()
    {
        GameObject shot = Instantiate(ShotPrefab, ShotsParent);
        shot.transform.rotation = transform.rotation;
    }
}
