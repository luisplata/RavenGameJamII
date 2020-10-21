using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoPlayer : MonoBehaviour
{
    [SerializeField] InputManager inputManager;
    [SerializeField] MovimientoCorredor corredor;
    [SerializeField] float speed;
    [SerializeField] private Button botonPanelDerecho, botonPanelIzquierdo;
    [SerializeField] private List<GameObject> carriles;
    [SerializeField] private int carrilSeleccionado;
    [SerializeField] private GameObject corredorPista;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        botonPanelDerecho.onClick.AddListener(delegate { CambiarDeCarrilHaciaLaDerecha(); });
        botonPanelIzquierdo.onClick.AddListener(delegate { CambiarDeCarrilHaciaLaIzquierda(); });
        corredor.CambiarDePunto(carriles[carrilSeleccionado]);
        //transform.parent = corredorPista.transform;
    }

    private void CambiarDeCarrilHaciaLaDerecha()
    {
        carrilSeleccionado++;
        if(carrilSeleccionado > carriles.Count -1)
        {
            carrilSeleccionado = carriles.Count - 1;
            Debug.Log("Aqui es donde puede ir a otro direccion de la calle");
        }
        corredor.CambiarDePunto(carriles[carrilSeleccionado]);
    }

    private void CambiarDeCarrilHaciaLaIzquierda()
    {
        carrilSeleccionado--;
        if (carrilSeleccionado < 0)
        {
            carrilSeleccionado = 0;
            Debug.Log("Aqui es donde puede ir a otro direccion de la calle");
        }
        corredor.CambiarDePunto(carriles[carrilSeleccionado]);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vectorVelocidad = Vector2.up;
        rb.velocity = vectorVelocidad * (speed * Time.deltaTime);

    }
}
