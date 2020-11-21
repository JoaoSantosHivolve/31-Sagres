using Assets.Scripts.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitor : Singleton<SceneTransitor>
{
    private Animator m_Animator;

    protected override void Awake()
    {
        base.Awake();

        m_Animator = GetComponent<Animator>();
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }

    private IEnumerator LoadSceneCoroutine(string sceneName)
    {
        m_Animator.SetBool("Start", true);
        yield return new WaitForSeconds(1f);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            var progress = Mathf.Clamp01(operation.progress / .9f);

            //slider.value = progress;

            if (progress == 1)
            {
                m_Animator.SetTrigger("Done");
                yield return new WaitForSeconds(1f);

                operation.allowSceneActivation = true;
                m_Animator.SetBool("Start", false);
                yield return new WaitForSeconds(1f);

                yield return null;
            }

            yield return null;
        }
    }
}
