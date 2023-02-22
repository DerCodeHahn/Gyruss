using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class Ship : CircularObject
{
    [SerializeField] InputActionReference MoveCW;
    [SerializeField] InputActionReference MoveCCW;
    [SerializeField] InputActionReference ShootInput;
    [SerializeField] GameObject ShotPrefab;
    [SerializeField] Transform ShotsParent;

    [SerializeField] float ShootingSpeed;
    [SerializeField] int Lives = 3;

    [SerializeField] LiveManager LiveManger;

    float shotTimer;
    bool shooting = false;

    void Start()
    {
        MoveCW.action.Enable();
        MoveCCW.action.Enable();
        ShootInput.action.Enable();

        LiveManger.SetLives(Lives);
    }


    void Update()
    {
        ReadUserInput();

        shotTimer += Time.deltaTime;
        if (shotTimer >= ShootingSpeed && shooting)
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

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.transform.parent.GetComponent<Enemy>();
        if (enemy is null || enemy.Dead)
            return;

        enemy.Dead = true;

        Destroy(other.transform.parent.gameObject);

        CameraShaker.Instance.Shake(CameraShaker.ShakeIntensity.Intense);

        Lives--;
        LiveManger.RemoveOne();

        if (Lives <= 0)
        {
            SceneManager.LoadScene(2);
        }


    }
}
