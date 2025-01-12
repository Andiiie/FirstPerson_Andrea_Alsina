using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] GameObject[] armas;
    private int indiceArmaActual = 1;
   
    void Update()
    {
        CambiarArmaConTeclado();
        CambiarArmaConRaton();
    }

     void CambiarArmaConTeclado()
     {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            CambioArma(0);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            CambioArma(1);

        }
        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            CambioArma(2);
        }
     }
    void CambiarArmaConRaton()
    {
        float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
        Debug.Log(scrollWheel);
        if (scrollWheel > 0) // anterior
        {
            CambioArma(indiceArmaActual - 1);
        }
        else if (scrollWheel < 0) // siguiente  
        {
            CambioArma(indiceArmaActual + 1);
        }
    }

    void CambioArma(int nuevoArma)
    {
        // aqui desactivo el amra que actualmente llevo equipada

        if (nuevoArma < armas.Length && nuevoArma >= 0)
        {
            armas[indiceArmaActual].SetActive(false);

            indiceArmaActual = nuevoArma;

            armas[indiceArmaActual].SetActive(true);
        }

        // despues cambio el indice
    }
}
