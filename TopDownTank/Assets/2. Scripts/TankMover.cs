using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour  //��ũ ������
{
    private Vector2 movementVector;
    private Rigidbody2D rigidbody2D;

    public float maxSpeed = 70f;
    public float rotationSpeed = 200;

    private void Awake()
    {
        rigidbody2D = GetComponentInParent<Rigidbody2D>();
    }

    public void Move(Vector2 movementVector)
    {
        this.movementVector = movementVector;   //�μ��� �޾ƿ� ���� �� �����Ʈ�� �־���
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = (Vector2)transform.up * movementVector.y * maxSpeed * Time.fixedDeltaTime;   //���� �� �������� �ٵ� �������� �޶���
        rigidbody2D.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime)); //��, ���� ������ �� ȸ����
    }
}
