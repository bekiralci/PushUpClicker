using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class ButtonBase : MonoBehaviour
{
    [Header("Values")]
    [SerializeField] public int upgradeCost;
    [SerializeField] private int startCost;
    [SerializeField] private int upgradeLevel;
    [SerializeField] private float factor;

    [Header("Buttons/Sprites")]
    public GameObject main_Button;
    public GameObject passive_Button;

    [Header("Texts")]
    public TextMeshProUGUI UpgradeCostTEXT;

    private void Start()
    {
        UpdateCost();
        UpdateText();
    }

    protected void UpdateText()
    {
        UpgradeCostTEXT.text = ReturnAmount(upgradeCost);
    }

    public void UpdateCost()
    {

        UpdateAmount(upgradeCost);

        upgradeCost = (int)(Mathf.Pow(upgradeLevel, factor)) * startCost;

        upgradeLevel++;

    }

    protected void UpdateAmount(int value)
    {
        EventManager.E_AmountManager.Invoke().SetAmount(value);
    }

    protected bool CheckAmount()
    {
        if (EventManager.E_AmountManager.Invoke().AmountCheck(upgradeCost))
        {
            return true;
        }
        return false;
    }

    public abstract void OnClickButton();

    private string ReturnAmount(int _value)
    {

        if (_value >= 100000000)
        {
            return (_value / 1000000D).ToString("0.#M");
        }
        if (_value >= 1000000)
        {
            return (_value / 1000000D).ToString("0.##M");
        }
        if (_value >= 100000)
        {
            return (_value / 1000D).ToString("0.#k");
        }
        if (_value >= 1000)
        {
            return (Mathf.FloorToInt((_value / 10)) / 100f).ToString("0.##k");
        }
        if (_value == 0)
        {
            return "0";
        }

        return _value.ToString("#");

    }

}
