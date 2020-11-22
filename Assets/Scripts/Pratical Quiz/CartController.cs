using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Beer
{
    private const int MaxPerBeer = 20;
    public string name;
    public float price;
    private int m_Quantity;
    public int quantity
    {
        get => m_Quantity;
        set
        {

            if (value <= 0)
                m_Quantity = 0;
            else if (value >= MaxPerBeer)
                m_Quantity = MaxPerBeer;
            else m_Quantity = value;
        }
    }
    public Sprite logo;

    public Image uiLogo;
    public TextMeshProUGUI uiCount;
    public TextMeshProUGUI uiPrice;
    public TextMeshProUGUI uiPriceTotal;
    public TextMeshProUGUI uiName;

    public void UpdatePanel_Count()
    {
        uiCount.text = quantity.ToString();
    }
    public void UpdatePanel_Price()
    {
        uiPrice.text = price.ToString() + "€";
    }
    public void UpdatePanel_PriceTotal()
    {
        uiPriceTotal.text = (price * quantity) + "€";
    }
    public void UpdatePanel_Name()
    {
        uiName.text = name;
    }
    public void UpdatePanel_Logo()
    {
        uiLogo.sprite = logo;  
    }
}

public class CartController : MonoBehaviour
{
    public GameObject prefab;
    public Transform content;
    public TextMeshProUGUI tabText;
    public TextMeshProUGUI totalPriceText;
    public TextMeshProUGUI totalPriceDiscountedText;
    public List<Beer> cart;

    private void Start()
    {
        foreach (var item in cart)
        {
            item.UpdatePanel_Count();
            item.UpdatePanel_Name();
            item.UpdatePanel_Logo();
            item.UpdatePanel_Price();
        }
    }

    private void UpdateTabText()
    {
        int count = 0;
        float price = 0;

        foreach (var item in cart)
        {
            count += item.quantity;

            for (int i = 0; i < item.quantity; i++)
            {
                price += item.price;
            }
        }

        tabText.text = "CART(" + count.ToString() + ") " + price.ToString() + "€";
    }
    public void AddBeer(int index)
    {
        cart[index].quantity++;
        cart[index].UpdatePanel_Count();
        cart[index].UpdatePanel_PriceTotal();

        UpdateTabText();
    }
    public void RemoveBeer(int index) 
    {
        cart[index].quantity--;
        cart[index].UpdatePanel_Count();
        cart[index].UpdatePanel_PriceTotal();

        UpdateTabText();
    }
}