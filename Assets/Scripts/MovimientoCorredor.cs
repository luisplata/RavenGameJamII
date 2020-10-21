using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoCorredor : MonoBehaviour
{
    [SerializeField] private GameObject puntoDondeDebeEstar;
    public GameObject corredor;
    private bool isLLego = true;
    private Rigidbody2D rb;
    [SerializeField] private int escalar;
    public bool puedeVoltear;

    private void Start()
    {
        CambiarDePunto(puntoDondeDebeEstar);
        rb = GetComponent<Rigidbody2D>();
    }

    public void CambiarDePunto(GameObject posicion)
    {
        isLLego = false;
        puntoDondeDebeEstar = posicion;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 diff = puntoDondeDebeEstar.transform.position - transform.position;
        Vector2 llegando = puntoDondeDebeEstar.transform.position - transform.position;
        if(llegando.sqrMagnitude <= 0.1 && !isLLego)
        {
            isLLego = true;
        }
        else
        {
            rb.velocity = diff * escalar;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("corredor"))
        {
            puedeVoltear = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("corredor"))
        {
            puedeVoltear = false;
        }
    }
}
