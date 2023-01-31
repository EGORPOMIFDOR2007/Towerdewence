using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System; 


public class TowerBuildMenu : MonoBehaviour
{
    [SerializeField] private Button[] _buildsButton;
    [SerializeField] private Button _sellButton;
    [SerializeField] private Button _upgreadButton;
    public event Action<TowerType> OnClickBuildButton;
    public event Action OnClickUpgreadButton;
    public event Action OnClickSellButton;

    void Start()
    {
        for (int i = 0; i < _buildsButton.Length; i++)
        {
            var towertype = (TowerType)i;
            _buildsButton[i].onClick.AddListener(() => OnClickBuildButton?.Invoke(towertype));
        }
        _sellButton.onClick.AddListener(() => OnClickSellButton?.Invoke());
        _upgreadButton.onClick.AddListener(() => OnClickUpgreadButton?.Invoke());
    }

    
    void Update()
    {
        
    }
    public void Show(bool isBuildMenu = true)
    {       

        gameObject.SetActive(true);
        for (int i = 0; i < _buildsButton.Length; i++)
        {
            _buildsButton[i].gameObject.SetActive(isBuildMenu);
        }
        _sellButton.gameObject.SetActive(!isBuildMenu);
        _upgreadButton.gameObject.SetActive(!isBuildMenu);

        OnClickBuildButton = null;
        OnClickUpgreadButton = null;
        OnClickSellButton = null;
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
