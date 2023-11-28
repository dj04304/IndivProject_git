using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OutputNameText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI playerNameText;

    private void Start()
    {
        string playerName = GameManager.Instance.playerId;
        playerNameText.text = playerName;
    }

}
