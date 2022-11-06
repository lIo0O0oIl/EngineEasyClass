using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayInput : MonoBehaviour
{
    private Camera mainCamera;

    public UnityEvent OnShoot = new UnityEvent();   //�߻��ϴ� �̺�Ʈ
    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();  //x, y�� �޾Ƽ� �����̰�
    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();    //���콺 ������

    private void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        GetBodyMoveMnet();
        GetTurretMoveMent();
        GetShootingInput();
    }

    private void GetShootingInput() //����
    {
        if (Input.GetMouseButtonDown(0))    //���� ��ư�� ������ ��.
        {
            OnShoot?.Invoke();
        }
    }

    private void GetTurretMoveMent()    //���콺 ��ġ�� ���� �ͷ� ������
    {
        OnMoveTurret?.Invoke(GetMousePosition());   //���콺 ��ġ�� ���� ������.
    }

    private Vector2 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        //Vector2 mousePosition = Input.mousePosition;  //�̰� 2�������� �ϱ� ���ؼ� 3�������� �� �и��ϰ� �ϰ� ������ �� �Ʒ� �ڵ� ����
        mousePosition.z = mainCamera.nearClipPlane;     //�̰� ī�޶� ���̴� ���� ó�� �κ���. 3�������� �׸𿡼� ī�޶� �ٷ� �տ� �ִ� �簢����
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);     //���� �����ǿ� ���� ���콺 ��ġ ��������
        return mouseWorldPosition;
    }

    private void GetBodyMoveMnet()  //��ũ�� ������
    {
        Vector2 MovementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //���� ���� ������
        OnMoveBody?.Invoke(MovementVector.normalized);  //�Լ� �����ϴ°�
    }
}
