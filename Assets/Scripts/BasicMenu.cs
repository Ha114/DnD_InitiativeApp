using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BasicMenu : MonoBehaviour
{
    public void CloseObject(GameObject gameObject) => gameObject.SetActive(false);
    public void ShowObject(GameObject gameObject) => gameObject.SetActive(true);
    public void DestroyObject(GameObject gameObject) => Destroy(gameObject);


}
