using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreenController : MonoBehaviour
{
    public Slider slider;
    public Animator animator;

    private void Start()
    {
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(1);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            var progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;

            if(progress == 1)
            {
                yield return new WaitForSeconds(1.5f);

                animator.Play("LoadingScreen");

                yield return new WaitForSeconds(2f);

                operation.allowSceneActivation = true;
                
                yield return null;
            }

            yield return null;
        }
    }
}