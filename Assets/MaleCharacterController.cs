using System.Collections;
using UnityEngine;

public class MaleCharacterController : MonoBehaviour
{
    public Animator coffeeAnimator;
    private Animator m_Animator;

    private void Awake()
    {
        m_Animator = GetComponent<Animator>();

        StartCoroutine(FirstStep());
    }

    private IEnumerator FirstStep()
    {
        yield return new WaitForSeconds(2);
        coffeeAnimator.SetTrigger("t_doors_open");
        coffeeAnimator.SetTrigger("roof_exit");
        m_Animator.SetBool("man_walking", true);

        yield return new WaitForSeconds(5);

        m_Animator.SetBool("man_walking", false);
    }
}