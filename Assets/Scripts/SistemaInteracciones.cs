using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    Camera cam;
    [SerializeField] private float distanciaInteraccion;
    Transform interactuableActual;
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit hit, distanciaInteraccion))
        {
            if (hit.transform.CompareTag("CajaMunicion"))
            {
                Debug.Log("La caja, la caja!");

                hit.transform.GetComponent<Outline>().enabled = true;
                interactuableActual = hit.transform;
                interactuableActual.GetComponent<Outline>().enabled = false;
            }         
        }
        else if (interactuableActual)
        {
            interactuableActual.GetComponent<Outline>().enabled = false;
            interactuableActual = null;
        }

    }
}
