using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutputNameText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText; // output ���� 

    private void Start()
    {
        // GameManager�� ��Ƶ� playerid ����
        string playerName = GameManager.Instance.playerId;
        // �̸� output ����
        playerNameText.text = playerName;
    }

}
