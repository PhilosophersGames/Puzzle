﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;


[RequireComponent(typeof(Dropdown))]
public class DropDownController : MonoBehaviour
{
    private Dropdown  m_dropdown;

    private Dropdown Dropdown
    {
    get
        {
            if (m_dropdown == null)
            {
                m_dropdown = GetComponent<Dropdown>();
            }
            return m_dropdown;
        }
    }

    public Action<Achievements> onValuechanged;

    private void Start()
    {
        UpdateOptions();
        Dropdown.onValueChanged.AddListener(HandleDropdownValueChanged);
    }

    [ContextMenu("UpdateOptions()")]
    public void UpdateOptions()
    {
           Dropdown.options.Clear();
        var values = Enum.GetValues(typeof(Achievements));
        foreach (Achievements achievement in values)
        {
            Dropdown.options.Add(new Dropdown.OptionData(achievement.ToString()));
        }
        Dropdown.RefreshShownValue();
    }

    private void HandleDropdownValueChanged(int value)
    {
        if (onValuechanged != null)
        {
            onValuechanged((Achievements)value);
        }
    }

}
