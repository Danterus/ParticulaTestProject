using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ArmorHud : MonoBehaviour
{
    [SerializeField] private TMP_Text _valueText;
    [SerializeField] private ArmorController _targetController;
    
    private void OnEnable()
    {
        if (_targetController != null)
        {
            _targetController.OnArmorChange += ChangeVal;
        }
        
    }

    private void OnDisable()
    {
        if (_targetController != null)
        {
            _targetController.OnArmorChange -= ChangeVal;
        }
        
    }

    private void ChangeVal()
    {
        if (_targetController != null && _targetController.GetCurrentArmor() > 0)
        {
            _valueText.text = "Armor: " + _targetController.GetCurrentArmor();
        }
        else
        {
            _valueText.text = " ";
        }
    }
}
