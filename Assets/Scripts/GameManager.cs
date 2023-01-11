using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    [SerializeField] Transform _parentCreatureInfo;
    [SerializeField] GameObject _slotCreaturePrefab;



    public void InstantiateSlotCreatureInfo(string name)
    {
        GameObject newSlot = Instantiate(_slotCreaturePrefab, _parentCreatureInfo.position, Quaternion.identity);
        newSlot.transform.SetParent(_parentCreatureInfo);
        CreatureInfo.instanceCreatureInfo.SetCreatureInfo(name);
    }
}
