using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using UnityEngine.Experimental.Rendering;

public class HostSystemUI : MonoBehaviour
{
    [SerializeField] private Button[] uiButtons;
    [SerializeField] private Transform popUp;
    [SerializeField] TextMeshProUGUI textBar;
    private bool openPopUp;
    private void Start()
    {
        popUp.localScale = Vector3.zero;
        textBar.text = "";
        uiButtons[0].onClick.AddListener(()=> SceneManager.LoadScene(""));
        uiButtons[1].onClick.AddListener(OpenPanel);
        uiButtons[2].onClick.AddListener(ConnectTo);
        uiButtons[3].onClick.AddListener(OpenPanel);
    }

    private void Update()
    {
        if (openPopUp)
        {
            if (Input.inputString != "" && !Input.GetKey(KeyCode.Backspace))
            {
                textBar.text += Input.inputString;
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ConnectTo();
            }
            if(Input.GetKeyDown(KeyCode.Backspace) && textBar.text.Length > 0)
            {
                string deleteLetter = textBar.text.Substring(0, textBar.text.Length - 1);
                textBar.text = deleteLetter;
            }
        }
        else
        {
            /*if(Input.GetKeyDown(KeyCode.Escape))
            {
                OpenPanel();
            }*/
        }
    }
    public void OpenPanel()
    {
        if (!openPopUp)
        {
            popUp.DOScale(1f, 0.8f);
            openPopUp = true;
            textBar.text = "";
        }
        else
        {
            popUp.DOScale(0f, 0.8f);
            openPopUp = false;
        }
    }
    public void ConnectTo()
    {
        
    }
}
