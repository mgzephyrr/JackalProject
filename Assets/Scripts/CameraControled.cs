using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControled : MonoBehaviour
{
    public float rotateSpeed = 10.0f; //скорость, с которой вращается камера
    public float speed = 10.0f; //скоростб движения камеры

    private float mult = 1f; //ускорение

    private void Update()
    {
        float horizont = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float rotate = 0f;
        if (Input.GetKey(KeyCode.Q)) //если нажата клавиша Q, то камера вращается по часовой стрелке
            rotate = -1f;
        else if (Input.GetKey(KeyCode.E)) //если нажата клавиша Q, то камера вращается против часовой стрелки
            rotate = 1f;
        //изменение поворота камеры по координате y
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate * mult, Space.World);


        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            mult = 3f;
        else mult = 1f;

        transform.Translate(new Vector3(horizont, 0, vertical) * Time.deltaTime * mult * speed, Space.World);
    }

}
