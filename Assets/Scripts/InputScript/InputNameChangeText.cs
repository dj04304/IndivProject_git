using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputNameChangeText : MonoBehaviour
{
    [SerializeField] private Button enterBtn; //버튼 선언
    [SerializeField] private TMP_InputField userName; // 유저의 이름 선언
    [SerializeField] private GameObject warningPanel; // 경고문
    [SerializeField] private GameObject chagedPanel;
                                                      

    /// <summary>
    /// 버튼 이벤트
    /// </summary>
    private void Awake()
    {
        enterBtn.onClick.AddListener(InputNameBtnEvent);
        warningPanel.SetActive(false);
    }

    // 
    public void InputNameBtnEvent()
    {
        // 글자의 길이가 2 ~ 10
        if (userName.text.Length >= 2 && userName.text.Length <= 10)
        {
            // GameManager에 playerId 전달
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
