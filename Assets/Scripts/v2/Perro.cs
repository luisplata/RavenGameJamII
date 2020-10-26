using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perro : MonoBehaviourDeLaCasa
{
    [SerializeField] private GameObject target;
    [SerializeField] private float speed;
    Rigidbody2D rb;
    [SerializeField] private bool comezarPerseguir;
    [SerializeField] private float aumentoParametro;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (comezarPerseguir)
        {
            Vector2 diff = (target.transform.position - transform.position).normalized;
            rb.velocity = diff * (speed * Time.deltaTime);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, (target.transform.localPosition - transform.position).normalized);
    }

    public void AumentarDificultad()
    {
        speed *= aumentoParametro;
    }

    protected override void AccionDeColisionConPlayer()
    {
        
    }

    protected override void AccionDeLaCuentaRegresiva()
    {
        
    }
}
