using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlantillaItemTienda : MonoBehaviour
{
    public Image imagen;
    public TextMeshProUGUI textoPrecio;
    public TextMeshProUGUI titulo;
    public Button botonComprar;
    int precio;
    int monedaTotales = 900;

    public Color nuevoColor;
    private CharacterColorManager characterColorManager;

    // Start is called before the first frame update
    void Start()
    {
        precio = int.Parse(textoPrecio.text);


        characterColorManager = GameManager.instance.characterColorManager;
    }

    // Update is called once per frame
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

        if (botonComprar.interactable)
        {

            characterColorManager.ChangeCharacterColor(nuevoColor);


        }
    }


    private void OnApplicationQuit()
    {

        PlayerPrefs.SetInt("monedasTotales", 900);
    }
}




