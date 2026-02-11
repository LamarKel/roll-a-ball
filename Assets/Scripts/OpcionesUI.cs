using UnityEngine;
using UnityEngine.SceneManagement;

public class OpcionesUI : MonoBehaviour
{
    public void Volver()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}
