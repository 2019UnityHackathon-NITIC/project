using System;
using UnityEngine;

public class CleanEnergy : MonoBehaviour
{
    [SerializeField]private int _pointBigger = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        Parameters.CleanEnergy += _pointBigger;
        Destroy(gameObject);
    }
}
