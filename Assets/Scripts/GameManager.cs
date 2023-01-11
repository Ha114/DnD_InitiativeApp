using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static HelperJSON;

public class GameManager : MonoBehaviour
{
    #region singleton
    public static GameManager instanceGameManager;
    private void Awake()
    {
        if (instanceGameManager == null)
        {
            instanceGameManager = this;
        }
    }
    #endregion

    [SerializeField] public Transform _parentCanvas;
    [SerializeField] public GameObject _manualPrefab;
    [SerializeField] public GameObject _mainMenuPrefab;

    [SerializeField] public GameObject[] _scenesPrefabs;


    [SerializeField] public Transform _parentSectionManualCreature;
    [SerializeField] public GameObject _slotPrefabManualCreature;

    private void Start()
    {
        Invoke("OpenFirst", 2f);
    }

    void OpenFirst()
    {
        Instantiate(_mainMenuPrefab, _parentCanvas);
    }

    public void SetNewScenePrefab(GameObject newScene, GameObject oldScene)
    {
        Instantiate(newScene, _parentCanvas);
        //oldScene.SetActive(false);
        Destroy(oldScene);
    }

    public void OpenManualPrefab() => SetNewScenePrefab(_manualPrefab, _mainMenuPrefab);

    public void OpenMainMenuPrefab() => SetNewScenePrefab(_mainMenuPrefab, _manualPrefab);




    public void SetCreatureInfoGM(string name)
    {
        GameObject newSlot = Instantiate(_slotPrefabManualCreature, _parentSectionManualCreature.position, Quaternion.identity);
        newSlot.transform.SetParent(_parentSectionManualCreature);
        CreatureInfo.instanceCreatureInfo.SetCreatureInfo(name);
    }
}
