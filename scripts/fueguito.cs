using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fueguito : MonoBehaviour
{
    private Rigidbody2D RB;

    public float MovHor = 0f;
    public float Velocidad = 4f;

    public bool HaySuelo = false;

    public LayerMask groundlayer;
    public float frontGroundRayGist = 0.25f;
    public float floorCheckY = 0.52f;
    public float frontCheck = 0.51f;
    public float frontDist = 0.001f;

    private RaycastHit2D hit;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        HaySuelo = (Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - floorCheckY, transform.position.z), new Vector3(MovHor, 0, 0), frontGroundRayGist, groundlayer));

        if (!HaySuelo)
        {
            MovHor = MovHor * -1;
        }

        //detacta si hay una pared
        if (Physics2D.Raycast(transform.position, new Vector3(MovHor, 0, 0), frontCheck, groundlayer))
        {
            MovHor = MovHor * -1;
        }

        //detecta si choca con un enemigo

        hit = Physics2D.Raycast(new Vector3(transform.position.x + MovHor * frontCheck, transform.position.y, transform.position.z), new Vector3(MovHor, 0, 0), frontDist);



        if (hit.transform != null)
        {
            if (hit.transform != null)
            {
                if (hit.transform.CompareTag("enemigo"))
                {
                    MovHor = MovHor * -1;
                }
            }
        }

        Giro(MovHor);


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

    private void FixedUpdate()
    {
        RB.velocity = new Vector2(MovHor * Velocidad, RB.velocity.y);
    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //hace daño al jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            jugador.Obj.RecibirDaño();
        }
    }

}
