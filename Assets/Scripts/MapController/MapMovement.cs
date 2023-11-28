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
       

        // 플레이어가 위치한 타일에 태그가 지정되어 있고, 카메라 전환을 아직 수행하지 않았다면
        if (currentTileBase != null && currentTileBase is Tile && !_cameraChanged)
        {
            Tile currentTile = (Tile)currentTileBase;
            Debug.Log("이동!");
            // 특정 타일에 도달하면 여기에서 카메라 전환 로직을 수행
            _cameraChanged = true;
                 // 플레이어가 키 입력 없이 이동하는 로직
            
        }

    }

}
