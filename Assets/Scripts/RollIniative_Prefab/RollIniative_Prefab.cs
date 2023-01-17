using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollIniative_Prefab : MonoBehaviour
{

    [SerializeField] Transform _parentSection;
    [SerializeField] GameObject _playerSlot;
    [SerializeField] GameObject _npcSlot;

    public void AddNewNPC() => AddObject(_npcSlot);

    public void AddPlayer()
    {
        AddObject(_playerSlot);
        //Debug.Log("I add Player");
    }

    public void BackToMainMenuButton() => SceneManager.instanceSceneManager.BackToMainMenu(2);


    private void AddObject(GameObject slot)
    {
        GameObject playerObject = Instantiate(slot, _parentSection.position, Quaternion.identity);
        playerObject.transform.SetParent(_parentSection);
    }

}
