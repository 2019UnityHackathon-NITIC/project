using System;
using UnityEngine;

public class CleanEnergy : MonoBehaviour
{
    [SerializeField]private int _pointBigger = 5;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        Parameters.CleanEnergy += _pointBigger;
        Destroy(gameObject);
    }
}
