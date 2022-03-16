using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "newRoom", menuName = "Create new room")]
public class RoomData : ScriptableObject
{
    public new string name;
    public int difficulty;
    public Tilemap room;

    public static RoomData CreateInstance(string name, int difficulty, Tilemap tilemap)
    {
        var data = ScriptableObject.CreateInstance<RoomData>();
        data.difficulty = difficulty;
        data.name = name;
        data.room = tilemap;
        return data;
    }
}
