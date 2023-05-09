using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControled : MonoBehaviour
{
    public float rotateSpeed = 10.0f; //скорость, с которой вращается камера

    private float mult = 1f;

    private void Update()
    {
        float rotate = 0f;
        if (Input.GetKey(KeyCode.Q)) //если нажата клавиша Q, то камера вращается по часовой стрелке
            rotate = -1f;
        else if (Input.GetKey(KeyCode.E)) //если нажата клавиша Q, то камера вращается против часовой стрелки
            rotate = 1f;
        //изменение поворота камеры по координате y
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate, Space.World);

    }

}
