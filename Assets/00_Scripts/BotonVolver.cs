using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonVolver : MonoBehaviour
{
    public void ButtonBack()
    {

        SceneManager.LoadScene("00_MainMenu");
    }

}
