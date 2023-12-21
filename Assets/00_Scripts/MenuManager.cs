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
      
        SceneManager.LoadScene("EscenarioBarcoPirata");
    }

    public void OptionsButton()
    {
       
        SceneManager.LoadScene("Opciones");
    }

    public void StoreButton()
    {

        SceneManager.LoadScene("Store");
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


