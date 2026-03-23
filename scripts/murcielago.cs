using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class murcielago : MonoBehaviour
{

    private Rigidbody2D RB;

    
    public bool mueveDerecha = false;

    public int puntosEntrega = 2;
   
    public float velocidad = 2f;

    public Transform puntoDerecha, puntoIzquierda;



    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();

        //evita que se muevan los hijos seleccionados
        puntoDerecha.parent = null;
        puntoIzquierda.parent = null;
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
       
    }


    void EsEliminado()
    {
        GameManager.Jefe.AgregarPuntos(puntosEntrega);
        UIManager.UI.actualizarPuntos();

        ManagerSonidos.sonidos.Idañoenemigo();

        ManagerEfectos.Efectos.mostrarpop(transform.position);

        gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
       
            if (mueveDerecha == true)
            { 
            
                RB.velocity = new Vector2(velocidad,RB.velocity.y);

                if (transform.position.x > puntoDerecha.position.x)
                {
                   mueveDerecha = false;
                }
            }
            else
            {
               RB.velocity = new Vector2(-velocidad,RB.velocity.y);

                if (transform.position.x < puntoIzquierda.position.x)
                {
                   mueveDerecha = true;
                }
            }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //hace daño al jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            jugador.Obj.RecibirDaño();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //mata el slime :(
        if (collision.gameObject.CompareTag("Player"))
        {
            EsEliminado();
        }
    }
}
