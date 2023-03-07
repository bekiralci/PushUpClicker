using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIItemIncome : ButtonBase
{

    [SerializeField] private TextMeshProUGUI incomeFactorText;
    public float incomeFactor;

    private void OnEnable()
    {
        incomeFactorText.text = "x" + incomeFactor.ToString("0.#");
        EventManager.E_UIItemIncome += GetThis;
    }

    private void OnDisable()
    {
        EventManager.E_UIItemIncome -= GetThis;
    }

    UIItemIncome GetThis()
    {
        return this;
    }

    private void IncomeFactorUpdate()
    {
        incomeFactor += .1f;
        incomeFactorText.text = "x" + incomeFactor.ToString("0.#");
    }

    public override void OnClickButton()
    {

        IncomeFactorUpdate();

    }

}
