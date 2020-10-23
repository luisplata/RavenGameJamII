using System;
using UnityEngine;

public class MovimientoDelMapa : MonoBehaviour
{
    private bool debeVoltear;
    [SerializeField] private float deltaTimeLocal, speed;
    private bool izq;
    private float gradosGirar;

    public void GirarHaciaDerecha()
    {
        debeVoltear = true;
        izq = false;
        gradosGirar = 90;
    }

    public void GirarHaciaIzquierda()
    {
        izq = true;
        debeVoltear = true;
        gradosGirar = -90;
    }

    private void Rotar(float grados)
    {
        Vector3 rotacion = transform.rotation.eulerAngles;
        rotacion.z = grados * (izq ? -1 : 1);
        transform.eulerAngles = rotacion;
    }

    private void Update()
    {
        if (debeVoltear)
        {
            deltaTimeLocal += Time.deltaTime;
            if(deltaTimeLocal >= gradosGirar)
            {
                deltaTimeLocal *= speed;
                Rotar(deltaTimeLocal);
            }
            else
            {
                deltaTimeLocal = 0;
                gradosGirar = 0;
                debeVoltear = false;
            }
        }
    }
}