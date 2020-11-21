using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MenuButtonController : MonoBehaviour
{
    public Animator menuAnimator;
    public Animator searchBarAnimator;
    public Animator otherButton;
    public Button howToUseButton;

    private void Start() => GetComponent<Button>().onClick.AddListener(OnClick);

    private void OnClick()
    {
        otherButton.SetBool("Visibility", !otherButton.GetBool("Visibility"));
        otherButton.GetComponent<Button>().enabled = otherButton.GetBool("Visibility");
        otherButton.GetComponent<Image>().enabled = otherButton.GetBool("Visibility");

        searchBarAnimator.SetBool("Open", !otherButton.GetBool("Visibility"));

        howToUseButton.interactable = otherButton.GetBool("Visibility");

        GetComponent<Animator>().SetBool("Pressed", !GetComponent<Animator>().GetBool("Pressed"));
        menuAnimator.SetBool("Open", !menuAnimator.GetBool("Open"));
    }
}