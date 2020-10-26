using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiapradorDePerros : MonoBehaviourDeLaCasa
{
    [SerializeField] private GameObject perro;
    protected override void AccionDeColisionConPlayer()
    {
        comenzarContarTiempoRespawn = true;
    }

    protected override void AccionDeLaCuentaRegresiva()
    {
        Debug.Log("Instanciamos al Perro");
        Instantiate(perro, transform.parent.transform);
    }
}
