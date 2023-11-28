using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private string cameraChangeTileTag = "CameraChangeTile";

    private bool _cameraChanged = false;

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPosition = transform.position;
        Vector3Int playerCellPosition = tilemap.WorldToCell(playerPosition);
        Vector3 playerTileCenter = tilemap.GetCellCenterWorld(playerCellPosition);

        TileBase currentTileBase = tilemap.GetTile(playerCellPosition);
       

        // �÷��̾ ��ġ�� Ÿ�Ͽ� �±װ� �����Ǿ� �ְ�, ī�޶� ��ȯ�� ���� �������� �ʾҴٸ�
        if (currentTileBase != null && currentTileBase is Tile && !_cameraChanged)
        {
            Tile currentTile = (Tile)currentTileBase;
            Debug.Log("�̵�!");
            // Ư�� Ÿ�Ͽ� �����ϸ� ���⿡�� ī�޶� ��ȯ ������ ����
            _cameraChanged = true;
                 // �÷��̾ Ű �Է� ���� �̵��ϴ� ����
            
        }

    }

}
