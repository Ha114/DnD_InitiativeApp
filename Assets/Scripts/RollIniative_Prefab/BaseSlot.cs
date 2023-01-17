using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseSlot : MonoBehaviour
{
    [SerializeField] public InputField _nameInput;
    [SerializeField] public InputField _initiativeInput;
  //  [SerializeField] Button _deletePlayerButton;

    public void SetData(string Name, string Iniative)
    {
        _nameInput.text = Name;
        _initiativeInput.text = Iniative;
    }


   

    public void DeleteThisObject() => Destroy(gameObject);
  
}
