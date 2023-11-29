using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelecteCharacters : MonoBehaviour
{
    [SerializeField] private GameObject chImg1;
    [SerializeField] private GameObject chImg2;
    [SerializeField] private Button characterBtn; //��ư ����

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
    /// userId�� GameManager���� ����
    /// </summary>
    private void Oncharcter()
    {
        GameManager.Instance.userId = playerId;
    }

    /// <summary>
    /// ĳ���� Sprite�� playerId���� true flase�� ���� ĳ���͸� ���� �״� ��
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
