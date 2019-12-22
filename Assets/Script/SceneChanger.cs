using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    [SerializeField] private string mainScene = "SampleScene";
    private GameObject _clickedGameObject;

    public void StartGame()
    {
        Parameters.CleanEnergy = Parameters.UnCleanEnergy = Parameters.CleanEnergyUsed = Parameters.UnClearEnergyUsed = 0;
        PlayerController.ShoesFlag = PlayerController2.ShoesFlag = PlayerController._shoesFlagManager = PlayerController2._shoesFlagManager = false;
        SceneManager.LoadScene(mainScene);
    }

    public static void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    // Update is called once per frame
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
                    if (_clickedGameObject == this.gameObject) StartGame();
                }
            }
        }
    }
}
