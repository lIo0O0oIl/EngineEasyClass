using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTurret : MonoBehaviour  //터렛이 마우스 위치에 따라 움직이는 것
{
    public float turretRotationSpeed = 150f;

    public void Aim(Vector2 pointerPosition)
    {
        var turretDirection = (Vector3)pointerPosition - transform.position;    //마우스 움직임 - 탱크의 현재 위치
        var desireAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;    //라디안이랑 앵글값을 반환
        var rotationStep = turretRotationSpeed * Time.deltaTime;    //회전 속도를 델다 타임으로 해준것
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desireAngle - 90), rotationStep); //쿼터니언 움직임 현재 여기 부터 저기 까지 어떤 속도로
                                                                                                                                         //부모의 회전을 바꾸어 자식의 회전 값도 변경되게

    }
}
