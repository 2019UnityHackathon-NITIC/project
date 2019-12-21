using System.Collections;
using UnityEngine;
public class Item : MonoBehaviour
{
    [SerializeField] private int usedPoint;
    [SerializeField] private GameObject panel;
    [SerializeField] private AudioClip clickSound;
    private GameObject _clickedGameObject;
    private AudioSource _audioSource;


    public void OnClick()
    {
        if (Parameters.UnCleanEnergy >= usedPoint && !PlayerController.ShoesFlag)
        {
            Instantiate(panel);
            _audioSource = gameObject.AddComponent<AudioSource>();
            _audioSource.PlayOneShot(clickSound);
            Parameters.UnCleanEnergy -= usedPoint;
            Parameters.UnClearEnergyUsed += usedPoint;
            gameObject.AddComponent<Shooes>();
        }
    }

    private void Start()
    {
        
    }
}
