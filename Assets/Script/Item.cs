using System.Collections;
using UnityEngine;
public class Item : MonoBehaviour
{
    [SerializeField] private int usedPoint;
    private GameObject _clickedGameObject;
    

    public void OnClick()
    {
        if (Parameters.UnCleanEnergy >= usedPoint && !PlayerController.ShoesFlag)
        {
            Parameters.UnCleanEnergy -= usedPoint;
            Parameters.UnClearEnergyUsed += usedPoint;
            gameObject.AddComponent<Shooes>();
        }
    }

    private void Start()
    {
        
    }
}
