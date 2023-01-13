using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollIniative_Prefab : MonoBehaviour
{

    [SerializeField] Transform _parentSection;
    [SerializeField] GameObject _playerSlot;
    [SerializeField] GameObject _npcSlot;

    private void Start()
    {
        // GameObject playerObject = Instantiate(REF.MainMenuDM_Prefab, _parentSection.position, Quaternion.identity);
        // playerObject.transform.SetParent(_parentSection);
    }

    public void AddNewNPC() => AddObject(_npcSlot);

    public void AddFromManual()
    {
        Debug.LogError("From Manual");
    }

    public void AddPlayer()
    {
        AddObject(_playerSlot);
        Debug.Log("I add Player");
    }    



    private void AddObject(GameObject slot)
    {
        GameObject playerObject = Instantiate(slot, _parentSection.position, Quaternion.identity);
        playerObject.transform.SetParent(_parentSection);
    }

}
