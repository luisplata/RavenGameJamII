using System;
using UnityEngine;

public class MovimientoDeMapa : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject quienRota;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vectorVelocidad = Vector2.down;
        rb.velocity = vectorVelocidad * (speed * Time.deltaTime);
    }

    internal void GirarHaciaDerecha()
    {
        Rotar(90);
    }


    private void Rotar(float grados)
    {
        Vector3 rotacion = quienRota.transform.rotation.eulerAngles;
        rotacion.z = grados;
        quienRota.transform.eulerAngles = rotacion;
    }

    internal void GirarHaciaIzquierda()
    {
        Rotar(-90);
    }
}
