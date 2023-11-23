using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColorManager : MonoBehaviour
{
    private Renderer characterRenderer; // El componente Renderer del personaje

    private void Start()
    {
        // Asumo que el componente Renderer está en el mismo GameObject que este script
        characterRenderer = GetComponent<Renderer>();
    }

    // Método para cambiar el color del personaje
    public void ChangeCharacterColor(Color newColor)
    {
        // Cambia el color del personaje
        characterRenderer.material.color = newColor;
    }

    // Método adicional para configurar el color directamente desde fuera (si es necesario)
    public void SetCharacterColor(Color initialColor)
    {
        // Configura el color inicial del personaje
        characterRenderer.material.color = initialColor;
    }
}
