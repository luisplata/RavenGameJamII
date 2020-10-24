using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallaConstruccion : MonoBehaviourDeLaCasa
{
    protected override void AccionDeColisionConPlayer()
    {
        StartCoroutine(FadeOff());
    }

    protected override void AccionDeLaCuentaRegresiva()
    {
        Color colorDeCoso = GetComponent<SpriteRenderer>().color;
        colorDeCoso.a = 1;
        GetComponent<SpriteRenderer>().color = colorDeCoso;
    }

    IEnumerator FadeOff()
    {
        Color colorDeCoso = GetComponent<SpriteRenderer>().color;
        for (int i = 0; i < 10; i++)
        {
            colorDeCoso.a = 1;
            GetComponent<SpriteRenderer>().color = colorDeCoso;
            Debug.Log("Alfa " + colorDeCoso.a);
            yield return new WaitForSeconds(.1f);
            colorDeCoso.a = 0;
            GetComponent<SpriteRenderer>().color = colorDeCoso;
            Debug.Log("Alfa " + colorDeCoso.a);
            yield return new WaitForSeconds(.1f);
        }
        comenzarContarTiempoRespawn = true;
    }
}