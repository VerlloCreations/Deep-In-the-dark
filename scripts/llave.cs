using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class llave : MonoBehaviour
{
   
    public bool recogioLlave = false;

    private void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIManager.UI.llaveGuardada();
            GameManager.Jefe.AgregarLlave();

            ManagerEfectos.Efectos.mostrarpop(transform.position);

            ManagerSonidos.sonidos.Imoneda(); 
            
            recogioLlave = true;

            if(recogioLlave == true) 
            { 
               gameObject.SetActive(false);
            }

        }
    }








}
