using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int usedPoint;
    [SerializeField] private GameObject createObject;
    [SerializeField] private bool clean = true;
    [SerializeField] private GameObject panel;
    private GameObject _clickedGameObject;
    private static bool createMode = false;
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            createMode = false;
            Destroy(GameObject.FindGameObjectWithTag("Inventory"));
        }
        if (Input.GetMouseButtonDown(0) && createMode) 
        {
            if (Camera.main != null)
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
                
        }
    }
    
    
    public void BuyObject()
    {
        if (clean && Parameters.CleanEnergy >= usedPoint)
        {
            Create();
        }
        else if ((!clean) && Parameters.UnCleanEnergy >= usedPoint)
        {

            Create();
        }
    }

    void Create()
    {
        createMode = true;
        panel.SetActive(false);
    }
}
        
