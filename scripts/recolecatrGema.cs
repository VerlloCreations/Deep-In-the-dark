using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class recolecatrGema : MonoBehaviour
{
    public bool recolectada = false;

    public int gemasRecogidas = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Jefe.AgregarGemas(gemasRecogidas);
            UIManager.UI.contarGema();

            ManagerSonidos.sonidos.Igui();

            ManagerEfectos.Efectos.mostrarpop(transform.position);

            recolectada = true;

            if(recolectada == true)
            {
                gameObject.SetActive(false);
            }
            
            
        }
    }
}
