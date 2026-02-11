using UnityEngine;
using TMPro;

public class JugadorController : MonoBehaviour
{
    private Rigidbody rb;
    public float velocidad = 10f;

    private int contador = 0;

    public TextMeshProUGUI textoContador;
    public TextMeshProUGUI textoGanar;

    public GameManager gameManager;
    public int totalColeccionables = 12;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ActualizarUI();
        if (textoGanar != null) textoGanar.text = "";
    }

    void FixedUpdate()
    {
        float movimientoH = Input.GetAxis("Horizontal");
        float movimientoV = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);
        rb.AddForce(movimiento * velocidad);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);

            contador++;
            ActualizarUI();
        }
    }

    void ActualizarUI()
    {
        if (textoContador != null)
            textoContador.text = "Contador: " + contador;

        if (contador >= totalColeccionables)
        {
            if (gameManager != null)
                gameManager.Ganar();
        }

    }
}
