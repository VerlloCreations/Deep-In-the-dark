using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bloqueDestruido : MonoBehaviour
{
    public int Randomizador;
    float mov1;
    float mov2;
    float mov3;

    int velocidad = 2;
    Rigidbody2D RB;

    private void Awake()
    {
        RB= GetComponent<Rigidbody2D>(); 
        mov1 = Random.Range(3f, 1);
        mov2 = Random.Range(3f, 1);
        mov3 = Random.Range(3f, 1);
            




    }
    // Start is called before the first frame update
    void Start()
    {
        Randomizador = Random.Range(1,4);
        if(Randomizador == 1)
        {
            arriba();
        }
        if(Randomizador == 2)
        {
            diagonal1();
        }
        if(Randomizador == 3)
        {
            diagonal2();
        }
    }

    void diagonal2()
    {
        RB.velocity = new Vector2(-mov3 * velocidad, mov2 * velocidad);
    }
    void diagonal1()
    {   
        RB.velocity = new Vector2(mov2 * velocidad, mov1 * velocidad);
    }
    void arriba()
    {
        RB.velocity = new Vector2(RB.velocity.x,mov1 * velocidad);
    }
}
