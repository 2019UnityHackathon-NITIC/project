using UnityEngine;

public class UnCleanEnergy : MonoBehaviour
{
    [SerializeField]private int _pointBigger = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        Parameters.UnCleanEnergy += _pointBigger;
        Destroy(gameObject);
    }
}