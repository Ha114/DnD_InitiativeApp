using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static HelperJSON;

public class MenuFilteringManual : Manual_Prefab
{
    #region singleton
    public static MenuFilteringManual instanceMenuFilteringManual;
    private void Awake()
    {
        if (instanceMenuFilteringManual == null)
        {
            instanceMenuFilteringManual = this;
        }
    }
    #endregion

    [Header("   Search info")]
    [SerializeField] InputField _input;
    [Header("   Meta Type List")]
    [SerializeField] Transform _parentSectionType;
    [SerializeField] GameObject _slotPrefabType;
    [SerializeField] GameObject _listOfMetaType;
    [SerializeField] InputField _inputOpenMetaType;
    [Header("   Meta Size List")]
    [SerializeField] Transform _parentSectionSize;
    [SerializeField] GameObject _slotPrefabSize;
    [SerializeField] GameObject _listOfMetaSize;
    [SerializeField] InputField _inputOpenMetaSize;
    [Header("   Meta Alignment List")]
    [SerializeField] Transform _parentSectionAlignment;
    [SerializeField] GameObject _slotPrefabAlignment;
    [SerializeField] GameObject _listOfMetaAlignment;
    [SerializeField] InputField _inputOpenMetaAlignment;
    [Header("   Meta Challenge List")]
    [SerializeField] Transform _parentSectionChallenge;
    [SerializeField] GameObject _slotPrefabChallenge;
    [SerializeField] GameObject _listOfMetaChallange;
    [SerializeField] InputField _inputOpenMetaChallange;
    [Header("   Meta Find By Name Creature")]
    [SerializeField] Transform _parentSectionNames;
    [SerializeField] GameObject _slotPrefabNames;
    [SerializeField] GameObject _listOfMetaNames;
    [SerializeField] InputField _inputOpenMetaNames;

    [Header("   Text Accepted Filter")]
    [SerializeField] Text acceptedFilter;
    private List<HelperJSONDataCreature> helperJSONData => instanceHelperJSON.helperJSONDatas;
    private List<string> allTypeManual = new List<string>();
    private List<string> allSizeManual = new List<string>();
    private List<string> allAlignmentManual = new List<string>();
    private List<string> allChallengeManual = new List<string>();
    private Dictionary<int, string> originalChallengeInfoDictionary = new Dictionary<int, string>();

    public class SearchFilterData
    {
        public string name;
        public string metaType;
        public string metaSize;
        public string metaAlignments;
        public string challengeLevel;

        public void SetData(InputField InputName, InputField InputOpenMetaType, InputField InputOpenMetaSize, InputField InputOpenMetaAlignments,
            InputField InputOpenMetaChallenge)
        {
            name = SetDataFromInputField(InputName);
            metaType = SetDataFromInputField(InputOpenMetaType);
            metaSize = SetDataFromInputField(InputOpenMetaSize);
            metaAlignments = SetDataFromInputField(InputOpenMetaAlignments);
            challengeLevel = SetDataFromInputField(InputOpenMetaChallenge);
        }
        private string SetDataFromInputField(InputField InputField) => InputField.gameObject.transform.GetChild(1).GetComponent<Text>().text;
        public bool CheckIfContains(HelperJSONDataCreature helperJSONDatas)
        {
            if (helperJSONDatas.name.Contains(name) && helperJSONDatas.meta.Contains(metaType)
                && helperJSONDatas.meta.Contains(metaType) && helperJSONDatas.meta.Contains(metaSize)
                && helperJSONDatas.meta.Contains(metaAlignments) && helperJSONDatas.meta.Contains(challengeLevel))
                return true;

            return false;
        }

        public string GetAcceptedFilterData() => "Name: " + name + ";\nType: " + metaType + ";\nSize: " +
            metaSize + ";\nAlignments: " + metaAlignments + ";\nChallenge: " + challengeLevel;
        
    }
    SearchFilterData searchFilterData;

