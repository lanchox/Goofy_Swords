using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tienda : MonoBehaviour
{
    [SerializeField] List<PlantillaInformacionItem> informacionItem;
    [SerializeField] GameObject plantillaObjetoTienda;
    [SerializeField] TextMeshProUGUI textoMonedasTotales;
    // Start is called before the first frame update
    void Start()
    {
        if(!PlayerPrefs.HasKey("monedasTotales"))
        {
            PlayerPrefs.SetInt("monedasTotales", 900);
        }

        var plantillaItem = plantillaObjetoTienda.GetComponent<CambioColor>();

        foreach (var item in informacionItem)
        {
            plantillaItem.imagen.sprite = item.image;
            plantillaItem.titulo.text = item.titulo;
            plantillaItem.textoPrecio.text = item.precio.ToString();

            Instantiate(plantillaItem, transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        textoMonedasTotales.text = PlayerPrefs.GetInt("monedasTotales").ToString();
    }
}
