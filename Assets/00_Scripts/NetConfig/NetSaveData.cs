using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.Netcode.Transports.UTP;
using Unity.VisualScripting;
using UnityEngine;

public class NetSaveData : MonoBehaviour
{
    public string proxyAddress = "$-CaOdNr-N-eEsCsT-$";
    public string proxyPort = "$-OpTo-H-rEtR-$";
    public string isHost = "$-PhAo-R-mTeY-$";
    public UnityTransport ut;
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "EscenaBarcoPirata")
        {
            if (PlayerPrefs.GetInt(isHost) == 1)
            {
                HostStarter();
            }
            else
            {
                ClientStarter();
            }
        }
    }

    public void SaveAddress()
    {
        PlayerPrefs.SetString(proxyAddress, GameObject.Find("ManagerAgent").GetComponent<HostSystemUI>().ipBar.text);
        PlayerPrefs.SetString(proxyPort, GameObject.Find("ManagerAgent").GetComponent<HostSystemUI>().portBar.text);
        PlayerPrefs.SetInt(isHost, 0);
    }

    public void ClientStarter()
    {
        ut.ConnectionData.Address = PlayerPrefs.GetString(proxyAddress);
        string portString = PlayerPrefs.GetString(proxyPort);
        ut.ConnectionData.Port = ushort.Parse(portString);
        NetworkManager.Singleton.StartClient();
    }
    public void HostStarter()
    {
        NetworkManager.Singleton.StartHost();
    }

    public void HostExist()
    {
        PlayerPrefs.SetInt(isHost, 1);
    }
}
