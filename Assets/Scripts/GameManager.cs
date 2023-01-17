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

    [Header("   Manual_Prfab")]
    [SerializeField] Transform _parentCreatureInfo;
    [SerializeField] GameObject _slotCreaturePrefab;

    [Header("   RollInitiative_Prefab")]
    [SerializeField] Transform _parentRollInitiative;
    [SerializeField] GameObject _slotRollInitiative;
    [SerializeField] GameObject _scrollListFindCreatureRollInitiative;
    [SerializeField] Transform _parentFindCreatureRollInitiative;

    public void InstantiateSlotCreatureInfo(string name)
    {
        InstantiateSlot(_slotCreaturePrefab, _parentCreatureInfo);   
        CreatureInfo.instanceCreatureInfo.SetCreatureInfo(name);
    }

    public GameObject InstantiateSlotCreatureInfoRollInitiative(string name)
    {
        GameObject newSlot = InstantiateSlot(_slotRollInitiative, _parentFindCreatureRollInitiative);
        Text txt = newSlot.transform.GetChild(0).GetComponent<Text>();
        txt.text = name;
        return newSlot;
    }

    public void ClearChild()
    {
        foreach (Transform child in _parentFindCreatureRollInitiative)
        {
            Destroy(child.gameObject);
            ChangeStateObjectScrollListRoll(false);
        }
    }

    public void ChangeStateObjectScrollListRoll(bool state) => _scrollListFindCreatureRollInitiative.SetActive(state);

    private GameObject InstantiateSlot(GameObject Slot, Transform Parent)
    {
        GameObject newSlot = Instantiate(Slot, Parent.position, Quaternion.identity);
        newSlot.transform.SetParent(Parent);
        return newSlot;
    }

}
