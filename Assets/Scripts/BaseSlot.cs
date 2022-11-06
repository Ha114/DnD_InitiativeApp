using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseSlot : MonoBehaviour
{
    [SerializeField] InputField _Name;
    [SerializeField] InputField _Initiative;
    [SerializeField] Button _deletePlayer;

    public void DeleteThisObject()
    {
        Destroy(gameObject);
    }
}
