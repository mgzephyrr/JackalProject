using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControled : MonoBehaviour
{
    public float rotateSpeed = 10.0f; //скорость, с которой вращается камера
    public float speed = 10.0f; //скорость движения камеры
    private float zoomSpeed = 1000.0f; //скорость приблежения и отдаления камеры

    private float mult = 1f; //ускорение

    private void Update()
    {
        //переменные нужны для движения
        float horizont = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float rotate = 0f; //показывает в какую сторону поворачивает камера
        if (Input.GetKey(KeyCode.Q)) //если нажата клавиша Q, то камера вращается по часовой стрелке
            rotate = -1f;
        else if (Input.GetKey(KeyCode.E)) //если нажата клавиша Q, то камера вращается против часовой стрелки
            rotate = 1f;
        //изменение поворота камеры по координате y
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime * rotate * mult, Space.World);

        //ускорение камеры по нажатым Shift
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            mult = 3f;
        else mult = 1f;

        //движение камеры
        transform.Translate(new Vector3(horizont, 0, vertical) * Time.deltaTime * mult * speed, Space.Self);

        //приближение и отдалении камеры при кручении колесика мыши
        transform.position += transform.up * zoomSpeed * Time.deltaTime * mult * Input.GetAxis("Mouse ScrollWheel");

        //ограничение на слишком сильное удаление или приближение камеры по координате y
        transform.position = new Vector3(
            transform.position.x,
            Mathf.Clamp(transform.position.y, 5f, 20f),
            transform.position.z);
    }

}
