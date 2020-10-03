using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoints : MonoBehaviour
{

    [SerializeField]
    private Transform[] _points = null;


    public Transform GetWayPoint(int index) => _points[index];

    public int GetPointsCount() => _points.Length;

}
