using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controladorNiveles : MonoBehaviour
{
    public void CambiarEscena(string nivel)
    {
        SceneManager.LoadScene(nivel);
    }

    public void reintentar()
    {
        GameManager.Jefe.GameOver();
    }
}
