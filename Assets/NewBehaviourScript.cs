using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Vector3 movePoint; // �̵� ��ġ ����
    public Vector3 movePoint_Rounded; // �̵� ��ġ �ݿø� ����
    public Camera mainCamera; // ���� ī�޶�

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {

        // ��Ŭ�� �̺�Ʈ�� ���Դٸ�
        if (Input.GetMouseButtonUp(0))
        {
            // ī�޶󿡼� �������� ���.
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            // Scence ���� ī�޶󿡼� ������ ������ ������ Ȯ���ϱ�
            Debug.DrawRay(ray.origin, ray.direction * 10f, Color.red, 1f);

            // �������� ������ �¾Ҵٸ�
            if (Physics.Raycast(ray, out RaycastHit raycastHit))
            {
                // ���� ��ġ�� �������� ����
                movePoint = raycastHit.point;
                movePoint_Rounded.Set(Mathf.Round(movePoint.x), Mathf.Round(movePoint.y), Mathf.Round(movePoint.z));
                Debug.Log("movePoint : " + movePoint.ToString());
                Debug.Log("movePoint_Rounded : " + movePoint_Rounded.ToString());
                Debug.Log("���� ��ü : " + raycastHit.transform.name);

                CreateWall();
            }
        }

    }

    void CreateWall()
    {
        Debug.Log("��ü ������");
    }
}
