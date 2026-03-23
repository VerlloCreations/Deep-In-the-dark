using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pop : MonoBehaviour
{
    public static pop obj;

    void Awake()
    {
        obj = this;
    }

    public void Encender(Vector3 pos)
    {
        transform.position = pos; 
        gameObject.SetActive(true);
    }

    public void apagar()
    {
        gameObject.SetActive(false);
    }

    void OnDestroy()
    {
        obj = null;
    }
}
