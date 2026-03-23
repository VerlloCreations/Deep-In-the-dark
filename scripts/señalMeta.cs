using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class señalMeta : MonoBehaviour
{
    private AudioSource musica;

    void Awake()
    {
        musica= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            UIManager.UI.ActivarPantallafinal();
            jugador.Obj.TermoinoNivel();
            musica.volume = 0.3f;
            ManagerSonidos.sonidos.Iganar();
            GameManager.Jefe.MonedasRecolectadas = GameManager.Jefe.puntos;
        }
    }

}
