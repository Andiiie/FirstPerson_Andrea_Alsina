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


                hitInfo.transform.GetComponent<Enemy>().RecibirDanho(misDatos.danhoAtaque);
           }
        }
    }
}
