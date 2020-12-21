﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltTarget : MonoBehaviour
{
    public float speed = 5;
    

    float horizontalInput;
    public float horizontalMultiplier = 2f;

    bool grounded;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
{
    Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
    Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
    rb.MovePosition(rb.position + forwardMove + horizontalMove);
}
// Update is called once per frame
void Update()
{
    horizontalInput = Input.GetAxis("Horizontal");
    Vector3 clampedPosition = transform.position;
    clampedPosition.x = Mathf.Clamp(transform.position.x, -4.3f, 4.3f);
    //clampedPosition.y = Mathf.Clamp(transform.position.y, 0f, 2.85f);
    transform.position = clampedPosition;

}
}