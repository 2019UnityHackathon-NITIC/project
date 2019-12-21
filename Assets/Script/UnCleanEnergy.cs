using UnityEngine;

public class UnCleanEnergy : MonoBehaviour
{
    [SerializeField]private int _pointBigger = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        Parameters.UnCleanEnergy += _pointBigger;
        Destroy(gameObject);
    }
}