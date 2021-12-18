using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ActionButton : MonoBehaviour
{
      [SerializeField] private TMP_Text _titleText;
      private Button _buttonComponent;
      private int _index;

      private void Awake()
      {
            _buttonComponent = GetComponent<Button>();
      }

      public void InitButton(int index, string title, Action<int> onClickAction)
      {
            _index = index;
            _titleText.text = title;
            _buttonComponent.onClick.RemoveAllListeners();
            _buttonComponent.onClick.AddListener(delegate { onClickAction(_index); });
      }
}
