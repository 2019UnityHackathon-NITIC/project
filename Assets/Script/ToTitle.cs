using UnityEngine;
class ToTitle : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) SceneChanger.ChangeScene("TitleScene");
    }
}
