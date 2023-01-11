using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    #region singleton
    public static SceneManager instanceSceneManager;
    private void Awake()
    {
        if (instanceSceneManager == null)
        {
            instanceSceneManager = this;
        }
    }
    #endregion

    [SerializeField] Transform _parentSection;
    [SerializeField] List<GameObject> _prefabScenes;

    private void Start()
    {
        OpenMainMenuPrefab();
    }

    public void BackToMainMenu(int i) => SetNewScenePrefab(_prefabScenes[0], _prefabScenes[i]);
    public void OpenManualPrefab() => SetNewScenePrefab(_prefabScenes[1], _prefabScenes[0]);
    public void OpenRollInitiativePrefab() => SetNewScenePrefab(_prefabScenes[2], _prefabScenes[0]);

    private void OpenMainMenuPrefab() => SetNewScenePrefab(_prefabScenes[0]);
    private void SetNewScenePrefab(GameObject newScene, GameObject oldScene = null)
    {
        newScene.SetActive(true);
        if(oldScene != null)
            oldScene.SetActive(false);
    }
}
