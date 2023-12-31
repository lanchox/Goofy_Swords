using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;

public class HostSystemUI : MonoBehaviour
{
    [SerializeField] private Transform popUp, totalMenu;
    [SerializeField] private GameObject cam;
    public TextMeshProUGUI ipBar, portBar;
    private bool openPopUp, enterIp;
    private void Start()
    {
        popUp.localScale = Vector3.zero;
    }

    private void Update()
    {
        if (openPopUp)
        {
            if (Input.inputString != "" && !Input.GetKey(KeyCode.Backspace))
            {
                if (!enterIp)
                {
                    ipBar.text += Input.inputString;
                }
                else
                {
                    portBar.text += Input.inputString;
                }
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (!enterIp)
                {
                    enterIp = true;
                }
                else
                {
                     NetSaveData.instance.ClientStarter();
                }
            }
            if(Input.GetKeyDown(KeyCode.Backspace))
            {
                if (!enterIp && ipBar.text.Length > 0)
                {
                    string deleteLetter = ipBar.text.Substring(0, ipBar.text.Length - 1);
                    ipBar.text = deleteLetter;
                }
                else if(portBar.text.Length > 0)
                {
                    string deleteLetter = portBar.text.Substring(0, portBar.text.Length - 1);
                    portBar.text = deleteLetter;
                }
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                OpenPanel();
            }
        }
    }
    public void OpenPanel()
    {
        if (!openPopUp)
        {
            popUp.DOScale(0.75f, 0.8f);
            openPopUp = true;
            ipBar.text = "127.0.0.1";
            portBar.text = "7777";
        }
        else
        {
            popUp.DOScale(0f, 0.8f);
            openPopUp = false;
        }
    }

    public void CloseTotalMenu()
    {
        totalMenu.DOScale(0f, 0.3f);
        Destroy(cam);
    }
}
