using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuDM_Prefab : MonoBehaviour
{
    public void OpenManualPrefabButton() => SceneManager.instanceSceneManager.OpenManualPrefab();
    public void OpenRollInitiativePrefabButton() => SceneManager.instanceSceneManager.OpenRollInitiativePrefab();

}
