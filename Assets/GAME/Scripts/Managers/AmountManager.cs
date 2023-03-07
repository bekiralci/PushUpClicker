using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmountManager : MonoBehaviour
{

    #region Enable/Disable/Event
    AmountManager GetAmountManager()
    {
        return this;
    }

    private void OnEnable()
    {
        EventManager.E_AmountManager += GetAmountManager;
    }

    private void OnDisable()
    {
        EventManager.E_AmountManager -= GetAmountManager;
    }

    #endregion

    public float _amount;
    [SerializeField] TextMeshProUGUI amountText;

    private void Start()
    {
        UpdateText();
    }

    public void IncreaseAmount(float value)
    {
        _amount += value;
        UpdateText();
    }

    protected void DecreaseAmount(float value)
    {
        _amount -= value;
    }

    private void UpdateText()
    {
        amountText.text = ReturnAmount((int)_amount).ToString();
    }

    string ReturnAmount(int _value)
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

    public void SetAmount(float value)
    {
        if (AmountCheck(value))
        {
            DecreaseAmount(value);
            UpdateText();
        }
    }

    public bool AmountCheck(float value)
    {

        if (_amount >= value)
        {

            return true;

        }

        return false;

    }

}
