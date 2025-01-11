using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPerson : MonoBehaviour
{
   
    [Header("Detectar el suelo")]
    [SerializeField] Transform Patas;
    [SerializeField] float radioDeteccion;
    [SerializeField] LayerMask queEsSuelo;

    [Header("Controladores,camara,animacion y movimiento")]
    [SerializeField] float escalaGravedad;
    [SerializeField] float velocidadMovimiento;
    [SerializeField] float alturaSalto;

    CharacterController Controller;
    float velocidadRotacion;
    Camera cam;
    Animator animPlayer;
    [SerializeField] int vidas;

    // para modificar la velocidad en caida libre y en los saltos
    private Vector3 MovimientoVertical;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Controller = GetComponent<CharacterController>();
        cam = Camera.main;
        animPlayer = GetComponent<Animator>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal"); //h=0, h=-1,h=1
        float v = Input.GetAxisRaw("Vertical");
        Vector2 input = new Vector2(h, v).normalized;

        transform.eulerAngles = new Vector3(0, cam.transform.eulerAngles.y, 0);

        if (input.sqrMagnitude > 0)
        {
            float anguloRotacion = Mathf.Atan2(input.x, input.y) * Mathf.Rad2Deg + cam.transform.eulerAngles.y;

            Vector3 movimiento = Quaternion.Euler(0, anguloRotacion, 0) * Vector3.forward;
            Controller.Move(movimiento * velocidadMovimiento * Time.deltaTime);
            animPlayer.SetBool("walking", true);
        }
        else
        {
            animPlayer.SetBool("walking", false);
        }

        AplicarGravedad();
        DeteccionSuelo();
    }
    void AplicarGravedad()
    {
        // mi movimiento vertical en la y aumenta a cierta escala por segundo
        MovimientoVertical.y += escalaGravedad * Time.deltaTime;
        Controller.Move(MovimientoVertical * Time.deltaTime);
    }
    void DeteccionSuelo()
    {

        Collider[] collsDetectados = Physics.OverlapSphere(Patas.position, radioDeteccion, queEsSuelo);
        // si existe un colider bajo mis pies
        if (collsDetectados.Length > 0)
        {
            MovimientoVertical.y = 0;
            Saltar();
        }

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("ParteEnemigo"))
        {
            Rigidbody rbEnemy = hit.gameObject.GetComponent<Rigidbody>();
            Vector3 direccionFuerza = hit.transform.position - transform.position;
            rbEnemy.AddForce(direccionFuerza.normalized * 50, ForceMode.Impulse);
        }
    }

    public void RecibirDanho(int danhoRecibido)
    {
        vidas -= danhoRecibido;
    }

    // sirve para dibujar figuras en la escena
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Patas.position, radioDeteccion);
    }

    private void Saltar()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            MovimientoVertical.y = Mathf.Sqrt(-2 * escalaGravedad * alturaSalto);
        }
    }
}
