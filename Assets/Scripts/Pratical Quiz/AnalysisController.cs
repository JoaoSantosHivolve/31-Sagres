using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnalysisController : MonoBehaviour
{
    public GameObject fridgeIconPosition;
    public GameObject showcaseIconPosition;

    public GameObject fridgeIcon;
    public GameObject showcaseIcon;

    public Animator coffeeHouseAnimator;
    public bool houseHidden;

    // Update is called once per frame
    void Update()
    {
        if(fridgeIconPosition.activeSelf)
        {
            fridgeIcon.SetActive(true);
            fridgeIcon.transform.position = Camera.main.WorldToScreenPoint(fridgeIconPosition.transform.position);
        }
        else
        {
            fridgeIcon.SetActive(false);
        }

        if (showcaseIconPosition.activeSelf)
        {
            showcaseIcon.SetActive(true);
            showcaseIcon.transform.position = Camera.main.WorldToScreenPoint(showcaseIconPosition.transform.position);
        }
        else
        {
            showcaseIcon.SetActive(false);
        }
    }

    public void HouseReaction(int obj)
    {
        houseHidden = !houseHidden;

        coffeeHouseAnimator.SetBool("base_structure_disapear", houseHidden);
        coffeeHouseAnimator.SetBool("b_characters_hide", houseHidden);

        if (obj == 0)
        {
            coffeeHouseAnimator.SetBool("b_showcase_hide", houseHidden);
            coffeeHouseAnimator.SetBool("b_fridge_zoom", houseHidden);
            showcaseIcon.transform.GetChild(0).GetComponent<Button>().interactable = !houseHidden;
        }
        if (obj == 1)
        {
            coffeeHouseAnimator.SetBool("b_fridge_hide", houseHidden);
            coffeeHouseAnimator.SetBool("b_showcase_zoom", houseHidden);
            fridgeIcon.transform.GetChild(0).GetComponent<Button>().interactable = !houseHidden;
        }
    }
}