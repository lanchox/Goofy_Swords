using UnityEngine;
using UnityEngine.SceneManagement;




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
        
       
        Application.Quit();
        
    }
}


