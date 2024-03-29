﻿using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace GiftOrCoal.Difficult
{
    public sealed class DifficultDropdown : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdown;
        
        private DifficultData[] _difficultData;
        private readonly List<UnityAction<int>> _actions = new();

        public void Init(DifficultData[] difficultData, int startValue)
        {
            _difficultData = difficultData ?? throw new ArgumentNullException(nameof(difficultData));
            _dropdown.AddOptions(CreateOptions());
            _dropdown.value = startValue;
        }

        private List<TMP_Dropdown.OptionData> CreateOptions()
        {
            return _difficultData.Select(difficultData => new TMP_Dropdown.OptionData(difficultData.Name)).ToList();
        }

        public void Subscribe(UnityAction<int> action)
        {
            if (action == null)
                throw new ArgumentNullException(nameof(action));
            
            _dropdown.onValueChanged.AddListener(action);
            _actions.Add(action);
        }

        private void OnDestroy()
        {
            foreach (var action in _actions)
            {
                _dropdown.onValueChanged.RemoveListener(action);
            }
        }
    }
}