using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseTest : MonoBehaviour
{
    
    
    string boxContent;

    public Object sky;

    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        touchClick();
    }
    void touchClick()
    {
       if(Input.GetMouseButtonDown(0))
       {
            RaycastHit hit;
        
            Ray touchray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(touchray, out hit);

            if(hit.collider != null)
            {
                boxContent=hit.collider.gameObject.name;
                Debug.Log(hit.collider.gameObject.name);

                if(boxContent.Equals(sky.name))
                {
                    menu.SetActive(true);
                }
                else
                {
                    menu.SetActive(false);
                }
            }
       }
    
    }
}
