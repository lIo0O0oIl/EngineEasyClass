using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour  //��ũ ������
{
    private Vector2 movementVector;
    private Rigidbody2D rigidbody2D;

    public float maxSpeed = 70f;
    public float rotationSpeed = 200;
    public float acceleration = 70f;
    public float deacceleration = 50f;

    private float currentSpeed = 0f;
    private float currentForewardDirection = 1f;

    private void Awake()
    {
        rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;   //�μ��� �޾ƿ� ���� �� �����Ʈ�� �־���
        CalculateSpeed(movementVector);
        if (movementVector.y > 0)
        {
            currentForewardDirection = 1f;
        }
        else if (movementVector.y < 0)
        {
            currentForewardDirection = -1f;
        }
    }

    private void CalculateSpeed(Vector2 movementVector)
    {
        if (Mathf.Abs(movementVector.y) > 0)
        {
            currentSpeed += acceleration * Time.deltaTime;
        }
        else
        {
            currentSpeed -= deacceleration * Time.deltaTime;
        }

        currentSpeed = Mathf.Clamp(currentSpeed, 0, maxSpeed);
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = (Vector2)transform.up * currentSpeed * currentForewardDirection * Time.fixedDeltaTime;   //���� �� �������� �ٵ� �������� �޶���
        rigidbody2D.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime)); //��, ���� ������ �� ȸ����
    }
}
