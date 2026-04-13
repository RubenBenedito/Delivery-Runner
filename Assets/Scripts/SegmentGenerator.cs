using System.Collections;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segment;
    public Transform player;

    [SerializeField] int zPosition = 91;
    [SerializeField] float segmentLifetime = 30f;
    public float distanceToSpawn = 200f;

    void Update()
    {
        if (player.position.z > zPosition - distanceToSpawn)
        {
            generateSegment();
        }
    }

    void generateSegment()
    {
        int segmentNum = Random.Range(0, segment.Length);


        GameObject newSegment = Instantiate(segment[segmentNum], new Vector3(0, 0, zPosition), Quaternion.identity); // Sem rotacao

        Destroy(newSegment, segmentLifetime);

        zPosition += 91;
    }
}