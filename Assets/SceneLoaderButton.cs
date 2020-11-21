using UnityEngine;
using UnityEngine.UI;

public class SceneLoaderButton : MonoBehaviour
{
    public string sceneName;

    private void Awake()
    {
        GetComponent<Button>().onClick.AddListener(LoadScene);
    }
    private void LoadScene()
    {
        SceneTransitor.Instance.LoadScene(sceneName);
    }
}