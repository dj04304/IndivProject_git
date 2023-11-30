using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputNameChangeText : MonoBehaviour
{
    [SerializeField] private Button enterBtn; //��ư ����
    [SerializeField] private TMP_InputField userName; // ������ �̸� ����
    [SerializeField] private GameObject warningPanel; // ���
    [SerializeField] private GameObject chagedPanel;
                                                      

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
        if (userName.text.Length >= 2 && userName.text.Length <= 10)
        {
            // GameManager�� playerId ����
            GameManager.Instance.playerId = userName.text;
            SceneManager.LoadScene("GameScene");
            DeactiveChagedPanel();
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

    private void DeactiveChagedPanel()
    {
        chagedPanel.SetActive(false);
    }

}
