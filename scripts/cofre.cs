using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cofre : MonoBehaviour
{
    public Transform LugarEntrega;

    public GameObject objetoEntrega;

    Animator anima;

    bool abierto = false;
    bool abriendo = false;
    public int monedasEnCofre;

    private void Awake()
    {
        anima = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
              if(GameManager.Jefe.llave == true)
              {
                  cambiarAnimacion(); 
                  GameManager.Jefe.AgregarPuntos(monedasEnCofre);
                   UIManager.UI.actualizarPuntos();
                    UIManager.UI.llaveUsada();
                     GameManager.Jefe.llave = false;
                Instantiate(objetoEntrega,LugarEntrega.transform.position, Quaternion.identity);

              }
              else
              {
                if (abierto == false) 
                {
                   avisoCofre.aviso.NoTieneLlave();
                }
              }
        }
    }


    void cambiarAnimacion()
    {
        abierto = true;
        abriendo = true;
        anima.SetBool("abriendo", abriendo);
    }
}
