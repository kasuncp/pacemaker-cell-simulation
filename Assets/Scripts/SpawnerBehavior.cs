using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour
{
    [SerializeField]
    private Transform cellPrefab = default;

    [SerializeField]
    private int gridSize = 10;

    private void Awake() {
        int offset = gridSize / 2;
        for (int i = 0; i < gridSize; ++i) {
            for (int j = 0; j < gridSize; ++j) {
                Transform cell = Instantiate(cellPrefab);
                cell.localPosition = new Vector3(i - offset, j - offset, 0);
            }
        }
    }
}
