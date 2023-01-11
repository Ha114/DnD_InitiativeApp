using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilteringSlot : MonoBehaviour
{
    [SerializeField] Text filtrName;
    public void OnClickFindByName() => MenuFilteringManual.instanceMenuFilteringManual.SetManualDataByFilter(0, filtrName.text);
    public void OnClickFindByType() => MenuFilteringManual.instanceMenuFilteringManual.SetManualDataByFilter(1, filtrName.text);
    public void OnClickFindBySize() => MenuFilteringManual.instanceMenuFilteringManual.SetManualDataByFilter(2, filtrName.text);
    public void OnClickFindByAlignment() => MenuFilteringManual.instanceMenuFilteringManual.SetManualDataByFilter(3, filtrName.text);
    public void OnClickFindByChallenge() => MenuFilteringManual.instanceMenuFilteringManual.SetManualDataByFilter(4, filtrName.text);


    public void ChangeColorOnClick(Button button)
    {
        Color color = button.GetComponent<Image>().color;
        string textButton = button.transform.GetChild(0).GetComponent<Text>().text;

        if (color == new Color(0.5849f, 0.2615f, 0.5207f, 0.6666f) || textButton == "")
        {
            button.GetComponent<Image>().color = new Color(0.7075472f, 0.6367925f, 0.6367925f, 0.3568628f); //basic color
            MenuFilteringManual.instanceMenuFilteringManual.RemoveChallengeRate(textButton);
        }
        else
        {
            button.GetComponent<Image>().color = new Color(0.5849f, 0.2615f, 0.5207f, 0.6666f);
            MenuFilteringManual.instanceMenuFilteringManual.CheckFilterChallenge(textButton);
        }
    }
}
