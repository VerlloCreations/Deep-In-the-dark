using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Transform MenuNiveles;
    public Transform InicialMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Niveles()
    {
        MenuNiveles.gameObject.SetActive(true);
        InicialMenu.gameObject.SetActive(false);
        ManagerSonidos.sonidos.Iseleccion();
    }

    public void regresarMenuI()
    {
        MenuNiveles.gameObject.SetActive(false);
        InicialMenu.gameObject.SetActive(true);
        ManagerSonidos.sonidos.Iseleccion();

    }

    public void cerrarJuego()
    {
        Application.Quit();
        ManagerSonidos.sonidos.Iseleccion();
    }
}
