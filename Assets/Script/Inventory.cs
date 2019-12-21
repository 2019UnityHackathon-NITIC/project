using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int usedPoint;
    [SerializeField] private GameObject createObject;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private bool clean = true;
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject itemPanel;
    [SerializeField] private Image _box;
    private GameObject _clickedGameObject;
    private static bool createMode = false;
    [SerializeField] private AudioClip clickSound;
    private AudioSource audioSource;
    void Update()
    { 
        if (Input.GetKey(KeyCode.Escape))
        {
            createMode = false;
            itemPanel.SetActive(false);
            PlayerController.onHand = null;
            Destroy(GameObject.FindGameObjectWithTag("Inventory"));
        }
        if (Input.GetMouseButtonDown(0) && createMode) 
        {
            if (Camera.main != null)
            {
                audioSource.PlayOneShot(clickSound);
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
                PlayerController.onHand = null;
                itemPanel.SetActive(false);
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
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.PlayOneShot(clickSound);
        createMode = true;
        PlayerController.onHand = createObject;
        itemPanel.SetActive(true);
        _box.sprite = _sprite;
        panel.SetActive(false);
    }
}
        
