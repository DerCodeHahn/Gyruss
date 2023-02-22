using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Enemy : CircularObject
{

    [SerializeField, Header("Enemy spezific")] float health;
    [SerializeField] float ScaleUpTime = 0.5f;
    [SerializeField] AnimationCurve PointsDistanceMapping;
    [SerializeField] int MaxPoints = 1000;

    [SerializeField] Transform bodyPosition;

    private void Awake()
    {
        base.Awake();
        transform.localScale = Vector3.zero;
        transform.DOScale(Vector3.one, ScaleUpTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        Shot shot = other.gameObject.GetComponent<Shot>();

        if (shot is not null)
        {
            health -= shot.Damage;
            if (health <= 0)
                KillEnemy();
            
            Destroy(shot.gameObject);
        }
    }

    void KillEnemy()
    {
        Destroy(gameObject);

        float amountTraveld =  transform.position.z / transform.parent.position.z;
        float currentPoints = PointsDistanceMapping.Evaluate(1-amountTraveld) * MaxPoints;

        //Debug.Log($"Killed at Distance {amountTraveld} Got {currentPoints} Points");

        ScoreManager.Instance.AddScore((int)currentPoints, bodyPosition.position );
    }

    protected override void FixedUpdate()
    {
        RotateCCW();
        base.FixedUpdate();
        
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
