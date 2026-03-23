using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntradaTienda : MonoBehaviour
{
    public static EntradaTienda Instance;

    [SerializeField]bool FrentePuerta = false;
    [SerializeField] GameObject CamaraPrincipal;
    [SerializeField] GameObject CamaraTienda;
    [SerializeField] GameObject UIPrincipal;
    [SerializeField] GameObject MenuCartas;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        CamaraPrincipal.SetActive(true);
        CamaraTienda.SetActive(false);
        UIPrincipal.SetActive(false);
        MenuCartas.SetActive(false);
    }

    void Update()
    {
        if(FrentePuerta)
        {
            if (Input.GetKeyUp(KeyCode.F))
            {
                CamaraPrincipal.SetActive(false);
                CamaraTienda.SetActive(true);
                UIPrincipal.SetActive(false);
                MenuCartas.SetActive(false);
            }
        }
        else
        {
            CamaraPrincipal.SetActive(true);
            CamaraTienda.SetActive(false);
            UIPrincipal.SetActive(true);
            MenuCartas.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            UIManager.UI.CambiarTextoFCasa();
            UIManager.UI.OnAvisoTecla();
            FrentePuerta = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            UIManager.UI.OffAvisoTecla();
            FrentePuerta = false;
        }
    }

    public void EntrarTiendaSalir(string nivel)
    {
        SceneManager.LoadScene(nivel);
    }

    public void SalirTienda()
    {
        CamaraPrincipal.SetActive(true);
        CamaraTienda.SetActive(false);
        UIPrincipal.SetActive(true);
        MenuCartas.SetActive(false);
    }

    public void SalirMenuCartas()
    {
        CamaraPrincipal.SetActive(false);
        CamaraTienda.SetActive(true);
        UIPrincipal.SetActive(false);
        MenuCartas.SetActive(false);
    }

    public void EntrarMenuCartas()
    {
        CamaraPrincipal.SetActive(false);
        CamaraTienda.SetActive(false);
        UIPrincipal.SetActive(false);
        MenuCartas.SetActive(true);
    }
}
