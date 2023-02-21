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
    new Rigidbody rigidbody;
    protected virtual void Awake() 
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    
    protected void RotateCCW()
    {
        rigidbody.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -AngularMovementSpeed * Time.fixedDeltaTime));
    }

    protected void RotateCW()
    {
        rigidbody.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, AngularMovementSpeed * Time.fixedDeltaTime));
    }

    protected virtual void FixedUpdate() 
    {
        rigidbody.MovePosition(transform.position + Vector3.forward * DepthMovementSpeed * Time.fixedDeltaTime);

        if (transform.position.z >= AutoKillDistance || transform.position.z <= -AutoKillDistance)
            Destroy(gameObject);
    }

}
