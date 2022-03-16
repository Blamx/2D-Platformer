using System.Collections;
using System.Collections.Generic;

using UnityEngine.Tilemaps;
using UnityEngine;

using Sirenix.OdinInspector;

[CreateAssetMenu]
public class TileObjectList : SerializedScriptableObject
{
    [SerializeField]
    public Dictionary<TileBase, GameObject> TileObjects;
}
