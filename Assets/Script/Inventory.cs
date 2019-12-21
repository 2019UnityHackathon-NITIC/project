﻿using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int usedPoint;
    [SerializeField] private GameObject createObject;
    [SerializeField] private bool clean = true;
    private GameObject _clickedGameObject;
    private static bool createMode = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            if (createMode && Camera.main != null)
            {
                if (clean)
                {
                    Parameters.CleanEnergy -= usedPoint;
                    Parameters.CleanEnergyUsed += usedPoint;
                }
                else
                {
                    Parameters.UnCleanEnergy -= usedPoint;
                    Parameters.UnClearEnergyUsed += usedPoint;
                }

                Vector2 mousePos = Input.mousePosition;
                Vector2 createPos = Camera.main.ScreenToWorldPoint(mousePos);
                Instantiate(createObject, createPos, Quaternion.identity);
                createMode = false;
            }
            else if (Camera.main != null) 
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
                RaycastHit2D hit2d = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                if (hit2d) {
                    _clickedGameObject = hit2d.transform.gameObject; 
                    if (_clickedGameObject == this.gameObject) BuyObject();
                }
            }
            else if (Input.GetKey(KeyCode.Escape)) createMode = false;
        }
    }

    void BuyObject()
    {
        if (clean && Parameters.CleanEnergy >= usedPoint)
        {
            Parameters.CleanEnergy -= usedPoint;
            Parameters.CleanEnergyUsed += usedPoint;
            Create();
        }
        else if ((!clean) && Parameters.UnCleanEnergy >= usedPoint)
        {
            Parameters.UnCleanEnergy -= usedPoint;
            Parameters.UnClearEnergyUsed += usedPoint;
            Create();
        }
    }

    void Create()
    {
        createMode = true;
    }
}
        