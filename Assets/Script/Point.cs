using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum PointDirection
{
    Up,
    Down,
    Lift,
    Right
}
public class Point : MonoBehaviour
{
   [SerializeField] private PointDirection _direction;

    public PointDirection Direction => _direction;
}  