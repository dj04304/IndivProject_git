using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecteCharacters : MonoBehaviour
{
    [SerializeField] private GameObject chImg1;
    [SerializeField] private GameObject chImg2;
    [SerializeField] private Button characterBtn; //버튼 선언

    [SerializeField] private int playerId = 0;

    private void Awake()
    {
        characterBtn.onClick.AddListener(Oncharcter);
        chImg1.SetActive(true);
    }

    private void OnEnable()
    {
        characterBtn.onClick.AddListener(SetCharacterImg);
    }
    /// <summary>
    /// userId를 GameManager에게 전달
    /// </summary>
    private void Oncharcter()
    {
        GameManager.Instance.userId = playerId;
    }

    /// <summary>
    /// 캐릭터 Sprite를 playerId에서 true flase로 누른 캐릭터를 껐다 켰다 함
    /// </summary>
    private void SetCharacterImg()
    {
        if(playerId == 0)
        {
            chImg1.SetActive(true);
            chImg2.SetActive(false);
        }
        else if(playerId == 1)
        {
            chImg2.SetActive(true);
            chImg1.SetActive(false);
        }
        else
        {
            Debug.Log("playerId: " + playerId);
        }


    }

}
