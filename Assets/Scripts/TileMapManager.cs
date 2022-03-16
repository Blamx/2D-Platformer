using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

using Sirenix.OdinInspector;

using GameManagement;

public class TileMapManager : MonoBehaviour
{

    [SerializeField]
    Tilemap map;

    [SerializeField]
    List<TileData> tileDatas;

    Dictionary<TileBase, TileData> dataFromTiles;

    private void Awake()
    {
        dataFromTiles = new Dictionary<TileBase, TileData>();

        foreach (var tiledata in tileDatas)
        {
            foreach (var tile in tiledata.tiles)
            {
                dataFromTiles.Add(tile, tiledata);
            }

            GlobalAudioManager.AddToAudioLibrary($"{tiledata.Surface.ToString()}_Foot", tiledata.FootSoundList);
            GlobalAudioManager.AddToAudioLibrary($"{tiledata.Surface.ToString()}_Land", tiledata.FootSoundList);
        }

    }

    public SurfaceManager.Surfaces GetTileSoundInfo(Vector3 pos)
    {
        TileBase tile = map.GetTile(map.WorldToCell(pos));

        string message = "Failed";

        TileData tileData = null;

        dataFromTiles.TryGetValue(tile, out tileData);

        if (tileData != null)
            message = tileData.DebugMessage;
        print($"{message}");

        if (tileData == null)
            return SurfaceManager.Surfaces.None;

        return tileData.Surface;
    }

}
