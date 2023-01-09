using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlockerGUI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Camera camera;
    Vector3 mousePos;
    RectTransform rt;
    RectTransform rectTransform;
    void Start()
    {
        rectTransform = gameObject.GetComponent<RectTransform>();

        float rectWidth = (rectTransform.anchorMax.x - rectTransform.anchorMin.x) * Screen.width;
        float rectHeight = (rectTransform.anchorMax.y - rectTransform.anchorMin.y) * Screen.height;


        Renderer rend = gameObject.GetComponent<Renderer>();
        Debug.Log(rend.bounds.max);
        Debug.Log(rend.bounds.min);
        rt = gameObject.GetComponent<RectTransform>();
        DisplayWorldCorners();
        //float x  = gameObject.transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        //Debug.Log("x = " + x);

        /* Debug.LogError("anchorMax.x = " + rectTransform.anchorMax.x);
         Debug.LogError("anchorMin.x = " + rectTransform.anchorMin.x);

         Debug.LogError("anchorMax.y = " + rectTransform.anchorMax.y);
         Debug.LogError("anchorMin.y = " + rectTransform.anchorMin.y);*/

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
           // mousePos.z = 0;
            //gameObject.transform.position = mousePos;
            Debug.LogError("Mouse = " + mousePos);
            float rectWidth = (rectTransform.anchorMax.x - rectTransform.anchorMin.x) * Screen.width;
            float rectHeight = (rectTransform.anchorMax.y - rectTransform.anchorMin.y) * Screen.height;
            Debug.LogError("Width = " + rectWidth + ", Height = " + rectHeight);

        }
    }

    void DisplayWorldCorners()
    {
        Vector3[] v = new Vector3[4];
        rt.GetWorldCorners(v);

        Debug.Log("World Corners");
        for (var i = 0; i < 4; i++)
        {
            Debug.Log("World Corner " + i + " : " + v[i]);
        }
    }

}
