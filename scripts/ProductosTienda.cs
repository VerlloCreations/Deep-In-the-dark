using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProductosTienda : MonoBehaviour
{
    public static ProductosTienda Instance;

    public Text PrecioVidaAu;
    public Text PrecioDup;
    public Text PrecioVel;
    public Text CantidadMonedas;
    public Text CantidadGemas;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void AumentarVida()
    {
        if(GameManager.Jefe.GemasTotales >= 3 && GameManager.Jefe.MaxVidas < 10)
        {
            GameManager.Jefe.GemasTotales -= GameManager.Jefe.PrecioVida;
            GameManager.Jefe.MaxVidas += 1;
            GameManager.Jefe.PrecioVida += 1;
            UIManager.UI.ActualizarVidaMax();
            ActualizarDatosMonYGem();
            PrecioVidaAu.text = "" + GameManager.Jefe.PrecioVida;
        }

        if(GameManager.Jefe.MaxVidas >= 10)
        {
            PrecioVidaAu.text = "Max";
        }
    }

    public void AplicarMultiplicador()
    {
        if(GameManager.Jefe.GemasTotales >= GameManager.Jefe.PrecioDuplicadorMonedas && !GameManager.Jefe.AplicoMul)
        {
            GameManager.Jefe.GemasTotales -= GameManager.Jefe.PrecioDuplicadorMonedas;
            GameManager.Jefe.AplicoMul = true;
            ActualizarDatosMonYGem();
        }

        if (GameManager.Jefe.AplicoMul)
        {
            PrecioDup.text = "Max";
        }
    }

    public void aumentarVelocidad()
    {
        if (GameManager.Jefe.GemasTotales >= GameManager.Jefe.PrecioAumentoDeVelocidad && jugador.Obj.velocidad <= 7)
        {
            GameManager.Jefe.GemasTotales -= GameManager.Jefe.PrecioAumentoDeVelocidad;
            GameManager.Jefe.VelocidadGlobal += 0.5f;
            jugador.Obj.velocidad = GameManager.Jefe.VelocidadGlobal;
            GameManager.Jefe.PrecioAumentoDeVelocidad += 2;
            PrecioVel.text = "" + GameManager.Jefe.PrecioAumentoDeVelocidad;
            ActualizarDatosMonYGem();
        }

        if(jugador.Obj.velocidad >= 7)
        {
            PrecioVel.text = "Max";
        }
    }

    public void ActualizarDatosMonYGem()
    {
        CantidadGemas.text = "" + GameManager.Jefe.GemasTotales;
        CantidadMonedas.text = "" + GameManager.Jefe.puntos;
    }


    public void MasMonedas()
    {
        GameManager.Jefe.puntos += 100;
        ActualizarDatosMonYGem();
    }

    public void MasGemas()
    {
        GameManager.Jefe.GemasTotales += 30;
        ActualizarDatosMonYGem();
    }
}
