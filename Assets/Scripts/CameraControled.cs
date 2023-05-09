using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControled : MonoBehaviour
{
    public float rotateSpeed = 10.0f; //��������, � ������� ��������� ������
    public float speed = 10.0f; //�������� �������� ������
    private float zoomSpeed = 1000.0f; //�������� ����������� � ��������� ������

    private float mult = 1f; //���������

    private void Update()
    {
        //���������� ����� ��� ��������
        float horizont = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float rotate = 0f; //���������� � ����� ������� ������������ ������
        if (Input.GetKey(KeyCode.Q)) //���� ������ ������� Q, �� ������ ��������� �� ������� �������
            rotate = -1f;
        else if (Input.GetKey(KeyCode.E)) //���� ������ ������� Q, �� ������ ��������� ������ ������� �������
            rotate = 1f;
        //��������� �������� ������ �� ���������� y
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate * mult, Space.World);

        //��������� ������ �� ������� Shift
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            mult = 3f;
        else mult = 1f;

        //�������� ������
        transform.Translate(new Vector3(horizont, 0, vertical) * Time.deltaTime * mult * speed, Space.Self);

        //����������� � ��������� ������ ��� �������� �������� ����
        transform.position += transform.up * zoomSpeed * Time.deltaTime * mult * Input.GetAxis("Mouse ScrollWheel");

        //����������� �� ������� ������� �������� ��� ����������� ������ �� ���������� y
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, 5f, 20f),
            transform.position.z);
    }

}
