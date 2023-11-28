using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutputNameText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText; // output 선언 

    private void Start()
    {
        // GameManager에 담아둔 playerid 전달
        string playerName = GameManager.Instance.playerId;
        // 이를 output 해줌
        playerNameText.text = playerName;
    }

}
