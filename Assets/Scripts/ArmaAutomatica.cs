using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaAutomatica : MonoBehaviour
{
    [SerializeField] ParticleSystem system;
    [SerializeField] ArmaSO misDatos; 
   
    Camera cam;

    [SerializeField] float timer = 0;
    void Start()
    {
        cam = Camera .main;
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetMouseButton(0) &&timer>misDatos.cadenciaAtaque)
        {
            system.Play();
            Debug.Log("piu!piu!");
            timer = 0f;

            if(Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hitInfo, misDatos.distanciaAtaque))
            {
                if (hitInfo.transform.CompareTag("ParteEnemigo"))
                {
                    Debug.Log(hitInfo.transform.name);
                    hitInfo.transform.GetComponent<ParteEnemigo>().RecibirDanho(misDatos.danhoAtaque);
                }
            }
        }
    }
}
