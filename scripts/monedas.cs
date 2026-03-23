using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monedas : MonoBehaviour
{

    public int puntosEntrega = 5;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Jefe.AgregarPuntos(puntosEntrega);

            ManagerSonidos.sonidos.Imoneda();

            UIManager.UI.actualizarPuntos();

            ManagerEfectos.Efectos.mostrarpop(transform.position);
            gameObject.SetActive(false);
        }
    }
}
