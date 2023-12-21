using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorACambiar : MonoBehaviour
{
    Renderer rend;
    public List<Color> skins;
    private int nuevaSkin;

    private void Start()
    {
        skins.Add(Color.green);
        skins.Add(Color.red);
        skins.Add(Color.blue);
        rend = GetComponent<Renderer>();
        nuevaSkin = PlayerPrefs.GetInt("mi skin");
        rend.materials[0].color = skins[nuevaSkin];
    }

}
