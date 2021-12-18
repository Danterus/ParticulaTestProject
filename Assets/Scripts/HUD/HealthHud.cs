using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthHud : MonoBehaviour
{
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private HealthController _targetController;

    private void OnEnable()
    {
        _targetController.OnHealthChange += ChangeVal;
    }

    private void OnDisable()
    {
        _targetController.OnHealthChange -= ChangeVal;
    }

    private void ChangeVal()
    {
        _valueText.text = _targetController.GetCurrentHealth() + "/" + _targetController.GetMaximumHealth();
    }
}
