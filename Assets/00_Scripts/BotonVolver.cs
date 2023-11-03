using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonVolver : MonoBehaviour
{
    public void ButtonBack()
    {

        SceneManager.LoadScene("Inicio");
    }
}
