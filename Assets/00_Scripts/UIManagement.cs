using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.Netcode;
using DG.Tweening;
using UnityEngine.Experimental.Rendering;

public class UIManagement : NetworkBehaviour
{
    public string sceneName;
    public List<Button> buttonsInScene;
    public List<Slider> sliderInScene;
    private void Awake()
    {
        sceneName = SceneManager.GetActiveScene().name;
    }

    void Start()
    {
        switch (sceneName)
        {
            //Aquí asignamos las acciones correpondientes a los Botones según escena;
            case "00_MainMenu":
                break;
            case "01_Options":
                break;
            case "02_CreateHost":
                break;
            case "03_JoinLikeClient":
                break;
            case "04_Shop":
                break;
            case "05_CharacterEditor":
                break;
            case "06_ShipBattleArena":
                break;
        }
    }
    void Update()
    {
        switch (sceneName)
        {
            //designamos acciones específicas que sean madas por Inputs si la escena trabajada lo necesita.
            //Acciones de aperturas y cierres de menús in Game o ventanas emergentes.
            case "00_MainMenu":
                break;
            case "01_Options":
                break;
            case "02_CreateHost":
                break;
            case "03_JoinLikeClient":
                break;
            case "04_Shop":
                break;
            case "05_CharacterEditor":
                break;
            case "06_ShipBattleArena":
                break;
        }
    }
    /*Cada void escrito desde aquí hacia abajo, debe corresponder a las acciones de los distintos botones del juego.
    Si estos voids activan corrutinas o funciones derivadas,
    entonces, estas deben tipearse inmediatamente después del void que las llama.*/
    public void LoadSceneMainMenu()
    {
        SceneManager.LoadScene("00_MainMenu");
    }

    public void LoadSceneOptions()
    {
        SceneManager.LoadScene("01_Options");
    }

    public void LoadSceneCreateHost()
    {
        SceneManager.LoadScene("02_CreateHost");
    }

    public void LoadSceneJoinLikeClient()
    {
        SceneManager.LoadScene("03_JoinLikeClient");
    }

    public void LoadSceneShop()
    {
        SceneManager.LoadScene("04_Shop");
    }

    public void LoadSceneCharacterEditor()
    {
        SceneManager.LoadScene("05_CharacterEditor");
    }
    public void StartHost()
    {
        NetworkManager.StartHost();
    }
    public void StartClient()
    {
        NetworkManager.StartClient();
    }
}
