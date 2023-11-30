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
    [SerializeField] private Button enterBtn; //��ư ����
    [SerializeField] private TMP_InputField userName; // ������ �̸� ����
    [SerializeField] private GameObject warningPanel; // ���
    // output�� GameScene���� �ؾ��ϹǷ� ������ ����
    
    /// <summary>
    /// ��ư �̺�Ʈ
    /// </summary>
    private void Awake()
    {
        enterBtn.onClick.AddListener(InputNameBtnEvent);
        warningPanel.SetActive(false);
    }

    // 
    public void InputNameBtnEvent()
    {
        // ������ ���̰� 2 ~ 10
        if(userName.text.Length >= 2 && userName.text.Length <= 10)
        {
            // GameManager�� playerId ����
            GameManager.Instance.playerId = userName.text;
            // scene ��ȯ
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            ActivateWarningPanel();
            Invoke("DeactivateWarningPanel", 3f);
        }
    }

    private void ActivateWarningPanel()
    {
        warningPanel.SetActive(true);
    }

    private void DeactivateWarningPanel()
    {
        warningPanel.SetActive(false);
    }

}
