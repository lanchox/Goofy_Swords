using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.UI;
public class Cargar : MonoBehaviour
{
    void Start()
    {
        NetSaveData.instance.InicioJuego();
    }
}
