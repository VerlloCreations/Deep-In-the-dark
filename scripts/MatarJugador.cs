using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatarJugador : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ManagerSonidos.sonidos.Ihit();
            jugador.Obj.vidas = 0;
            jugador.Obj.RecibirDaño();
        }
    }
}
