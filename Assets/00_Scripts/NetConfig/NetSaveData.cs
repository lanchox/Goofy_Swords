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
    public UnityTransport ut;
    public static NetSaveData instance;
    private void Awake()
    {
        instance = this;
    }
    public void ClientStarter()
    {
        ut.ConnectionData.Address = FindObjectOfType<HostSystemUI>().ipBar.text;
        string portString = FindObjectOfType<HostSystemUI>().portBar.text;
        ut.ConnectionData.Port = ushort.Parse(portString);
        NetworkManager.Singleton.StartClient();
    }
    public void HostStarter()
    {
        NetworkManager.Singleton.StartHost();
    }
}
