using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class avisoCofre : MonoBehaviour
{
    public static avisoCofre aviso;

    Animator anima;
    private void Awake()
    {
        anima = GetComponent<Animator>();
        aviso = this;
    }

    public void NoTieneLlave()
    {
        anima.SetBool("iniciaAviso", true);
        Invoke("terminarAviso", 1.5f);
    }

    void terminarAviso()
    {
        anima.SetBool("iniciaAviso", false);
    }


}
