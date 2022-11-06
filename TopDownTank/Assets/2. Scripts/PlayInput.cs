using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayInput : MonoBehaviour
{
    private Camera mainCamera;

    public UnityEvent OnShoot = new UnityEvent();   //발사하는 이벤트
    public UnityEvent<Vector2> OnMoveBody = new UnityEvent<Vector2>();  //x, y를 받아서 움직이게
    public UnityEvent<Vector2> OnMoveTurret = new UnityEvent<Vector2>();    //마우스 움직임

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

    private void GetShootingInput() //슈팅
    {
        if (Input.GetMouseButtonDown(0))    //왼쪽 버튼을 눌렀을 때.
        {
            OnShoot?.Invoke();
        }
    }

    private void GetTurretMoveMent()    //마우스 위치에 따른 터렛 움직임
    {
        OnMoveTurret?.Invoke(GetMousePosition());   //마우스 위치에 따른 움직임.
    }

    private Vector2 GetMousePosition()
    {
        Vector3 mousePosition = Input.mousePosition;
        //Vector2 mousePosition = Input.mousePosition;  //이건 2차원으로 하기 위해서 3차원으로 더 분명하게 하고 싶으면 위 아래 코드 쓰기
        mousePosition.z = mainCamera.nearClipPlane;     //이건 카메라에 보이는 가장 처음 부분임. 3차원에서 네모에서 카메라 바로 앞에 있는 사각형임
        Vector2 mouseWorldPosition = mainCamera.ScreenToWorldPoint(mousePosition);     //월드 포지션에 따른 마우스 위치 가져오기
        return mouseWorldPosition;
    }

    private void GetBodyMoveMnet()  //탱크의 움직임
    {
        Vector2 MovementVector = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); //가로 세로 움직임
        OnMoveBody?.Invoke(MovementVector.normalized);  //함수 실행하는거
    }
}
