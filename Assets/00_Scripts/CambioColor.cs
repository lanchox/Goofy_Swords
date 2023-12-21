using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class CambioColor : MonoBehaviour
{
    public Image imagen;
    public TextMeshProUGUI textoPrecio;
    public TextMeshProUGUI titulo;
    public Button botonComprar;
    int precio;
    int monedaTotales = 900;

    //public Color nuevoColor;
    //private CharacterColorManager characterColorManager;

    public void byColor()
    {
        //PlayerPrefs.SetInt("mi skin", 1);
    }

    void Start()
    {
        precio = int.Parse(textoPrecio.text);
        //characterColorManager = GameManager.instance.characterColorManager;

    }

    void Update()
    {
        monedaTotales = PlayerPrefs.GetInt("monedasTotales");
        if (precio > monedaTotales)
        {
            botonComprar.interactable = false;
        }
    }

    public void Comprar()
    {
        monedaTotales -= precio;
        PlayerPrefs.SetInt("monedasTotales", monedaTotales);
        PlayerPrefs.SetInt("mi skin", 1);

        //characterColorManager.ChangeCharacterColor(nuevoColor);
        //PlayerPrefs.SetString("colorActual", ColorUtility.ToHtmlStringRGBA(nuevoColor)); // Guardar el nuevo color como cadena hexadecimal

        // Si es necesario desactivar el botón después de la compra, hazlo aquí.
        botonComprar.interactable = false;
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("monedasTotales", 900);
    }

}
