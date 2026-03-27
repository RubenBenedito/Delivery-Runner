using System.Collections;
using UnityEngine;

public class SegmentGenerator : MonoBehaviour
{
    public GameObject[] segment;
    [SerializeField] int zPosition = 91;
    [SerializeField] bool createSegment = false;

    void Update()
    {
        if (createSegment) return;

        createSegment = true;
        StartCoroutine(SegmentGen());
    }

    IEnumerator SegmentGen()
    {
        int segmentNum = Random.Range(0, segment.Length);

        Instantiate(segment[segmentNum], new Vector3(0, 0, zPosition), Quaternion.identity);

        zPosition += 91;

        yield return new WaitForSeconds(8);

        createSegment = false;
    }
}