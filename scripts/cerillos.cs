using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cerillos : MonoBehaviour
{
      public int cerillosEntrega = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Jefe.AgregarCerillos(cerillosEntrega);

            ManagerSonidos.sonidos.Idañoenemigo();

            UIManager.UI.AgregarCerillos();

            ManagerEfectos.Efectos.mostrarpop(transform.position);
            gameObject.SetActive(false);
        }
    }
}
