using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granade : MonoBehaviour
{
    [SerializeField] float fuerzaDisparo;
    [SerializeField] float tiempoReloj;
    [SerializeField] float radioExplosion;
    [SerializeField] LayerMask queSeExplota;
    [SerializeField] GameObject explosion; 

    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward.normalized * fuerzaDisparo, ForceMode.Impulse);
        Destroy(gameObject, tiempoReloj);
    }

    private void OnDestroy()
    {
        // se instancia una copia del prefab de explosion
        Instantiate(explosion,transform.position, Quaternion.identity);

        Collider[] collsDetectados = Physics.OverlapSphere(transform.position, radioExplosion, queSeExplota);
        if(collsDetectados.Length > 0)
        {
            foreach(Collider coll in collsDetectados)
            {
                coll.GetComponent<ParteEnemigo>().Explotar(); // deshabilito el movimiento del enemigo impactado
                coll.GetComponent<Rigidbody>().isKinematic = false; // se dejan los huesos en dinamico
                coll.GetComponent <Rigidbody>().AddExplosionForce(80,transform.position,radioExplosion,15f,ForceMode.Impulse); // se aplica la explosion
            }
        }
    }
}
