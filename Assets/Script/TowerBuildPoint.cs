using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider2D))]
public class TowerBuildPoint : MonoBehaviour
{
    [SerializeField] private GameUI _gameUI;
    [SerializeField] private Transform _point;
    [SerializeField] private TowerSettings _settings;

    
    public Tower Tower { get; private set; }
    private void Reset()
    {
       name = nameof(TowerBuildPoint);
    }
    private void OnMouseDown()
    {
        OpenBuildMenu();
    }
    private void OpenBuildMenu()
    {
        _gameUI.MenuBuild.Show(Tower == null);
        _gameUI.MenuBuild.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        _gameUI.MenuBuild.OnClickBuildButton += BuildTower;
        _gameUI.MenuBuild.OnClickSellButton += SellTower;
        _gameUI.MenuBuild.OnClickUpgreadButton += UpgreadTower;
    }
    private void CloseBuildMenu()
    {
        _gameUI.MenuBuild.OnClickBuildButton -= BuildTower;
        _gameUI.MenuBuild.OnClickSellButton -= SellTower;
        _gameUI.MenuBuild.OnClickUpgreadButton -= UpgreadTower;
        _gameUI.MenuBuild.Hide();
    }
    private void BuildTower (TowerType towertype)
    {
        Debug.Log($"Build button clicked -{towertype}");
        Tower = Instantiate(_settings.GetTower(towertype, GradeType.great_I), transform.position, Quaternion.identity);
        CloseBuildMenu();
    }
    private void SellTower()
    {
        Debug.Log("SellButtonClicked");
        CloseBuildMenu();
    }
    private void UpgreadTower()
    {
        Debug.Log("UpgreatButtonClicked");
        CloseBuildMenu();
    }

}
