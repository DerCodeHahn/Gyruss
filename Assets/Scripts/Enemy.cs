using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Enemy : CircularObject
{
    [SerializeField] float health;
    [SerializeField] float ScaleUpTime = 0.5f;

    private void Awake()
    {
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
                Destroy(gameObject);
            Destroy(shot.gameObject);
        }
    }

    protected override void Update()
    {
        base.Update();
        RotateCCW();
    }

    private void OnDestroy()
    {
        transform.DOKill();
    }
}
