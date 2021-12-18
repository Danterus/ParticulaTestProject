using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AttackTitleUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _title;

    private void Awake()
    {
        BattleController.OnCastleActionMade += UpdateText;
        _title.text = " ";
    }

    private void UpdateText(string user, string actionName, int value)
    {
        _title.text = user + " used " + actionName + " for " + value;
    }
}
