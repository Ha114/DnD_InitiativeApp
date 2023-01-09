using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FilteringSlot : MonoBehaviour
{
    [SerializeField] Text filtrName;
    public void OnClickFindByName() => MenuFilteringManual.in2.SetManualDataByFilter(0, filtrName.text);
    public void OnClickFindByType() => MenuFilteringManual.in2.SetManualDataByFilter(1, filtrName.text);
    public void OnClickFindBySize() => MenuFilteringManual.in2.SetManualDataByFilter(2, filtrName.text);
    public void OnClickFindByAlignment() => MenuFilteringManual.in2.SetManualDataByFilter(3, filtrName.text);
    public void OnClickFindByChallenge1() => MenuFilteringManual.in2.SetManualDataByFilter(4, filtrName.text);


    public void ChangeColorOnClick(Button button)
    {
        Color color = button.GetComponent<Image>().color;
        string textButton = button.transform.GetChild(0).GetComponent<Text>().text;

        if (color == new Color(0.5849f, 0.2615f, 0.5207f, 0.6666f) || textButton == "")
        {
            button.GetComponent<Image>().color = new Color(0.7075472f, 0.6367925f, 0.6367925f, 0.3568628f); //basic color
            MenuFilteringManual.in2.RemoveChallengeRate(textButton);
        }
        else
        {
            button.GetComponent<Image>().color = new Color(0.5849f, 0.2615f, 0.5207f, 0.6666f);
            MenuFilteringManual.in2.CheckFilterChallenge(textButton);
        }
    }
}
