using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu (fileName = nameof (TowerSettings), menuName = "Settings/TowerSetting")]
public class TowerSettings : ScriptableObject
{
    [SerializeField] private List<Tower> _prefabs;

    public Tower GetTower(TowerType type, GradeType gradeType)
    {
        var tower = _prefabs.Find(x => x.Type == type & x.GradeType == gradeType);

        if (tower == null)
        {
            throw new Exception($"not find Tower with type-{type}");
        }
        return tower;
    }
}
