using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class jugador : MonoBehaviour
{

    public static jugador Obj;

    public int vidas = 3;
    public bool EnElSuelo = false;
    public bool SeMueve = false;
    public bool Inmune = false;
    public bool llegoMeta = false;

    public float velocidad = 3f;
    public float FuerzaSalto = 5f;

    public float MovHor;
    public float MovFinal;
    public float tiempoInmuneCnt = 0f;
    public float tiempoInmune = 0.5f;

    public LayerMask groundLayer;
    public float radio = 0.3f;
    public float groundRayDist = 0.5f;

    Rigidbody2D Rb;
    Animator anim;
    SpriteRenderer sprite;


    void Awake()
    {
        Obj = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        vidas = GameManager.Jefe.MaxVidas;
        UIManager.UI.actualizarVida();
        GameManager.Jefe.Gemas = 0;
        velocidad = GameManager.Jefe.VelocidadGlobal;
    }

    // Update is called once per frame
    void Update()
    {
        if (llegoMeta)
        {
            MovFinal -= Time.deltaTime;

            if (MovFinal >= 0)
            {
                MovHor = 1f;
            }
            else
            {
                MovHor = 0f;
            }

            if (MovFinal <= 0)
            {
                llegoMeta = false;
            }
        }
        if (!llegoMeta)
        {
            MovHor = Input.GetAxisRaw("Horizontal");
        }



        SeMueve = (MovHor != 0f);

        EnElSuelo = Physics2D.CircleCast(transform.position, radio, Vector3.down, groundRayDist, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            salto();
        }


        if (Inmune)
        {
            sprite.enabled = !sprite.enabled;

            tiempoInmuneCnt -= Time.deltaTime;

            if (tiempoInmuneCnt <= 0)
            {
                Inmune = false;
                sprite.enabled = true;
            }
        }

        Giro(MovHor);

        anim.SetBool("caminando", SeMueve);
        anim.SetBool("EnELAire", !EnElSuelo);
    }


    private void VaInmune()
    {
        Inmune = true;
        tiempoInmuneCnt = tiempoInmune;
    }

    public void salto()
    {
        if (!EnElSuelo) return;

        Rb.velocity = Vector2.up * FuerzaSalto;

        ManagerSonidos.sonidos.ISalto();
    }


    private void Giro(float valorX)
    {

        Vector3 Escala = transform.localScale;

        if (valorX < 0f)
        {
            Escala.x = MathF.Abs(Escala.x) * -1;
        }
        else

          if (valorX > 0f)
        {
            Escala.x = MathF.Abs(Escala.x);
        }

        transform.localScale = Escala;
    }

    void FixedUpdate()
    {
        Rb.velocity = new Vector2(MovHor * velocidad, Rb.velocity.y);
    }

    void OnDestroy()
    {
        Obj = null;
    }

    public void RecibirDaño()
    {
        if (Inmune == false)
        {
            vidas--;

            ManagerSonidos.sonidos.Ihit();

            UIManager.UI.actualizarVida();

            VaInmune();
        }

        if (vidas <= 0)
        {
            gameObject.SetActive(false);
            GameManager.Jefe.ActivarPantallaMuerte();
        }
    }

    public void agregarVida()
    {
        vidas++;

        if (vidas > GameManager.Jefe.MaxVidas)
        {
            vidas = GameManager.Jefe.MaxVidas;
        }
    }

    public void TermoinoNivel()
    {
        llegoMeta = true;
        MovFinal = 2f;
    }

    public void apagarJugador()
    {
        gameObject.SetActive(false);
    }
}
//<>