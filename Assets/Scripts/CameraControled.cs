using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControled : MonoBehaviour
{
    public float rotateSpeed = 0.1f; //��������, � ������� ��������� ������
    public float speed = 5.0f; //�������� �������� ������
    public float zoomSpeed = 100.0f; //�������� ����������� � ���������

    private float mult = 1f; //���������

    //��� �������� ������ ������
    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;

    public float sensitivityHor = 5.0f; //���������������� � ��������
    public float sensitivityVert = 5.0f; //���������������� � ��������
    public float minimumVert = -90.0f;
    public float maximumVert = 90.0f;
    private float _rotationX = 0;

    private int rotateCount = 0;
    //���������� 4 ��������� �������
    private Vector3[] startedCoords = { new Vector3(48.5f, 13.3f, 46f), new Vector3(41f, 13.3f, 53.5f), new Vector3(48.5f, 13.3f, 61f), new Vector3(56f, 13.3f, 53.5f) };

    private void Update()
    {
        //���������� ����� ��� ��������
        float horizont = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); 

        float rotate = 0f; //���������� � ����� ������� ������������ ������

        if (Input.GetKeyDown(KeyCode.F1))
        {
            Application.OpenURL("userguide\\camera_controller.htm");
        }

        if (Input.GetKeyDown(KeyCode.Q)) //���� ������ ������� Q, �� ������ ��������� �� ������� �������
        //rotate = -1f;
        {
            rotateCount++;
            if (rotateCount == 4) rotateCount = 0;
            transform.Rotate(new Vector3(0, 90, 0), Space.World);
            transform.position = startedCoords[rotateCount % 4];
        }
        else if (Input.GetKeyDown(KeyCode.E)) //���� ������ ������� Q, �� ������ ��������� ������ ������� �������
        {
            rotateCount--;
            if (rotateCount == -1) rotateCount = 3;
            transform.Rotate(new Vector3(0, -90, 0), Space.World);
            transform.position = startedCoords[rotateCount % 4];
        }    
        //��������� �������� ������ �� ���������� y
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate * mult, Space.World);

        //��������� ������ �� ������� Shift
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            mult = 3f;
        else mult = 1f;

        //�������� ������
        transform.Translate(new Vector3(horizont, vertical, vertical) * Time.deltaTime * mult * speed, Space.Self);

        //��� �� �������� ����
        //transform.position += transform.up * speed * Time.deltaTime * mult * Input.GetAxis("Mouse ScrollWheel");
        transform.Translate(new Vector3(0, 0, Input.GetAxis("Mouse ScrollWheel")) * Time.deltaTime * mult * zoomSpeed, Space.Self);

        //����������� �� ������� ������� �������� ��� ����������� ������ �� ���������� y
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, 35f, 60f),
            Mathf.Clamp(transform.position.y, 3f, 12f),
            Mathf.Clamp(transform.position.z, 42f, 65f)
            );

        //�������� ������ �� ������� ���
        if (Input.GetMouseButton(0)) //��� - 0, ��� - 1
        {
            if (axes == RotationAxes.MouseX)
            {
                transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityHor, 0);
            }
            else if (axes == RotationAxes.MouseY)
            {
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
                float rotationY = transform.localEulerAngles.y;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
            else
            {
                _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
                _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
                float delta = Input.GetAxis("Mouse X") * sensitivityHor;
                float rotationY = transform.localEulerAngles.y + delta;
                transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
            }
        }
    }

}
