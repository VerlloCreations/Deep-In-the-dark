using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager UI;

    public Text GemasTotales;

    public Text VidaMax;

    public Text vidaRes;

    public Text puntosAcu;

    public Text tiempo;

    public Text cerillosRes;

    public Text TextF;

    public Transform pantallaFinal;

    public Transform pantallaMuerte;

    public Transform gema1;

    public Transform gema2;

    public Transform gema3;

    public Transform llave;

    public Transform TeclaF;

    public Transform cerillos;

    public GameObject BurbujaTexto;

    void Awake()
    {
        UI = this;
        actualizarPuntos();
        ActualizarVidaMax();

        if(GemasTotales != null)
        {
            actualizarGemasTotales();
        }
    }

    public void actualizarGemasTotales()
    {
        GemasTotales.text = "" + GameManager.Jefe.GemasTotales;
    }

    public void actualizarVida()
    {
        vidaRes.text = "" + jugador.Obj.vidas;
    }

    public void actualizarPuntos()
    {
        puntosAcu.text = "" + GameManager.Jefe.puntos;
    }

    public void actualizarTiempo()
    {
        tiempo.text = "" + canastaDeBombas.compartir.EnfriamientoTer;
    }

    public void contarGema()
    {
        if(GameManager.Jefe.Gemas == 1)
        {
            gema1.gameObject.SetActive(true);
        }

        if(GameManager.Jefe.Gemas == 2)
        {
            gema2.gameObject.SetActive(true);
        }

        if(GameManager.Jefe.Gemas == 3)
        {
            gema3.gameObject.SetActive(true);
        }
    }

    public void AgregarCerillos()
    {
        cerillosRes.text = "" + GameManager.Jefe.Tcerillos;
    }

    public void llaveGuardada()
    {
        llave.gameObject.SetActive(true);
    }

    public void llaveUsada()
    {
        llave.gameObject.SetActive(false);
    }

    public void ActivarPantallafinal()
    {
        pantallaFinal.gameObject.SetActive(true);
    }

    public void ActivarPantallaMuerte()
    {
        pantallaMuerte.gameObject.SetActive(true);
        ManagerSonidos.sonidos.Igameover();
    }

    public void OnAvisoTecla()
    {
        TeclaF.gameObject.SetActive(true);
    }

    public void OffAvisoTecla()
    {
        TeclaF.gameObject.SetActive(false);
    }

    public void CambiarTextoFNPC()
    {
        TextF.text = "Hablar";
    }

    public void CambiarTextoFCasa()
    {
        TextF.text = "Entrar";
    }

    public void ActualizarVidaMax()
    {
        VidaMax.text = "" + GameManager.Jefe.MaxVidas;
    }

    public void ActBurbuja()
    {
        BurbujaTexto.gameObject.SetActive(true);
    }

    public void ApaBurbuja()
    {
        BurbujaTexto.gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        UI = null;
    }
}
