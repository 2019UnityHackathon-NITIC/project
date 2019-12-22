using UnityEngine;

class ToStage :MonoBehaviour{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SceneChanger.ChangeScene("Stage");
    }
}
