using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambioCamara : MonoBehaviour
{
    public GameObject camaraprincipal, camara1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            camaraprincipal.SetActive(false);
            camara1.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            camaraprincipal.SetActive(true);
            camara1.SetActive(false);
        }
    }
}
