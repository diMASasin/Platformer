using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    [SerializeField] private GameObject _coinPrefab;
    [SerializeField] private GameObject[] _spawnPoints = new GameObject[4];

    private void Start()
    {
        foreach (var coin in _spawnPoints)
        {
            Instantiate(_coinPrefab, coin.transform);
        }
    }
}
