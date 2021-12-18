using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    [SerializeField] private ActionButton _actionButtonPrefab;

    [SerializeField] private Transform _actionButtonParent;
    private List<ActionButton> _instantiatedButtons = new List<ActionButton>();
    
    public void SetActions(Dictionary<int, string> actions, Action<int> onClick)
    {
        var counter = 0;
        foreach (var kvp in actions)
        {
            if (_instantiatedButtons.Count > counter)
            {
                _instantiatedButtons[counter].InitButton(kvp.Key, kvp.Value, onClick);
            }
            else
            {
                ActionButton a = Instantiate(_actionButtonPrefab, _actionButtonParent);
                _instantiatedButtons.Add(a);
                a.InitButton(kvp.Key, kvp.Value, onClick);
            }
            counter++;
        }
    }

}
