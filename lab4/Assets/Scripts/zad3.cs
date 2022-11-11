using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad3 : MonoBehaviour
{
    // ruch wokó³ osi Y bêdzie wykonywany na obiekcie gracza, wiêc
    // potrzebna nam referencja do niego (konkretnie jego komponentu Transform)
    public Transform player;

    public float sensitivity = 200f;

    public float xMaxLimit = 90.0f;
    public float xMinLimit = -90.0f;
    float rotX = 0.0f;
    float rotY = 0.0f;
    void Start()
    {
        // zablokowanie kursora na œrodku ekranu, oraz ukrycie kursora
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseXMove = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseYMove = -Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        rotX += mouseXMove;
        rotY -= mouseYMove;
        rotY = Mathf.Clamp(rotY, xMinLimit, xMaxLimit);

        player.Rotate(Vector3.up * mouseXMove);

     
        //transform.Rotate(new Vector3(mouseYMove, 0f, 0f), Space.Self);
        transform.eulerAngles = new Vector3(rotY, rotX, 0);
    }
}