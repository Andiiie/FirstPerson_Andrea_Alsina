using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bazooka : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] GameObject granade;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // creo una instancia de la misma orientacion del ca�on
            Instantiate(granade, spawnPoint.position, spawnPoint.rotation);
        } 
    }
}
