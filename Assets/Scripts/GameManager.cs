using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public float tiempo = 120f;

    public TextMeshProUGUI textoTiempo;
    public TextMeshProUGUI textoEstado;

    public string escenaMenu = "MenuPrincipal";

    private bool termino = false;
    public string siguienteEscena = "";
    public float volverMenuEnSegundos = 5f;
    public string mensajeGanar = "Ganaste";
    public string mensajePerder = "Perdiste";


    void Start()
    {
        if (textoEstado != null)
            textoEstado.text = "";
    }

    void Update()
    {
        if (termino) return;

        tiempo -= Time.deltaTime;

        if (textoTiempo != null)
            textoTiempo.text = "Tiempo: " + Mathf.CeilToInt(tiempo);

        if (tiempo <= 0f)
        {
            Perder();
        }
    }

    public void Ganar()
    {
        if (termino) return;
        termino = true;

        if (textoEstado != null)
            textoEstado.text = mensajeGanar;

        StartCoroutine(CambiarEscenaDespues(siguienteEscena));

    }

    public void Perder()
    {
        if (termino) return;
        termino = true;

        if (textoEstado != null)
            textoEstado.text = mensajePerder;

        StartCoroutine(CambiarEscenaDespues(escenaMenu));
    }
    public void RestarTiempo(float segundos)
    {
        tiempo -= segundos;

        if (tiempo < 0f)
            tiempo = 0f;
    }


    IEnumerator CambiarEscenaDespues(string escena)
    {
        yield return new WaitForSeconds(volverMenuEnSegundos);
        SceneManager.LoadScene(escena);
    }

}
