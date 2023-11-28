using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject Player;
    private static GameManager _instance;
    // �޾ƿ� playerId
    private string _playerId;
    // �޾ƿ� userId
    private int _userId = 0;

    /// <summary>
    /// �̱���
    /// </summary>
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // _instance�� null �̸� GameObject�� "GameManager" ��� ������Ʈ�� ����
                GameObject gameManagerObject = new GameObject("GameManager");
                // _instance �� GameManager ������Ʈ �߰�
                _instance = gameManagerObject.AddComponent<GameManager>();
                // DontDestroyOnLoad�� GameManagerobject�� �� ��ȯ�� Destroy���� �ʰԲ� ����
                DontDestroyOnLoad(gameManagerObject);
            }
            return _instance;
        }
    }

    /// <summary>
    /// Double-Check Locking
    /// </summary>
    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this; 
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            // �ν��Ͻ��� �ߺ��Ǿ� ������ ��� �ı����ش�.
            Destroy(gameObject);
        }
    }

    // playerId ������Ƽ
    public string playerId
    {
        get { return _playerId; }
        set { _playerId = value; }
    }

    // userId ������Ƽ
    public int userId
    {
        get { return _userId; }
        set { _userId = value; }
    }

    // id�� �޾ƿ���
    public void CharacterSelected(int id)
    {
        _userId = id;
    }
    
}
