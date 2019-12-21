using UnityEngine;

public class UnCleanEnergy : MonoBehaviour
{
    [SerializeField]private int _pointBigger = 5;

    [SerializeField] private AudioClip _SE;
    [SerializeField]private AudioSource _audioSource;

    private void OnTriggerEnter2D(Collider2D other)
    {
        _audioSource.PlayOneShot(_SE);
        if (!other.gameObject.CompareTag("Player")) return;
        Parameters.UnCleanEnergy += _pointBigger;
        Destroy(gameObject);
    }
}
