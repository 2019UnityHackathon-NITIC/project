using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class SceneChanger : MonoBehaviour
    {
        [SerializeField]
        public string mainScene = "SampleScene";

        public void StartGame()
        {
            SceneManager.LoadScene(mainScene);
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
           
        }
    }
}
