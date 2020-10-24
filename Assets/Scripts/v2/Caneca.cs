using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caneca : MonoBehaviourDeLaCasa
{
    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }


    
    protected override void AccionDeLaCuentaRegresiva()
    {
        ani.SetTrigger("respawn");
    }

    protected override void AccionDeColisionConPlayer()
    {
        ani.SetTrigger("cayo");
        comenzarContarTiempoRespawn = true;
    }
}