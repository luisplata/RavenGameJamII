using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPlayer : MonoBehaviour
{
    [SerializeField] InputManager inputManager;
    [SerializeField] MovimientoCorredor corredor;
    [SerializeField] float speed;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 vectorVelocidad = new Vector2();
        if (inputManager.SeMovioHorizontalmente() != 0)
        {
            if(inputManager.SeMovioHorizontalmente() > 0)
            {
            }
            else
            {   
            }
            vectorVelocidad.x = inputManager.SeMovioHorizontalmente();
        }
        if(inputManager.SeMovioVerticalmente() != 0)
        {
            if(inputManager.SeMovioVerticalmente() > 0)
            {   
            }
            else
            {
            }
            vectorVelocidad.y = inputManager.SeMovioVerticalmente();
        }
        rb.velocity = vectorVelocidad * (speed * Time.deltaTime);
    }
}
