using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovimientoPlayer : MonoBehaviour
{
    [SerializeField] InputManager inputManager;
    [SerializeField] MovimientoCorredor corredor;
    [SerializeField] private Button botonPanelDerecho, botonPanelIzquierdo;
    [SerializeField] private List<GameObject> carriles;
    [SerializeField] private int carrilSeleccionado;
    [SerializeField] public GameObject corredorPista;
    [SerializeField] private MovimientoDeMapa movimientoMapa;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        botonPanelDerecho.onClick.AddListener(delegate { CambiarDeCarrilHaciaLaDerecha(); });
        botonPanelIzquierdo.onClick.AddListener(delegate { CambiarDeCarrilHaciaLaIzquierda(); });
        corredor.CambiarDePunto(carriles[carrilSeleccionado]);
        
    }

    private void CambiarDeCarrilHaciaLaDerecha()
    {
        carrilSeleccionado++;
        if(carrilSeleccionado > carriles.Count -1)
        {
            carrilSeleccionado = carriles.Count - 1;
        }
        corredor.CambiarDePunto(carriles[carrilSeleccionado]);
        if (corredor.puedeVoltear)
        {
            if(corredor.ElNuevoCorredor != null)
            {
                corredorPista = corredor.ElNuevoCorredor;
                corredor.corredorActual = corredorPista;
                movimientoMapa.GirarHaciaDerecha();
                movimientoMapa.corredorDelMapa = corredorPista;
                corredor.puedeVoltear = false;
            }
        }
    }

    private void CambiarDeCarrilHaciaLaIzquierda()
    {
        carrilSeleccionado--;
        if (carrilSeleccionado < 0)
        {
            carrilSeleccionado = 0;
            
        }
        corredor.CambiarDePunto(carriles[carrilSeleccionado]);
        if (corredor.puedeVoltear)
        {
            if (corredor.ElNuevoCorredor != null)
            {
                corredorPista = corredor.ElNuevoCorredor;
                corredor.corredorActual = corredorPista;
                movimientoMapa.GirarHaciaIzquierda();
                movimientoMapa.corredorDelMapa = corredorPista;
                corredor.puedeVoltear = false;
            }
        }
    }
}
