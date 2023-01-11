using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static HelperJSON;

public class Manual_Prefab : MonoBehaviour
{
    [Header("   Manual List")]
    [SerializeField] public Transform _parentSectionManual;
    [SerializeField] public GameObject _slotPrefabManual;
    private List<HelperJSONDataCreature> helperJSONData => instanceHelperJSON.helperJSONDatas;

    // Start is called before the first frame update
    void Start()
    {
        SetCreaturesSlots();
        
    }
    public void SetCreaturesSlots(int idSortType = 0, string word = "")
    {
        for (int i = 0; i < helperJSONData.Count; i++)
        {
            if (idSortType == 0 && helperJSONData[i].name.Contains(word))
            {
                InstantiateSlot(_parentSectionManual, _slotPrefabManual, helperJSONData[i].name);
            }
        }
    }

    public void InstantiateSlot(Transform parent, GameObject slot, string name)
    {
        GameObject newSlot = Instantiate(slot, parent.position, Quaternion.identity);
        newSlot.transform.SetParent(parent);
        Text txt = newSlot.transform.GetChild(0).GetComponent<Text>();
        txt.text = name;
    }

    public virtual void DestroyManualSlots()
    {
        foreach (Transform child in _parentSectionManual)
            Destroy(child.gameObject);
    }
}
