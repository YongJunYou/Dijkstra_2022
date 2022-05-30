using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUnit : MonoBehaviour
{
    public float speed;      // ĳ���� ������ ���ǵ�
    public CharacterController characterController; // ĳ���� ��Ʈ�ѷ�
    public Vector3 movePoint; // �̵� ��ġ ����
    public Vector3 movePoint_Rounded; // �̵� ��ġ �ݿø� ����
    public Camera mainCamera; // ���� ī�޶�

    void Start()
    {
        speed = 4.0f;
        mainCamera = Camera.main;
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {

        // ��Ŭ�� �̺�Ʈ�� ���Դٸ�
        if (Input.GetMouseButtonUp(1))
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

            }
        }

        // ���������� �Ÿ��� 0.1f ���� �ִٸ�
        if (Vector3.Distance(transform.position, movePoint) > 0.1f)
        {
            // �̵�
            Move();
        }

    }

    void Move()
    {
        // thisUpdatePoint �� �̹� ������Ʈ(������) ���� �̵��� ����Ʈ�� ��� ������.
        // �̵��� ����(�̵��� ��-���� ��ġ) ���ϱ� �ӵ��� �ؼ� �̵��� ��ġ���� ����Ѵ�.
        Vector3 thisUpdatePoint = (movePoint_Rounded - transform.position).normalized * speed;
        // characterController �� ĳ���� �̵��� ����ϴ� ������Ʈ��.
        // simpleMove �� �ڵ����� �߷��� ����ؼ� �̵������ִ� �޼ҵ��.
        // ������ �̵��� ����Ʈ�� �������ָ� �ȴ�.
        characterController.SimpleMove(thisUpdatePoint);
    }
}