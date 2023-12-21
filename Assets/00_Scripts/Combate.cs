using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combate : MonoBehaviour
{
    public float danioPorGolpe = 1f;
    public float vidaJugador = 5f;

    private void Update()
    {
        if (vidaJugador <= 0)
        {

            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Espada"))
        {

            TomarDanio();
        }
    }

    private void TomarDanio()
    {
 
        vidaJugador -= danioPorGolpe;

        
    }
}
