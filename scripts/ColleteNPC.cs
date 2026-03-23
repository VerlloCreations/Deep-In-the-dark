using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColleteNPC : MonoBehaviour
{
    public static ColleteNPC NPC;

    public List<Dialogos> ListaDialogos;
    private Dialogos dialogoActual;

    public bool RangoHablar,Hablar,CamaraEnPosicion, DejoHablar;

    Animator animator;
    void Awake()
    {
        if (NPC == null)
        {
            NPC = this;
        }
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (RangoHablar)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                Hablar = true;
                animator.SetFloat("TurnoAnimacion",3f);
            }
        }
        else
        {
            CamaraEnPosicion = false;
            UIManager.UI.ApaBurbuja();
        }


        if (CamaraEnPosicion)
        {
            UIManager.UI.ActBurbuja();
            ListaDialogos[0].Dialogo.gameObject.SetActive(true);
        }

    }

    [System.Serializable]
    public class Dialogos
    {
        public string Name;
        public int ID;
        public GameObject Dialogo;
    }

    // 0 = Idle 1 = Saludando 2 = hablando1 3 = hablando2 4 = Libro

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && DejoHablar == false)
        {
            RangoHablar = true;
            UIManager.UI.CambiarTextoFNPC();
            UIManager.UI.OnAvisoTecla();
            animator.SetFloat("TurnoAnimacion", 1f);
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            RangoHablar = false;
            Hablar = false;
            DejoHablar = false;
            UIManager.UI.OffAvisoTecla();
            UIManager.UI.ApaBurbuja();
            animator.SetFloat("TurnoAnimacion", 0f);
        }
    }

    public void MostrarDialogo(int id)
    {
        // Apagar todos
        foreach (var d in ListaDialogos)
            if (d.Dialogo != null) d.Dialogo.SetActive(false);

        // Buscar el que corresponde
        dialogoActual = ListaDialogos.Find(x => x.ID == id);

        if (dialogoActual != null && dialogoActual.Dialogo != null)
        {
            dialogoActual.Dialogo.SetActive(true);

            if (id == 6)
            {
                var extra = ListaDialogos.Find(x => x.ID == 7);
                if (extra != null && extra.Dialogo != null)
                    extra.Dialogo.SetActive(true);
                
            }

            if (id >= 9 && id <= 13)
            {
                // Activa el 8
                var extra8 = ListaDialogos.Find(x => x.ID == 8);
                if (extra8 != null && extra8.Dialogo != null)
                {
                    extra8.Dialogo.SetActive(true);
                }

                // Activa también el 6
                var extra6 = ListaDialogos.Find(x => x.ID == 6);
                if (extra6 != null && extra6.Dialogo != null)
                {
                    extra6.Dialogo.SetActive(true);
                }
               
            }

            if(id == 1)
            {
                animator.SetFloat("TurnoAnimacion", 3f);
            }else if(id >= 6 && id <= 13)
            {
                animator.SetFloat("TurnoAnimacion", 4f);
            }
            else
            {
                animator.SetFloat("TurnoAnimacion", 2f);
            }
        }
        else
        {
            Debug.LogError("No existe diálogo con ID " + id);
        }
    }

    public void SalirDialogo()
    {
        DejoHablar = true;
        UIManager.UI.ApaBurbuja();
        animator.SetFloat("TurnoAnimacion", 0f);
    }
}
