using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Transform[] puntosSpawn;
    [SerializeField] private Enemy enemigoPrefab;
    // Start is called before the first frame update
    void Start()
    {
        //saca una copia de un enemigo en el punto 0 con rotacion0,0,0.
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            Instantiate(enemigoPrefab, puntosSpawn[Random.Range(0, puntosSpawn.Length)].position, Quaternion.identity);
            yield return new WaitForSeconds(2);

        }


    }
}
