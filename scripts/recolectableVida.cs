using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recolectableVida : MonoBehaviour
{

    public int vidaRecarga = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            jugador.Obj.agregarVida();

            UIManager.UI.actualizarVida();

            gameObject.SetActive(false);

            ManagerEfectos.Efectos.mostrarpop(transform.position);

            ManagerSonidos.sonidos.Igui();

            
        }
    }
}
