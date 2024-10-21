using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class ThirdPerson : MonoBehaviour
{
    [SerializeField] private float velocidadMovimiento;

    CharacterController controller;
    private Camera cam;
    [SerializeField] private float smoothing;

    private float velocidadRotacion;
    private Animator anim;
    void Start()
    {
        //Bloquear y ocultar el cursor
        Cursor.lockState = CursorLockMode.Locked;

        GetComponent<CharacterController>();

        anim = GetComponent<Animator>();
        cam = Camera.main;

    }


    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); // h = 0 , h = -1, h = 1
        float v = Input.GetAxisRaw("Vertical");

        // Vector3 movimiento = new Vector3(h, 0, v).normalized;

        Vector2 input = new Vector2(h, v).normalized;

        //Si existe input...
        if (input.magnitude > 0)
        {
            //Se calcula el angulo al que tengo que rotarme en funcion de los imputs y orientacion de la camara
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y;
            Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloRotacion, ref velocidadRotacion, smoothing);

            float anguloSuave = Mathf.SmoothDampAngle(transform.eulerAngles.y, anguloRotacion, ref velocidadRotacion, smoothing);

            transform.eulerAngles = new Vector3(0, anguloRotacion, 0);

            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;

            //Cursor.visible = false;
        }

        // controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
    }
}
