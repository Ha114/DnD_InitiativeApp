using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] public Transform _parentCanvas;
    [SerializeField] public GameObject[] _scenesPrefabs;




    public void SetNewScenePrefab(int nrScene = 0)
    {
        Instantiate(_scenesPrefabs[nrScene], _parentCanvas);
        //WordSlot wordSlot = GO.GetComponent<WordSlot>();
    }

    // Start is called before the first frame update
    void Start()
    {
        //SetNewScenePrefab();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
