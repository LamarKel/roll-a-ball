using UnityEngine;

public class MoverObstaculo : MonoBehaviour
{
    public Vector3 puntoA;
    public Vector3 puntoB;
    public float velocidad = 2f;

    private float t;

    void Start()
    {
        // Si no configuraste puntos manualmente, crea un recorrido por defecto
        if (puntoA == Vector3.zero && puntoB == Vector3.zero)
        {
            puntoA = transform.position;
            puntoB = transform.position + new Vector3(6f, 0f, 0f);
        }
    }

    void Update()
    {
        t += Time.deltaTime * velocidad;

        // Oscila 0..1..0
        float k = (Mathf.Sin(t) + 1f) / 2f;
        transform.position = Vector3.Lerp(puntoA, puntoB, k);
    }
}
