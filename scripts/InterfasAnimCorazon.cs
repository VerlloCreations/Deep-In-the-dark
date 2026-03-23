using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InterfasAnimCorazon : MonoBehaviour
{
    public static InterfasAnimCorazon comp;

    Animator corazon;

    private void Awake()
    {
        if (comp = null)
        {
            comp = this;
        }
        corazon = GetComponent<Animator>();
    }
    private void Update()
    {
        if (jugador.Obj.vidas == 3)
       {
            corazon.SetFloat("vida",3f);
       }

        if (jugador.Obj.vidas == 2)
        {
            corazon.SetFloat("vida", 2f);
        }

        if (jugador.Obj.vidas == 1)
        {
            corazon.SetFloat("vida", 1f);
        }
    }

    public void VelocidadCorazon()
    {
       
    }
}
