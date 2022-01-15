using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;

    public Vector3 EndPosition => _endPoint.position;
}
