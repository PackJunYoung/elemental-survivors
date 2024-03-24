using UnityEngine;

public class MapManager : MonoBehaviour
{
    public float mapMinX;
    public float mapMaxX;
    public float mapMinY;
    public float mapMaxY;

    public static MapManager instance;

    public void Init()
    {
        instance = this;
    }

    public Vector3 GetPositionInsideMap(Vector3 position)
    {
        position.x = Mathf.Clamp(position.x, mapMinX, mapMaxX);
        position.y = Mathf.Clamp(position.y, mapMinY, mapMaxY);
        return position;
    }

    public Vector3 GetRandomPositionInsideMap()
    {
        var randomX = Random.Range(mapMinX, mapMaxX);
        var randomY = Random.Range(mapMinY, mapMaxY);
        return new Vector3(randomX, randomY, 0f);
    }
}
