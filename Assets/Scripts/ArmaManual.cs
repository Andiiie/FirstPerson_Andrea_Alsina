using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaManual : MonoBehaviour
{
    [SerializeField] private ArmaSO misDatos;
    [SerializeField] private ParticleSystem system;

    private Camera cam;
    void Start()
    {
        //cam es la main camera principal de la escena "Mi camara"
        cam = Camera.main;
    }


    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            system.Play();
           if (Physics.Raycast (cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
           {
                Debug.Log(hitInfo.transform.name);
                // 1.  Crear un método recibir daño en script "enemigo" con un parametro de entrada tipo float
                // 2.  Desde este script, ejecuta el método "RecibirDanho" de enemigo
                // 3.  Para ello, necesitamos un daño, obtenla desde el Scriptable Object
                // 4.  Si el enemigo se queda sin vida, destrúyelo

                hitInfo.transform.GetComponent<Enemy>().RecibirDanho(misDatos.danhoAtaque);
           }
        }
    }
}
