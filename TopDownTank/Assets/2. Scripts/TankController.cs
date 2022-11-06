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

    public void HandleShoot()   //슈팅하는것
    {
        foreach (var turret in turrets) //터렛이 2개 이상일 때 총알 발사 많이 하려고
        {
            turret.Shoot();
        }
    }

    public void HandleMoveBody(Vector2 movementVector)  //탱크 움직임
    {
        tankMover.Move(movementVector);
    }

    public void HandleMoveTurret(Vector2 pointerPosition)   //탱크 터렛 움직임
    {
        aimTurret.Aim(pointerPosition);
    }

}
