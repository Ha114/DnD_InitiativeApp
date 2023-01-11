using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManualSlotPrefab : MonoBehaviour
{
    [SerializeField] Text creatureName;
    public void SetCreatureInfo() => GameManager.instanceGameManager.InstantiateSlotCreatureInfo(creatureName.text);
    
}
