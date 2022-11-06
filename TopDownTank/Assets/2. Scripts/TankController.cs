using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    public TankMover tankMover;
    public AimTurret aimTurret;
    public Turret[] turrets;

    private void Awake()
    {
        tankMover = GetComponentInChildren<TankMover>();
        aimTurret = GetComponentInChildren<AimTurret>();
        turrets = GetComponentsInChildren<Turret>();
    }

    public void HandleShoot()   //�����ϴ°�
    {
        foreach (var turret in turrets) //�ͷ��� 2�� �̻��� �� �Ѿ� �߻� ���� �Ϸ���
        {
            turret.Shoot();
        }
    }

    public void HandleMoveBody(Vector2 movementVector)  //��ũ ������
    {
        tankMover.Move(movementVector);
    }

    public void HandleMoveTurret(Vector2 pointerPosition)   //��ũ �ͷ� ������
    {
        aimTurret.Aim(pointerPosition);
    }

}
