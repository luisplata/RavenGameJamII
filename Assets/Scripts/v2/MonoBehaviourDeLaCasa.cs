using UnityEngine;

public abstract class MonoBehaviourDeLaCasa : MonoBehaviour
{
    protected bool comenzarContarTiempoRespawn;
    protected float deltaTimeLocal;
    [SerializeField] protected int tiempoDeRespawn;

    protected void FixedUpdate()
    {
        float anguloLocal = Vector2.SignedAngle(Vector2.up, Vector2.right);
        Vector3 rotacion = transform.rotation.eulerAngles;
        rotacion.z = anguloLocal + 90;
        transform.eulerAngles = rotacion;
        CuentaRegresiva();
    }

    protected void CuentaRegresiva()
    {
        if (comenzarContarTiempoRespawn)
        {
            deltaTimeLocal += Time.deltaTime;
            if (deltaTimeLocal >= tiempoDeRespawn)
            {
                deltaTimeLocal = 0;
                comenzarContarTiempoRespawn = false;
                AccionDeLaCuentaRegresiva();
            }
        }
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            AccionDeColisionConPlayer();
        }
    }

    protected abstract void AccionDeColisionConPlayer();

    protected abstract void AccionDeLaCuentaRegresiva();
}
