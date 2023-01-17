using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using static HelperJSON;

public class NpcSlot : BaseSlot
{
    [SerializeField] InputField _npcAC;
    [SerializeField] InputField _npcHP;
    public List<Button> buttonsNPC;
    private List<HelperJSONDataCreature> helperJSONData => instanceHelperJSON.helperJSONDatas;

    

    public void OnChangeInputFieldByName()
    {
        GameManager.instanceGameManager.ClearChild();

        string name = _nameInput.text;

        if (name.Length >= 3)
        {
            string nameCreature;
            for (int i = 0; i < helperJSONData.Count; i++)
            {
                nameCreature = helperJSONData[i].name;
                if (nameCreature.ToLower().Contains(name.ToLower()))
                {
                    GameManager.instanceGameManager.ChangeStateObjectScrollListRoll(true);
                    GameObject futureButton = GameManager.instanceGameManager.InstantiateSlotCreatureInfoRollInitiative(nameCreature);
                    buttonsNPC.Add(futureButton.GetComponent<Button>());
                    ButtonsOnClickFunction(futureButton.GetComponent<Button>());
                }
            }
        }
    }



    private void ButtonsOnClickFunction(Button button)
    {
        string nameCreature = button.gameObject.transform.GetChild(0).GetComponent<Text>().text;
        button.onClick.AddListener(TaskOnClick);
        
        void TaskOnClick()
        {
            foreach(var npc in helperJSONData)
            {
                if (npc.name == nameCreature)
                {
                    _nameInput.text = npc.name;
                    _npcAC.text = npc.ArmorClass.Split(' ')[0];
                    _npcHP.text = npc.HitPoints.Split(' ')[0];
                    //Debug.Log("name = " + npc.name + ", ac = " + npc.ArmorClass + ", hp = " + npc.HitPoints);
                    GameManager.instanceGameManager.ClearChild();
                }
            }
        }
    }

}


