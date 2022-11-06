using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTurret : MonoBehaviour  //�ͷ��� ���콺 ��ġ�� ���� �����̴� ��
{
    public float turretRotationSpeed = 150f;

    public void Aim(Vector2 pointerPosition)
    {
        var turretDirection = (Vector3)pointerPosition - transform.position;    //���콺 ������ - ��ũ�� ���� ��ġ
        var desireAngle = Mathf.Atan2(turretDirection.y, turretDirection.x) * Mathf.Rad2Deg;    //�����̶� �ޱ۰��� ��ȯ
        var rotationStep = turretRotationSpeed * Time.deltaTime;    //ȸ�� �ӵ��� ���� Ÿ������ ���ذ�
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 0, desireAngle - 90), rotationStep); //���ʹϾ� ������ ���� ���� ���� ���� ���� � �ӵ���
                                                                                                                                         //�θ��� ȸ���� �ٲپ� �ڽ��� ȸ�� ���� ����ǰ�

    }
}
