using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveScenesLoader : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadSceneAsync("SceneTransition", LoadSceneMode.Additive);
    }
}