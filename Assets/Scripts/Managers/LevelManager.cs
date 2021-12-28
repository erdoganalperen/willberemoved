using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : GenericSingleton<LevelManager>
{
    [Header("Road")]
    [SerializeField] private GameObject roadPrefab;
    [SerializeField] private int widht;
    [SerializeField] private GameObject finishPrefab;
    [Header("Levels")]
    [SerializeField] private List<Level> levels;
    [SerializeField] private Vector3 levelInstantiatePosition;
    private GameObject _currentLevel;
    private int _currentLevelIndex;
    public Action ONLevelLoaded;
    private void Start()
    {
        CreateLevel(_currentLevelIndex);
    }
    void CreateLevel(int levelIndex)
    {
        if (_currentLevel!=null)
        {
            foreach (Transform item in transform)
            {
                Destroy(item.gameObject);
            }
        }   
        var level = levels[levelIndex];
        _currentLevel = Instantiate(roadPrefab, levelInstantiatePosition, Quaternion.identity, transform);
        var roadController = _currentLevel.GetComponent<RoadController>();
        roadController.SetLength(level.roadLength);
        var instantiatedFinishPrefab = Instantiate(finishPrefab, new Vector3(0, 0, level.roadLength),Quaternion.identity,transform);
        ONLevelLoaded?.Invoke();
    }
    public void NextLevel()
    {
        _currentLevelIndex++;
        if (_currentLevelIndex < levels.Count)
        {
            CreateLevel(_currentLevelIndex);
            GameManager.Instance.ChangeState(GameState.Playing);
        }
        else
        {
            print("this was the last level");
        }
    }
}
