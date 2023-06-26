using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    [SerializeField]
    private bool ReloadThisScene = false;

    [SerializeField]
    private string SceneName;

    [SerializeField]
    private bool AddButtonText = false;

    public void OnClick()
    {
        if (ReloadThisScene) SceneName = SceneManager.GetActiveScene().name;
        if (AddButtonText) SceneName = SceneName + " " + GetComponentInChildren<TMPro.TMP_Text>().text;
        SceneManager.LoadScene(SceneName);
    }
}
