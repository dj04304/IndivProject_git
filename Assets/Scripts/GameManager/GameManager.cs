using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject Player;
    private static GameManager _instance;
    // 받아올 playerId
    private string _playerId;
    // 받아올 userId
    private int _userId = 0;

    /// <summary>
    /// 싱글톤
    /// </summary>
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                // _instance가 null 이면 GameObject에 "GameManager" 라는 오브젝트를 생성
                GameObject gameManagerObject = new GameObject("GameManager");
                // _instance 에 GameManager 컴포넌트 추가
                _instance = gameManagerObject.AddComponent<GameManager>();
                // DontDestroyOnLoad로 GameManagerobject가 씬 변환시 Destroy되지 않게끔 설정
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
            // 인스턴스가 중복되어 생성될 경우 파괴해준다.
            Destroy(gameObject);
        }
    }

    // playerId 프로퍼티
    public string playerId
    {
        get { return _playerId; }
        set { _playerId = value; }
    }

    // userId 프로퍼티
    public int userId
    {
        get { return _userId; }
        set { _userId = value; }
    }

    // id값 받아오기
    public void CharacterSelected(int id)
    {
        _userId = id;
    }
    
}
