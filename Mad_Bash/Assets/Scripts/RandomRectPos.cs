using UnityEngine;

public static class RandomRectPos
{
    public static Vector3 RandomOnRect(float areaX, float areaY)
    {
        float newX = Random.Range(-(areaX * 0.5f), (areaX * 0.5f));
        float newY = Random.Range(-(areaY * 0.5f), (areaY * 0.5f));        

        var vec3 = new Vector3(newX, newY);

        return vec3;
    }

    public static Vector3 RandomOnRect(float areaX, float areaY, float areaZ)
    {
        float newX = Random.Range(-(areaX * 0.5f), (areaX * 0.5f));
        float newY = Random.Range(-(areaY * 0.5f), (areaY * 0.5f));
        float newZ = Random.Range(-(areaZ * 0.5f), (areaZ * 0.5f));

        var vec3 = new Vector3(newX, newY, newZ);

        return vec3;
    }
}