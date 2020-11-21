using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestLoaderButton : MonoBehaviour
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
