
using UnityEngine;

public struct CellMemory 
{

    public enum Type
    {
        Invalid,
        Empty,
        Object
    }

    public Type type;
    public bool reveal;
    public Vector3Int position;
    public string name;

}
