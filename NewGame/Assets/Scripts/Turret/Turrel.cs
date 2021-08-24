﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrel : MonoBehaviour
{
    private Transform _target;
    [SerializeField] private Transform _head;
    [SerializeField] private float _speed = 1f;
    public float angle;

    void Start()
    {
        _target = FindObjectOfType<PlayerCharacter>().transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = (_target.position - _head.position);

        Vector3 StepDir = Vector3.RotateTowards(_head.forward, dir, _speed * Time.deltaTime, 0f);
        angle = Vector3.Angle(_head.forward, dir);

        _head.rotation = Quaternion.LookRotation(StepDir);

    }
}
