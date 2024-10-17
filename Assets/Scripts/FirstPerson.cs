using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;

    CharacterController controller;
    void Start()
    {
       //Bloquear y ocultar el cursor
       Cursor.lockState = CursorLockMode.Locked;
        
        GetComponent<CharacterController>();
    }

   
    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); // h = 0 , h = -1, h = 1
        float v = Input.GetAxisRaw("Vertical"); 

        // Vector3 movimiento = new Vector3(h, 0, v).normalized;

        Vector2 input = new Vector2(h, v).normalized;

        //Si existe input...
        if(input.magnitude > 0)
        {
            //Se calcula el angulo al que tengo que rotarme en funcion de los imputs y orientacion de la camara
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;

            //Cursor.visible = false;
        }

        // controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
    }
}
