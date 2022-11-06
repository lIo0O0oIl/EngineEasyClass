using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMover : MonoBehaviour  //탱크 움직임
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
        this.movementVector = movementVector;   //인수를 받아온 것을 내 무브먼트에 넣어줌
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = (Vector2)transform.up * movementVector.y * maxSpeed * Time.fixedDeltaTime;   //나를 위 방향으로 바디 움직임이 달라짐
        rigidbody2D.MoveRotation(transform.rotation * Quaternion.Euler(0, 0, -movementVector.x * rotationSpeed * Time.fixedDeltaTime)); //왼, 오를 눌렀을 때 회전함
    }
}
