using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : CircularObject
{
    [SerializeField] float damage = 1;

    public float Damage { get => damage; }

    void Start()
    {

    }

}
