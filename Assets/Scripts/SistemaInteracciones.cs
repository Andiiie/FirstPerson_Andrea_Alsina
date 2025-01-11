using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.PackageManager;
using UnityEngine;

public class SistemaInteracciones : MonoBehaviour
{
    Camera cam;
    [SerializeField] float DistacioaInteraccion;
    Transform InteractuableActual;

    void Start()
    {
        cam = Camera.main;

    }

    void Update()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out RaycastHit ObjectHitInfo, DistacioaInteraccion))
        {
            if (ObjectHitInfo.transform.TryGetComponent(out CajaMunicion scripCaja))
            {
                Debug.Log("La caja La caja");

                InteractuableActual = ObjectHitInfo.transform;
                InteractuableActual.GetComponent<Outline>().enabled = true;

                if (Input.GetKeyDown(KeyCode.E))
                {
                    scripCaja.Abrir();
                }
            }
            else if (InteractuableActual)
            {
                InteractuableActual.GetComponent<Outline>().enabled = false;
                InteractuableActual = null;
            }
        }
    }
}
