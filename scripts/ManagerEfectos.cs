using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEfectos : MonoBehaviour
{
    public static ManagerEfectos Efectos;

    public GameObject pop;

    void Awake()
    {
        Efectos = this;
    }

    public void mostrarpop(Vector3 pos)
    {
        pop.gameObject.GetComponent<pop>().Encender(pos);
    }
    void OnDestroy()
    {
        Efectos = null;   
    }
}
