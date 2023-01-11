using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DnDInitiativeMenu : MonoBehaviour
{
    [SerializeField] Transform _parentSectionScenes;



    private void Start()
    {
       // GameObject playerObject = Instantiate(REF.MainMenuDM_Prefab, _parentSection.position, Quaternion.identity);
       // playerObject.transform.SetParent(_parentSection);
    }

    //to prefab roll to initiative
    /*  [SerializeField] Transform _parentSection;
      [SerializeField] GameObject _playerSlot;
      [SerializeField] GameObject _npcSlot;
      TouchScreenKeyboard keyboard;
      /*   public void InstantiateWordSlot(string name)
      {
          GameObject GO = Instantiate(WordSlotPrefab, AlphabetTransform);
          WordSlot wordSlot = GO.GetComponent<WordSlot>();
          wordSlot.textWord.text = name;
      }

      public void AddPlayer()
      {
          AddObject(_playerSlot);
          Debug.Log("I add Player");
      }
      public void AddNPC()
      {
          AddObject(_npcSlot);
          Debug.Log("I add NPC");
      }

      public void OpenKey()
      {
          keyboard = TouchScreenKeyboard.Open("text to edit");

      }

      private void AddObject(GameObject slot)
      {
          GameObject playerObject = Instantiate(slot, _parentSection.position, Quaternion.identity);
          playerObject.transform.SetParent(_parentSection);
      }*/

}
