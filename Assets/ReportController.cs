using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReportController : MonoBehaviour
{
    public bool reportFakeDrinks;
    public bool reportDamagedAdvertising;

    public bool storeFakeDrinks;
    public bool storeDamagedAdvertising;

    public DamageObjectBehaviour fridge;
    public DamageObjectBehaviour fridgeBeerBottles;
    public DamageObjectBehaviour showcase;
    public DamageObjectBehaviour showcaseBeerBottles;
    public DamageObjectBehaviour advertising;

    public GameObject uiFailedReport;
    public GameObject uiSucessfullReport;

    private void Start()
    {
        var damageState = Common.GoodsState.Damaged;
        storeFakeDrinks = fridge.state == damageState || showcase.state == damageState || fridgeBeerBottles.state == damageState || showcaseBeerBottles.state == damageState  ? true : false;
        storeDamagedAdvertising = advertising.state == Common.GoodsState.Damaged;
    }

    public void UpdateFakeDrinksValue(Toggle toggle) => reportFakeDrinks = toggle.isOn;
    public void UpdateDamagedAdvertisingValue(Toggle toggle) => reportDamagedAdvertising = toggle.isOn;

    public void VerifyReport()
    {
        if(reportFakeDrinks == storeFakeDrinks && reportDamagedAdvertising == storeDamagedAdvertising)
        {
            uiSucessfullReport.SetActive(true);
        }
        else
        {
            uiFailedReport.SetActive(true);
        }
    }

}