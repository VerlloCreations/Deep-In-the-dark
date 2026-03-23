using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerSonidos : MonoBehaviour
{
    public static ManagerSonidos sonidos;

    public AudioClip salto;
    public AudioClip moneda;
    public AudioClip gui;
    public AudioClip hit;
    public AudioClip dañoEnemigo;
    public AudioClip ganar;
    public AudioClip gameover;
    public AudioClip seleccion;

    private AudioSource audioSrc;
    void Awake()
    {
        sonidos = this;
        audioSrc= gameObject.AddComponent<AudioSource>();
    }

    public void ISalto()
    {
        iniciarSonido(salto);
    }

    public void Imoneda()
    {
        iniciarSonido(moneda);
    }

    public void Igui()
    {
        iniciarSonido(gui);
    }

    public void Ihit()
    {
        iniciarSonido(hit);
    }

    public void Idañoenemigo()
    {
        iniciarSonido(dañoEnemigo);
    }

    public void Iganar()
    {
        iniciarSonido(ganar);
    }

    public void Igameover()
    {
        iniciarSonido(gameover);
    }

    public void Iseleccion()
    {
        iniciarSonido(seleccion);
    }





    public void iniciarSonido(AudioClip clip)
    {
        audioSrc.PlayOneShot(clip);
    }
    void OnDestroy()
    {
        sonidos = null;
    }
}
