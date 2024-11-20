using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmaAutomatica : MonoBehaviour
{
    [SerializeField] private ParticleSystem system;
    //[SerializeField] private GameObject target;
    Camera cam;
    void Start()
    {
        cam = Camera .main;
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            system.Play(); 
            //if (Physics.Raycast(Camera.transform.position)
        }
    }
}
