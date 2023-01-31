using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TowerBuildMenu _menuBuild;

    public TowerBuildMenu MenuBuild => _menuBuild;
    void Start()
    {
        MenuBuild.Hide();
    }
}
