using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CandyFactory : MonoBehaviour {
    const int SphereCandyFrequency = 3;

    public int candySize;
    public int row;
    public int col;
    public float candyDistance;

    public GameObject[] candyPrefabs;
    public GameObject[] candySquarePrefabs;

    // Start is called before the first frame update
    void Start() {
        if (candySize > row * col) candySize = row * col;
        List<Vector3> candidatePositions = new List<Vector3>();
        float halfDist = candyDistance / 2.0f;
        Vector3 cardinalPoint = new Vector3(transform.position.x - halfDist * (col - 1), transform.position.y, transform.position.z + halfDist * (row - 1));
        for (int i = 0; i < row; i++) {
            for (int j = 0; j < col; j++) {
                candidatePositions.Add(new Vector3(cardinalPoint.x + candyDistance * j, cardinalPoint.y, cardinalPoint.z - candyDistance * i));
            }
        }
        for (int i = 0; i < candySize; i++) {
            int selectedNumber = Random.Range(0, candidatePositions.Count);
            GameObject newCandy = Instantiate(SampleCandy(), candidatePositions[selectedNumber], Quaternion.identity);
            newCandy.transform.parent = transform;
            candidatePositions.RemoveAt(selectedNumber);
        }
    }

    private int sampleCandyCount = 0;
    private GameObject SampleCandy() {
        GameObject prefab = null;
        if (sampleCandyCount % SphereCandyFrequency == 0) {
            int index = Random.Range(0, candyPrefabs.Length);
            prefab = candyPrefabs[index];
        } else {
            int index = Random.Range(0, candySquarePrefabs.Length);
            prefab = candySquarePrefabs[index];
        }
        sampleCandyCount++;
        return prefab;
    }

    // Update is called once per frame
    void Update() {

    }
}
