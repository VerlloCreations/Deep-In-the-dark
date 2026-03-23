using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static CartaPropiedades;

public class CartaPropiedades : MonoBehaviour
{
    public static CartaPropiedades instancia;

    bool SeGeneroMenu;
    int CartasTotales;
    int Columnas = 4;

    public int CostoTiradaSin;
    public int CostoTiradaCon;
    [SerializeField]int fila;
    [SerializeField] int separacionX = 400;
    [SerializeField] int separacionY = 400;

    [SerializeField] SpriteRenderer Personaje;
    [SerializeField] SpriteRenderer CartaMarco;
    [SerializeField] RectTransform ContenedorCartas;
    [SerializeField] GameObject PrefabCartas;

    public Sprite[] MarcosRareza;
    public List<Cartas> CartasInfo;
    public List<CartasInstanciadasUI> CartasInstanciadas;
    public List<ProbabilidadRarezas> Probs;

    CartasInstanciadasUI cartaSeleccionada;

    void Start()
    {
        CartasTotales = CartasInfo.Count * System.Enum.GetValues(typeof(Rareza)).Length;
        ProductosTienda.Instance.ActualizarDatosMonYGem();
        if (!SeGeneroMenu)
        {
            EntradaTienda.Instance.EntrarMenuCartas();
            MenuCartasDesbloqueadas();
            EntradaTienda.Instance.SalirTienda();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    public class CartasInstanciadasUI
    {
        public string nombreCarta;
        public string nombrePersonaje;
        public int id;    
        public GameObject PrefabEnUI;     
        public Rareza UIRareza;
        public bool desbloqueada = false;
        public UnityEngine.UI.Image PersonajeUI;
        public UnityEngine.UI.Image MarcoRarezaUI;
    }

    [System.Serializable]
    public class Cartas
    {
        public string personaje;
        public string descripcion;
        public Sprite spritePersonaje;
    }

    public enum Rareza
    {
        Comun,Rara,Epica,Legendaria
    }

    [System.Serializable]
    public class ProbabilidadRarezas
    {
        public Rareza Rareza;
        public float Prob;
    }

    public Cartas ObtenerPorPersonaje(string NombrePersonaje)
    {
        return CartasInfo.FirstOrDefault(c => c.personaje == NombrePersonaje);
    }

    public void TirarGachaSinProbabilidades()
    {
        if(GameManager.Jefe.puntos >= CostoTiradaSin)
        {
            GameManager.Jefe.PagarTiradaSin();
            UIManager.UI.actualizarPuntos();
            ProductosTienda.Instance.ActualizarDatosMonYGem();

            int indicePersonaje = Random.Range(0, CartasInstanciadas.Count);
            cartaSeleccionada = CartasInstanciadas[indicePersonaje];
            Cartas CartaResultado = ObtenerPorPersonaje(cartaSeleccionada.nombrePersonaje);

            if (CartaResultado != null)
            {
                cartaSeleccionada.desbloqueada = true;
                Personaje.sprite = CartaResultado.spritePersonaje;
                CartaMarco.sprite = MarcosRareza[(int)cartaSeleccionada.UIRareza];
                cartaSeleccionada.PersonajeUI.color = cartaSeleccionada.desbloqueada ? Color.white : Color.gray;
                cartaSeleccionada.MarcoRarezaUI.color = cartaSeleccionada.desbloqueada ? Color.white : Color.gray;
            }
        }
    }
    public void TirarGachaConProbs()
    {
        if(GameManager.Jefe.puntos >= CostoTiradaCon)
        {
            GameManager.Jefe.PagarTiradaCon();
            UIManager.UI.actualizarPuntos();
            ProductosTienda.Instance.ActualizarDatosMonYGem();

            // Paso 1: decidir rareza
            Rareza rarezaSeleccionada = ObtenerRarezaPorProbabilidad();

            // Paso 2: elegir carta de esa rareza
            cartaSeleccionada = ObtenerCartaPorRareza(rarezaSeleccionada);

            if (cartaSeleccionada != null)
            {
                Cartas CartaResultado = ObtenerPorPersonaje(cartaSeleccionada.nombrePersonaje);

                // Mostrar resultado
                Personaje.sprite = CartaResultado.spritePersonaje;
                CartaMarco.sprite = MarcosRareza[(int)cartaSeleccionada.UIRareza];

                // Marcar desbloqueada
                cartaSeleccionada.desbloqueada = true;

                cartaSeleccionada = CartasInstanciadas.FirstOrDefault(c => c.id == cartaSeleccionada.id);

                if (cartaSeleccionada != null)
                {
                    cartaSeleccionada.PersonajeUI.color = cartaSeleccionada.desbloqueada ? Color.white : Color.gray;
                    cartaSeleccionada.MarcoRarezaUI.color = cartaSeleccionada.desbloqueada ? Color.white : Color.gray;
                }
            }
        }
    }


    public Rareza ObtenerRarezaPorProbabilidad()
    {
        float random = Random.Range(0f, 1f);
        float acumulado = 0f;

        foreach (var p in Probs)
        {
            acumulado += p.Prob;
            if (random <= acumulado)
                return p.Rareza;
        }

        return Probs[0].Rareza;
    }

    public CartasInstanciadasUI ObtenerCartaPorRareza(Rareza rareza)
    {
        var cartasFiltradas = CartasInstanciadas
            .Where(c => c.UIRareza == rareza)
            .ToList();

        if (cartasFiltradas.Count == 0) return null;

        int indice = Random.Range(0, cartasFiltradas.Count);
        return cartasFiltradas[indice];
    }


    public void MenuCartasDesbloqueadas()
    {
        if (!SeGeneroMenu)
        {
            for (int CartasColocadasMenu = 0; CartasColocadasMenu < CartasTotales; CartasColocadasMenu++)
            {
                //Obtiene el objeto prefabricado para cambiarle las texturas
                GameObject CartaGenerada = Instantiate(PrefabCartas, ContenedorCartas);
                fila = CartasColocadasMenu / Columnas;
                int col = CartasColocadasMenu % Columnas;

                //Obtiene las rarezas
                Rareza CalidadColumna;

                //Obtiene el sprite del personaje
                Transform PersonajePrefab = CartaGenerada.transform.GetChild(1);
                UnityEngine.UI.Image SpritePersonajePrefab = PersonajePrefab.GetComponent<UnityEngine.UI.Image>();

                //Obtiene la informacion del personaje
                Cartas CartaObteniendoPersonaje = CartasInfo[fila];

                //Guarda la carta en una lista de todas las cartas posibles
                CartasInstanciadasUI ReferenciaUI = new CartasInstanciadasUI();

                //Obtiene el marco de rareza
                Transform MarcoPrefab = CartaGenerada.transform.GetChild(0);
                UnityEngine.UI.Image SpriteMarcoPrefab = MarcoPrefab.GetComponent<UnityEngine.UI.Image>();

                SpritePersonajePrefab.sprite = CartaObteniendoPersonaje.spritePersonaje;

                switch (col)
                {
                    case 0:

                        CalidadColumna = Rareza.Comun;
                        ReferenciaUI.UIRareza = Rareza.Comun;
                        ReferenciaUI.nombrePersonaje = CartaObteniendoPersonaje.personaje;
                        ReferenciaUI.nombreCarta = CartaObteniendoPersonaje.personaje + " " + Rareza.Comun;
                        SpriteMarcoPrefab.sprite = MarcosRareza[(int)CalidadColumna];

                        break;
                    case 1:

                        CalidadColumna = Rareza.Rara;
                        ReferenciaUI.UIRareza = Rareza.Rara;
                        ReferenciaUI.nombrePersonaje = CartaObteniendoPersonaje.personaje;
                        ReferenciaUI.nombreCarta = CartaObteniendoPersonaje.personaje + " " + Rareza.Rara;
                        SpriteMarcoPrefab.sprite = MarcosRareza[(int)CalidadColumna];

                        break;
                    case 2:

                        CalidadColumna = Rareza.Epica;
                        ReferenciaUI.UIRareza = Rareza.Epica;
                        ReferenciaUI.nombrePersonaje = CartaObteniendoPersonaje.personaje;
                        ReferenciaUI.nombreCarta = CartaObteniendoPersonaje.personaje + " " + Rareza.Epica;
                        SpriteMarcoPrefab.sprite = MarcosRareza[(int)CalidadColumna];

                        break;
                    case 3:

                        CalidadColumna = Rareza.Legendaria;
                        ReferenciaUI.UIRareza = Rareza.Legendaria;
                        ReferenciaUI.nombrePersonaje = CartaObteniendoPersonaje.personaje;
                        ReferenciaUI.nombreCarta = CartaObteniendoPersonaje.personaje + " " + Rareza.Legendaria;
                        SpriteMarcoPrefab.sprite = MarcosRareza[(int)CalidadColumna];

                        break; 
                    default:

                        CalidadColumna = Rareza.Comun;
                        ReferenciaUI.UIRareza = Rareza.Comun;
                        SpriteMarcoPrefab.sprite = MarcosRareza[(int)CalidadColumna];

                        break;
                }

                

                ReferenciaUI.id = CartasColocadasMenu;
                ReferenciaUI.PrefabEnUI = CartaGenerada;
                ReferenciaUI.PersonajeUI = SpritePersonajePrefab;
                ReferenciaUI.MarcoRarezaUI = SpriteMarcoPrefab;

                ReferenciaUI.PersonajeUI.color = ReferenciaUI.desbloqueada ? Color.white : Color.gray;
                ReferenciaUI.MarcoRarezaUI.color = ReferenciaUI.desbloqueada ? Color.white : Color.gray;

                CartasInstanciadas.Add(ReferenciaUI);

                Vector2 posicion = new Vector2(col * separacionX, -fila * separacionY);
                CartaGenerada.GetComponent<RectTransform>().anchoredPosition = posicion;

                CartaGenerada.name = $"Contenedor_1_{CartasColocadasMenu}";
                SeGeneroMenu = true;
            }
        }
    }

}
