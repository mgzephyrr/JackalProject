using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControled : MonoBehaviour
{
    public float rotateSpeed = 10.0f; //��������, � ������� ��������� ������

    private float mult = 1f;

    private void Update()
    {
        float rotate = 0f;
        if (Input.GetKey(KeyCode.Q)) //���� ������ ������� Q, �� ������ ��������� �� ������� �������
            rotate = -1f;
        else if (Input.GetKey(KeyCode.E)) //���� ������ ������� Q, �� ������ ��������� ������ ������� �������
            rotate = 1f;
        //��������� �������� ������ �� ���������� y
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate, Space.World);

    }

}
