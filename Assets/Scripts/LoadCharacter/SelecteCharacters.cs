using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecteCharacters : MonoBehaviour
{
    [SerializeField] private int playerId;
    [SerializeField] private Button characterBtn; //버튼 선언

    private void Awake()
    {
        characterBtn.onClick.AddListener(Oncharcter);
    }

    public void Oncharcter()
    {
        GameManager.Instance.userId = playerId;
    }

}
