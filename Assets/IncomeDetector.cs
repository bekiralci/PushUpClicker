using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncomeDetector : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out StickmanDetector stickmanDetector))
        {
            EventManager.E_AmountManager.Invoke().IncreaseAmount(stickmanDetector._income * EventManager.E_UIItemIncome.Invoke().incomeFactor);
        }
    }
}
