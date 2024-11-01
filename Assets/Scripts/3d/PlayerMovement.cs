﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 3f;
    public float turnSpeed = 10f;
    public bool isEnd = false;

    private Animator animator;
    private Rigidbody rb;

    private Vector3 move;
    private float forwardAmount;
    private float turnAmount;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        UpdateAnim();
    }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void ProcessInput()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (isEnd)
        {
            x = 0;
            z = 0;
        }

        move = new Vector3(x, 0, z);
        Vector3 localMove = transform.InverseTransformVector(move);

        forwardAmount = localMove.z;
        turnAmount = Mathf.Atan2(localMove.x, localMove.z);

        if (Input.GetButton("Fire3"))
        {
            forwardAmount *= 0.3f;
        }
    }

    private void MovePlayer()
    {
        rb.AddForce(forwardAmount * transform.forward * forwardSpeed, ForceMode.VelocityChange);
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0, turnAmount * turnSpeed, 0));
    }

    private void UpdateAnim()
    {
        animator.SetFloat("Forward", forwardAmount * forwardSpeed);
        animator.SetFloat("Turn", turnAmount * turnSpeed);
    }
}
