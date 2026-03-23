using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomba : MonoBehaviour
{
    public static bomba bomb;

    int quitarCerillo = 1;
    bool activa = false;


    CapsuleCollider2D RangoExplocion;
    Animator anima;
    
    private void Awake()
    {
        bomb = this;

        RangoExplocion= GetComponent<CapsuleCollider2D>();
        anima = GetComponent<Animator>();
    }
    void Start()
    {
        RangoExplocion.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(GameManager.Jefe.Tcerillos > 0 && activa == false)
            {
                activa= true;
                GameManager.Jefe.quitarCerillos(quitarCerillo);
                UIManager.UI.AgregarCerillos();
                encenderBomba();
                Invoke("OnHitBoxExplocion", 2f);
                Invoke("DestruirBomba",2.9f);
            }
            
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("MuroRompible"))
        {
            muroRompible.rompible.DestruirBloque();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            ManagerSonidos.sonidos.Ihit();
            jugador.Obj.vidas = 1;
            jugador.Obj.RecibirDaño();
            jugador.Obj.apagarJugador();
            GameManager.Jefe.ActivarPantallaMuerte();
        }
    }


    void DestruirBomba()
    {
        gameObject.SetActive(false);
    }

    void OnHitBoxExplocion()
    {
        RangoExplocion.enabled = true;
    }

    void encenderBomba()
    {
       anima.SetBool("Encendida",true);
    }
}
