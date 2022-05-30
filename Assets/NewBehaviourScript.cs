using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Vector3 movePoint; // 이동 위치 저장
    public Vector3 movePoint_Rounded; // 이동 위치 반올림 저장
    public Camera mainCamera; // 메인 카메라

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {

        // 좌클릭 이벤트가 들어왔다면
        if (Input.GetMouseButtonUp(0))
        {
            // 카메라에서 레이저를 쏜다.
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            // Scence 에서 카메라에서 나오는 레이저 눈으로 확인하기
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);

            // 레이저가 뭔가에 맞았다면
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                // 맞은 위치를 목적지로 저장
                movePoint = raycastHit.point;
                movePoint_Rounded.Set(Mathf.Round(movePoint.x), Mathf.Round(movePoint.y), Mathf.Round(movePoint.z));
                Debug.Log("movePoint : " + movePoint.ToString());
                Debug.Log("movePoint_Rounded : " + movePoint_Rounded.ToString());
                Debug.Log("맞은 객체 : " + raycastHit.transform.name);

                CreateWall();
            }
        }

    }

    void CreateWall()
    {
        Debug.Log("객체 생성중");
    }
}
