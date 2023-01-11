using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static HelperJSON;

public class CreatureInfo : BasicMenu
{
    #region singleton
    public static CreatureInfo instanceCreatureInfo;
    private void Awake()
    {
        if (instanceCreatureInfo == null)
        {
            instanceCreatureInfo = this;
        }
    }
    #endregion

    [Header("   Creature Info")]
    [SerializeField] Text textCreatureInfo;
    [SerializeField] Text textCreatureDescription;

    private List<HelperJSONDataCreature> helperJSONData => instanceHelperJSON.helperJSONDatas;

    public void SetCreatureInfo(string name)
    {
        textCreatureDescription.text = "";
        textCreatureInfo.text = name;
        for (int i = 0; i < helperJSONData.Count; i++)
        {
            if (helperJSONData[i].name == name)
            {
                List<string> parametres = instanceHelperJSON.GetAllParametresNamesOfClass();
                List<object> values = instanceHelperJSON.GetAllParametresValuesOfClass(helperJSONData[i]);

                for (int j = 1; j < parametres.Count - 1; j++)
                    textCreatureDescription.text += "\n" + j + ". " + parametres[j] + ": " + values[j];

            }
        }
    }

    public void ChosenOneButton()
    {
        Debug.Log("This creature set chosen");
    }
}