    public void ClearFilter()
    {
        ClearInfoText(_inputOpenMetaType); 
        ClearInfoText(_inputOpenMetaSize);
        ClearInfoText(_inputOpenMetaAlignment);
        ClearInfoText(_inputOpenMetaChallange);

        _inputOpenMetaNames.text = "";

        void ClearInfoText(InputField InputField)
        {
            InputField.gameObject.transform.GetChild(1).GetComponent<Text>().text = "";
            InputField.GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f, 0.8f); //grey color
        }
    }
    public void AcceptFiltr()
    {
        searchFilterData = new SearchFilterData();
        DestroyManualSlots();
        searchFilterData.SetData(_input, _inputOpenMetaType, _inputOpenMetaSize, _inputOpenMetaAlignment, _inputOpenMetaChallange);
        int count = 0;

        for (int i = 0; i < helperJSONData.Count; i++)
        {
            if (searchFilterData.CheckIfContains(helperJSONData[i]))
            {
                count++;
                InstantiateSlot(_parentSectionManual, _slotPrefabManual, helperJSONData[i].name);
            }
        }

        acceptedFilter.text = searchFilterData.GetAcceptedFilterData() + ";\nResults: " + count;
    }
    public void SetManualDataByFilter(int idSortType = 0, string word = "")
    {
        for (int i = 0; i < helperJSONData.Count; i++)
        {
            if (idSortType == 0 && helperJSONData[i].name.Contains(word))
                CheckToAcceptFilter(helperJSONData[i].name, _inputOpenMetaNames, new Color(1f, 1f, 1f, 1f), helperJSONData[i].name);

            if (idSortType == 1 && helperJSONData[i].meta.Contains(word))
                CheckToAcceptFilter(word, _inputOpenMetaType, new Color(0.956f, 1f, 0.4274f, 1f));

            if (idSortType == 2 && helperJSONData[i].meta.Contains(word))
                CheckToAcceptFilter(word, _inputOpenMetaSize, new Color(0.9607f, 0.6509f, 0.4117f, 1f));

            if (idSortType == 3 && helperJSONData[i].meta.Contains(word))
                CheckToAcceptFilter(word, _inputOpenMetaAlignment, new Color(0.419f, 0.7941f, 0.8018f, 1f));

            if (idSortType == 4 && helperJSONData[i].Challenge.Contains(word))
            {
                string[] getLevelChallenge = word.Split('(');
                if (word == "") _listOfMetaChallange.SetActive(false);
            }
        }

        if (_listOfMetaType || _listOfMetaSize || _listOfMetaAlignment)
            SetActiveFalseAllList();

        void SetActiveFalseAllList()
        {
            _listOfMetaType.SetActive(false);
            _listOfMetaSize.SetActive(false);
            _listOfMetaAlignment.SetActive(false);
            _listOfMetaNames.SetActive(false);
        }
    }

    public void CheckFilterChallenge(string word = "")
    {
        _inputOpenMetaChallange.transform.GetChild(1).GetComponent<Text>().text += word + " ";
        _inputOpenMetaChallange.text = "";

        if (word == "")
            _inputOpenMetaChallange.GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f, 0.8f); //grey color
        else
            _inputOpenMetaChallange.GetComponent<Image>().color = new Color(0.8679f, 0.6501f, 0.8176f, 1f);
    }
    public void CheckToAcceptFilter(string word, InputField inputField, Color color, string textPlaceholder = "")
    {
        inputField.transform.GetChild(1).GetComponent<Text>().text = word;
        inputField.text = textPlaceholder;

        if (word == "")
            inputField.GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f, 0.8f); //grey color
        else
            inputField.GetComponent<Image>().color = color;
    }
    public void RemoveChallengeRate(string word)
    {
        string replaced = _inputOpenMetaChallange.transform.GetChild(1).GetComponent<Text>().text.Replace(word + " ", string.Empty);
        _inputOpenMetaChallange.transform.GetChild(1).GetComponent<Text>().text = replaced;

        if (replaced == "")
            _inputOpenMetaChallange.GetComponent<Image>().color = new Color(0.8f, 0.8f, 0.8f, 0.8f); //grey color
        else
            _inputOpenMetaChallange.GetComponent<Image>().color = new Color(0.8679f, 0.6501f, 0.8176f, 1f);
    }

    public void HideOpenMenuFilter(GameObject MenuPanel) => MenuPanel.SetActive(false);

    public void ClearInputField(InputField inputField) => inputField.transform.GetChild(1).GetComponent<Text>().text = "";

    public void GetAllMetaForButton(int n)
    {
        for (int i = 0; i < helperJSONData.Count; i++)
        {
            string[] metaDataAndAlignment = helperJSONData[i].meta.Split(',');
            string[] creatureSizeAndType = metaDataAndAlignment[0].Split(' ');

            switch (n) {
                case 0: SetActiveList(_listOfMetaType, creatureSizeAndType[1], allTypeManual, _parentSectionType, _slotPrefabType); break;
                case 1: SetActiveList(_listOfMetaSize, creatureSizeAndType[0], allSizeManual, _parentSectionSize, _slotPrefabSize); break;
                case 2: SetActiveList(_listOfMetaAlignment, metaDataAndAlignment[1], allAlignmentManual, _parentSectionAlignment, _slotPrefabAlignment); break;
                case 3: SetActiveList(_listOfMetaChallange, helperJSONData[i].Challenge, allChallengeManual, _parentSectionChallenge, _slotPrefabChallenge, false); break;
                default: Debug.Log("No such meta in manual"); break;
            }
        }
    }

    public void OnChangeInputFieldByType(InputField text) => SetDataFromInputField(_parentSectionType, _slotPrefabType, text.text, allTypeManual);
    public void OnChangeInputFieldBySize(InputField text) => SetDataFromInputField(_parentSectionSize, _slotPrefabSize, text.text, allSizeManual);
    public void OnChangeInputFieldByAlignment(InputField text) => SetDataFromInputField(_parentSectionAlignment, _slotPrefabAlignment, text.text, allAlignmentManual);
    public void OnChangeInputFieldByChallenge(InputField text) => SetDataFromInputField(_parentSectionChallenge, _slotPrefabChallenge, text.text, allChallengeManual);
    public void ClickOnButtonChallenge()
    {
        originalChallengeInfoDictionary.Clear();
        CreateDictionaryByList(allChallengeManual);
        foreach (Transform child in _parentSectionChallenge)
        {
            child.GetComponent<Image>().color = new Color(0.7075472f, 0.6367925f, 0.6367925f, 0.3568628f);
        }
    }
    public void OnChangeInputFieldByName(InputField text)
    {
        foreach (Transform child in _parentSectionNames)
        {
            Destroy(child.gameObject);
            SetActiveList(false);
        }

        string name = text.text;

        if (name.Length >= 3)
        {
            string nameCreature;
            for (int i = 0; i < helperJSONData.Count; i++)
            {
                nameCreature = helperJSONData[i].name;
                if (nameCreature.ToLower().Contains(name.ToLower()))
                {
                    SetActiveList(true);
                    InstantiateSlot(_parentSectionNames, _slotPrefabNames, nameCreature);
                }
            }
        }

        void SetActiveList(bool activeState) => _listOfMetaNames.SetActive(activeState);
    }

    private void SetDataFromInputField(Transform parentSection, GameObject slot, string fromInputText, List<string> metaList)
    {
        foreach (Transform child in parentSection)
            Destroy(child.gameObject);

        InstantiateSlot(parentSection, slot, "");

        foreach (var x in metaList)
        {
            if (x.Contains(fromInputText))
                InstantiateSlot(parentSection, slot, x);
        }
    }

    private void SetActiveList(GameObject gameObjectList, string s, List<string> manualList, Transform parent, GameObject slot, bool isInstantiateSlotTrue = true)
    {
        gameObjectList.SetActive(true); 
        CheckTypeIfExist(s, manualList, parent, slot, isInstantiateSlotTrue);
    }

    private void CheckTypeIfExist(string newType, List<string> listMeta, Transform parentSection, GameObject slotPrefab, bool isInstantiateSlotTrue)
    {
        if (!listMeta.Contains(newType))
        {
            listMeta.Add(newType);
            if(isInstantiateSlotTrue)
                InstantiateSlot(parentSection, slotPrefab, newType);
        }
    }
    
    private void CreateDictionaryByList(List<string> list)
    {
        int count = 0;
        foreach(var element in list)
            originalChallengeInfoDictionary.Add(count++, element); 
        
        GetSortedChallengeLevelDictionary(originalChallengeInfoDictionary);
    }
    private void GetSortedChallengeLevelDictionary(Dictionary<int, string> challengeDictionary)
    {
        Dictionary<int, int> challengeDictionaryInt = new Dictionary<int, int>();
        int key = 0;

        foreach(var element in challengeDictionary)
        {
            string[] getDirectExp = element.Value.Split('(', ' ');
            if (getDirectExp[2].Contains(","))
            {
                string[] getWithoutComma = getDirectExp[2].Split(',');
                string withoutComma = getWithoutComma[0] + getWithoutComma[1];
                challengeDictionaryInt.Add(key++, Int32.Parse(withoutComma, CultureInfo.InvariantCulture));
            }
            else
                challengeDictionaryInt.Add(key++, Int32.Parse(getDirectExp[2], CultureInfo.InvariantCulture));
        }

        challengeDictionaryInt = challengeDictionaryInt.OrderBy(u => u.Value).ToDictionary(z => z.Key, y => y.Value);
        CompareTwoDictionariesForChallenge(challengeDictionaryInt, challengeDictionary);
    }
    private void CompareTwoDictionariesForChallenge(Dictionary<int, int> sortedInfo, Dictionary<int, string> originalInfo)
    {
        foreach (KeyValuePair<int, int> info in sortedInfo)
            InstantiateSlot(_parentSectionChallenge, _slotPrefabChallenge, originalInfo[info.Key]);
        
    }  
}
