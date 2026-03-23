using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class muroRompible : MonoBehaviour
{
    public static muroRompible rompible;

    public BoxCollider2D hitbox;

    public GameObject efectoDestruido;

    SpriteRenderer render;

    private void Awake()
    {
        hitbox= GetComponent<BoxCollider2D>(); 
        render = GetComponent<SpriteRenderer>();
        rompible = this;
    }
    public void DestruirBloque()
    {
        efectoDestruido.SetActive(true);
        render.enabled = false;
        hitbox.enabled = false;
        Invoke("offCompleto",2);
        
    }

    void offCompleto()
    {
        gameObject.SetActive(false);
    }
}
