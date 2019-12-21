using System;
using UnityEngine;
public class Item : MonoBehaviour
{
    [SerializeField] private int usedPoint;
    private GameObject _clickedGameObject;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (Camera.main != null) 
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
                RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                if (hit2d) {
                    _clickedGameObject = hit2d.transform.gameObject; 
                    if (_clickedGameObject == this.gameObject) Do();
                }
            }
        }
    }

    void Do()
    {
        if (Parameters.UnCleanEnergy >= usedPoint && !PlayerController.ShoesFlag)
        {
            Parameters.UnCleanEnergy -= usedPoint;
            Parameters.UnClearEnergyUsed += usedPoint;
            gameObject.AddComponent<Shooes>();
        }
    }

}
