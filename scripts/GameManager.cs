using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Jefe;

    public bool PrimeraVezTienda = true, resolucionAlta;
    public bool llave;

    public int MaxVidas = 3;
    public int puntos = 0;
    public int MaxGemas = 3;
    public int Gemas;
    public int GemasTotales;
    public int Tcerillos;
    public int Maxcerillos = 10;
    public int MonedasRecolectadas;
    public float VelocidadGlobal = 3f;

    //=============Precios Tienda=================

    public int PrecioVida = 3;
    public int PrecioDuplicadorMonedas = 6;
    public int PrecioAumentoDeVelocidad = 4;
    public bool AplicoMul = false;


    private void Awake()
    {
        if (Jefe == null)
        {
            Jefe = this;
            DontDestroyOnLoad(gameObject); // no se destruye al cambiar de escena
        }
        else
        {
            Destroy(gameObject); // evita duplicados
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F11))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }

        if (Input.GetKeyDown(KeyCode.V) && resolucionAlta)
        {
            Screen.SetResolution(1280, 720, false); // false = ventana
        }

        if (Input.GetKeyDown(KeyCode.V) && !resolucionAlta)
        {
            Screen.SetResolution(1920, 1080, false); // false = ventana
        }
    }

    public void AgregarPuntos(int PuntosObt)
    {
        if (!AplicoMul)
        {
            puntos += PuntosObt;
        }
        else
        {
            puntos += PuntosObt * 2;
        }

    }

    public void AgregarGemas(int GemaObtenida)
    {
        Gemas += GemaObtenida;
        GemasTotales += GemaObtenida;

        if(Gemas > MaxGemas)
        {
            Gemas = MaxGemas;
        }
    }

    public void AgregarCerillos(int CerilloObtenido)
    {
        Tcerillos += CerilloObtenido;

        if(Tcerillos > Maxcerillos)
        {
            Tcerillos = Maxcerillos;
        }
    }

    public void quitarCerillos(int cerilloEliminado)
    {
        Tcerillos -= cerilloEliminado;

        if (Tcerillos < 0)
        {
            Tcerillos = 0;
        }
    }

    public void AgregarLlave()
    {
        llave = true;
    }

    public void PagarTiradaSin()
    {
        puntos -= 50;

        if (puntos < 0)
        {
            puntos = 0;
        }
    }

    public void PagarTiradaCon()
    {
        puntos -= 10;
        if (puntos < 0)
        {
            puntos = 0;
        }
    }

    public void GameOver()
    {
        //obtiene la escena actual
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ActivarPantallaMuerte()
    {
        UIManager.UI.ActivarPantallaMuerte();
    }
}
