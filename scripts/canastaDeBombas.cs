using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class canastaDeBombas : MonoBehaviour
{
    public static canastaDeBombas compartir;

    public bool EstaEnZona;
    public bool EnfriamientoOff = true;
    public float Enfriamiento = 10f;
    public float EnfriamientoTer = 0;

    public Transform zonaGenerar;

    public GameObject Bomba;

    private void Awake()
    {
        compartir = this;
    }
    void Update()
    {
        if(EstaEnZona == true) 
        { 
            if (EnfriamientoTer <= 0) 
            {

               if(Input.GetKeyDown(KeyCode.F)) 
               {
                    EnfriamientoOff = false;
                    EnfriamientoTer = Enfriamiento;

                    Instantiate(Bomba,zonaGenerar.transform.position,Quaternion.identity);
               }

            }

            UIManager.UI.actualizarTiempo();

        }
        
        if(!EnfriamientoOff)
        {
             EnfriamientoTer -= Time.deltaTime;

             if (EnfriamientoTer <= 0)
             {
                  EnfriamientoOff = true;
             }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            EstaEnZona = true;
            UIManager.UI.OnAvisoTecla();
        }
        else
        {
            EstaEnZona = false;
            UIManager.UI.OffAvisoTecla();
        }
    }
}
