using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputNameText : MonoBehaviour
{
    [SerializeField] private Button enterBtn;
    [SerializeField] private TMP_InputField userName;

    private void Awake()
    {
        enterBtn.onClick.AddListener(ButtonTest);
    }

    public void ButtonTest()
    {
        GameManager.Instance.playerId = userName.text;
        SceneManager.LoadScene("GameScene");
    }
}
