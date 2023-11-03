using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System.Collections;




public class MenuManager : MonoBehaviour
{
    public void PlayButton()
    {
      
        SceneManager.LoadScene("Banco_De_Pruebas");
    }

    public void OptionsButton()
    {
       
        SceneManager.LoadScene("Opciones");
    }

   public void Quit()
    {
        #if UNITY_EDITOR 
        EditorApplication.isPlaying = false;
        #else 
        Application.Quit();
        #endif
    }
}


