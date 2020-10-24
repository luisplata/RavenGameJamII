using System;
using UnityEngine;

public class MovimientoDeMapa : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject quienRota;
    [SerializeField] private GameObject player;
    public GameObject corredorDelMapa;
    private bool debeGirar;
    private float deltaTimeLocal;
    private float gradosParaRotar;
    private bool rotarIzquierda;
    [SerializeField] private int gradosRotacion;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vectorVelocidad = Vector2.down;
        if (debeGirar)
        {
            if (rotarIzquierda)
            {
                Rotar(gradosRotacion*-1);
            }
            else
            {
                Rotar(gradosRotacion);
            }

            deltaTimeLocal += gradosRotacion;
            if (Mathf.Abs(deltaTimeLocal) >= Mathf.Abs(gradosParaRotar))
            {
                debeGirar = false;
                deltaTimeLocal = 0;
                return;
            }
        }
        //debe el mapa estar alineado con el player
        float direccionDeLado = (player.transform.position.x - corredorDelMapa.transform.position.x);
        if (Mathf.Abs(direccionDeLado) > 0.01f)
        {
            if (direccionDeLado > 0)
            {
                vectorVelocidad.x = Vector2.right.x;
            }
            if (direccionDeLado < 0)
            {
                vectorVelocidad.x = Vector2.left.x;
            }
        }
        else
        {
            vectorVelocidad.x = Vector2.zero.x;
        }

        rb.velocity = vectorVelocidad * (speed * Time.deltaTime);
    }

    internal void GirarHaciaDerecha()
    {
        debeGirar = true;
        rotarIzquierda = false;
        gradosParaRotar = 90;
    }


    private void Rotar(float grados)
    {
        Vector3 rotacion = quienRota.transform.rotation.eulerAngles;
        rotacion.z += grados;
        quienRota.transform.eulerAngles = rotacion;
    }

    internal void GirarHaciaIzquierda()
    {
        debeGirar = true;
        rotarIzquierda = true;
        gradosParaRotar = -90;
    }

}
