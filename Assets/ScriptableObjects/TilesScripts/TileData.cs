using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

using Sirenix.OdinInspector;

using GameManagement;

[CreateAssetMenu]
public class TileData : ScriptableObject
{
    public TileBase[] tiles;

    [SerializeField]
    public string DebugMessage;

    [SerializeField]
    public  List<AudioClip> FootSoundList;

    [SerializeField]
    public List<AudioClip> LandSoundList;

    [SerializeField]
    public SurfaceManager.Surfaces Surface;

    
}
