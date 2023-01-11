using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class HelperJSON : MonoBehaviour
{
    #region singleton
    public static HelperJSON instanceHelperJSON;
    private void Awake()
    {
        if (instanceHelperJSON == null)
        {
            LoadJson();
            instanceHelperJSON = this;
        }
    }
    #endregion
    public class HelperJSONDataCreature
    {
        //basic info
        public string name;
        public string meta;
        [JsonProperty(PropertyName = "Armor Class")]
        public string ArmorClass;
        [JsonProperty(PropertyName = "Hit Points")]
        public string HitPoints;
        public string Speed;

        /*creature statistics:
         STR - strength, DEX - dexterity, CON - constitution, INT - intelligence, WIS - wisdom, CHA - charisma, mod - modifier*/
        public string STR;
        public string STR_mod;
        public string DEX;
        public string DEX_mod;
        public string CON;
        public string CON_mod;
        public string INT;
        public string INT_mod;
        public string WIS;
        public string WIS_mod;
        public string CHA;
        public string CHA_mod;

        //additional info
        [JsonProperty(PropertyName = "Saving Throws")]
        public string SavingThrows;
        public string Skills;
        public string Senses;
        public string Languages;
        public string Challenge;
        public string Traits;

        //Immunities
        [JsonProperty(PropertyName = "Damage Resistances")]
        public string DamageResistances;
        [JsonProperty(PropertyName = "Damage Immunities")]
        public string DamageImmunities;
        [JsonProperty(PropertyName = "Condition Immunities")]
        public string ConditionImmunities;

        //Actions
        public string Actions;
        [JsonProperty(PropertyName = "Legendary Actions")]
        public string LegendaryActions;
        //image if internet connection == true
        public string img_url;
    }
    public List<HelperJSONDataCreature> helperJSONDatas;

    List<HelperJSONDataCreature> npcList;

    public void LoadJson()
    {
        using (StreamReader r = new StreamReader("srd_5e_monsters.json"))
        {
            string json = r.ReadToEnd();
            npcList = JsonConvert.DeserializeObject<List<HelperJSONDataCreature>>(json);
            helperJSONDatas = npcList;
        }
    }

    public List<string> GetAllParametresNamesOfClass()
    {
        return typeof(HelperJSONDataCreature).GetFields()
                            .Select(field => field.Name)
                            .ToList();    
    }
    public List<object> GetAllParametresValuesOfClass(HelperJSONDataCreature creature)
    {
        return creature.GetType()
                       .GetFields()
                       .Select(field => field.GetValue(creature))
                       .ToList();
    }
}
