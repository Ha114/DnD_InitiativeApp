using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class InfoNPC : MonoBehaviour
{
    public class Monster
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

    public void LoadJson()
    {
        Debug.Log("Starting...");
        using (StreamReader r = new StreamReader("srd_5e_monsters.json"))
        {
            string json = r.ReadToEnd();
            List<Monster> monsters = JsonConvert.DeserializeObject<List<Monster>>(json);
            Debug.Log("Name monster: " + monsters[1].name);
            Debug.Log("AC monster: " + monsters[1].ArmorClass);
            if (monsters[1].LegendaryActions != null)
            {
                Debug.Log("LegendaryActions monster: " + monsters[1].LegendaryActions);
            }
        }
        Debug.Log("End");
    }


    // Start is called before the first frame update
    void Start()
    {
        LoadJson();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
