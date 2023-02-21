using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularObject : MonoBehaviour
{
    [SerializeField, Tooltip("Degree per second")] 
    protected float AngularMovementSpeed = 0;

    [SerializeField, Tooltip("Meter per second")] 
    protected float DepthMovementSpeed = 0;

    const float AutoKillDistance = 1000;
    
    protected void RotateCCW()
    {
        transform.Rotate(0, 0, -AngularMovementSpeed * Time.deltaTime);
    }

    protected void RotateCW()
    {
        transform.Rotate(0, 0, AngularMovementSpeed * Time.deltaTime);
    }

    protected virtual void Update() 
    {
        transform.position += Vector3.forward * DepthMovementSpeed;

        if (transform.position.z >= AutoKillDistance || transform.position.z <= -AutoKillDistance)
            Destroy(gameObject);
    }

}
