using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Netcode.Transports.UTP;
using UnityEngine;
public class NetSaveData : MonoBehaviour
{
    public string proxyAddress = "$-CaOdNr-N-eEsCsT-$";
    public string proxyPort = "$-OpTo-H-rEtR-$";
    public string isHost = "$-PhAo-R-mTeY-$";
    public UnityTransport ut;
    public static NetSaveData instance;
    private void Awake()
    {
        instance = this;
    }
    public void InicioJuego()
    {
        if (PlayerPrefs.GetInt(isHost) == 1)
        {
            NetworkManager.Singleton.StartHost();
            Debug.Log("es Host");
        }
        else
        {
            ClientStarter();
            Debug.Log("es Cliente");
        }
    }

    public void SaveAddress()
    {
        PlayerPrefs.SetString(proxyAddress, FindObjectOfType<HostSystemUI>().ipBar.text);
        PlayerPrefs.SetString(proxyPort, FindObjectOfType<HostSystemUI>().portBar.text);
        PlayerPrefs.SetInt(isHost, 0);
        SceneManager.LoadScene(1);
    }

    public void ClientStarter()
    {
        ut.ConnectionData.Address = PlayerPrefs.GetString(proxyAddress);
        string portString = PlayerPrefs.GetString(proxyPort);
        ut.ConnectionData.Port = ushort.Parse(portString);
        NetworkManager.Singleton.StartClient();
    }
    public void HostExist()
    {
        PlayerPrefs.SetInt(isHost, 1);
        SceneManager.LoadScene(1);
    }
}
