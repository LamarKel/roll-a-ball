using UnityEngine;

public class ObstaculoRestaTiempo : MonoBehaviour
{
    public GameManager gameManager;
    public float tiempoARestar = 10f;

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (gameManager != null)
                gameManager.RestarTiempo(tiempoARestar);
        }
    }
}
