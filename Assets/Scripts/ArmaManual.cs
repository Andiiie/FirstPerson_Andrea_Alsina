using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaManual : MonoBehaviour
{
    [SerializeField] ArmaSO misDatos;
    [SerializeField] ParticleSystem system;

    Camera cam;
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
                hitInfo.transform.GetComponent<ParteEnemigo>().RecibirDanho(misDatos.danhoAtaque);  
           }
        }
    }
}
