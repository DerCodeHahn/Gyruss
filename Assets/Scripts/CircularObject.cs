using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularObject : MonoBehaviour
{
    [SerializeField,Tooltip("Degree per second")] protected float MovementSpeed = 10f;

    protected void RotateCCW()
    {
        transform.Rotate(0, 0, MovementSpeed * Time.deltaTime);
    }

    protected void RotateCW()
    {
        transform.Rotate(0, 0, -MovementSpeed * Time.deltaTime);
    }

}
