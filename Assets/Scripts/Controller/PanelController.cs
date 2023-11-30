using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] Button button;


    private void Start()
    {
        button.onClick.AddListener(TogglePanel);
    }

    private void TogglePanel()
    {
        panel.SetActive(!panel.activeSelf);
    }
}
