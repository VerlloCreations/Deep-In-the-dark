using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{

    public bool ControlNPC;
    public float VelocidadZoom;

    public Transform fondo0;
    public float factor0 = 1f;

    public Transform fondo1;
    public float factor1 = 1 / 2f;

    public Transform fondo2;
    public float factor2 = 1 / 4f;

    private float desplazamiento;
    private float IniMovCam;
    private float sigMovCam;

    Camera cam;
    Vector3 camPos;
    void Start()
    {
        cam = GetComponent<Camera>();
        camPos = new Vector3(6.5f,0.5f,transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if(ColleteNPC.NPC != null)
        {
            if (ColleteNPC.NPC.Hablar)
            {
                ControlNPC = true;
                transform.position = Vector3.MoveTowards(transform.position, camPos, 6f * Time.deltaTime);
                
                if(cam.orthographicSize >= 2.1f)
                {
                    cam.orthographicSize -= VelocidadZoom * Time.deltaTime;
                }
                else
                {
                    cam.orthographicSize = 2;
                }            
                
                if(transform.position == camPos)
                {
                    ColleteNPC.NPC.CamaraEnPosicion = true;
                }
            }
            else
            {
                ControlNPC = false;
                cam.orthographicSize = 3;
            }
        }

        if(jugador.Obj.llegoMeta == false && !ControlNPC)
        {
            IniMovCam = transform.position.x;
               transform.position = new Vector3(jugador.Obj.transform.position.x,
                  jugador.Obj.transform.position.y, transform.position.z);
        }
        
    }

    void LateUpdate()
    {
        if (!ControlNPC)
        {
            sigMovCam = transform.position.x;

            fondo0.position = new Vector3(fondo0.position.x + (sigMovCam - IniMovCam) * factor0, fondo0.position.y, fondo0.position.z);

            fondo1.position = new Vector3(fondo1.position.x + (sigMovCam - IniMovCam) * factor1, fondo1.position.y, fondo1.position.z);

            fondo2.position = new Vector3(fondo2.position.x + (sigMovCam - IniMovCam) * factor2, fondo2.position.y, fondo2.position.z);
        }
    }
}
