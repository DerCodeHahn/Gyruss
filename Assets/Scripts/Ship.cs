using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Ship : CircularObject
{
    [SerializeField] InputActionReference MoveCW;
    [SerializeField] InputActionReference MoveCCW;

    void Start()
    {
        MoveCW.action.Enable();
        MoveCCW.action.Enable();
    }


    void Update()
    {
        if (MoveCW.action.IsPressed())
        {
            RotateCW();
        }

        if (MoveCCW.action.IsPressed())
        {
            RotateCCW();
        }
    }


}
