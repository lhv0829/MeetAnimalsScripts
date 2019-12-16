using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showWord : MonoBehaviour
{
    string boxContent;

    public Text wordDisplayText;

    public GameObject panel;

    public int dist=5;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        touchClick();
    }

    void touchClick()
    {
        if((Input.GetButton("Fire1")))
        {
            RaycastHit hit;

            Ray touchray=Camera.main.ScreenPointToRay(Input.mousePosition);

            Physics.Raycast(touchray, out hit);

            var p = GameObject.Find("Player").GetComponent<player>();

            
            if(hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                if(hit.collider.gameObject.CompareTag("Animal"))    
                {
                    if(hit.distance <= dist)
                    {
                        p.playerSpeed = 0;
                        panel.SetActive(true);
                        boxContent=hit.collider.gameObject.name;
                        wordDisplayText.text = boxContent.ToString();
                    }
                }
                else
                {
                    p.playerSpeed = 3;
                    panel.SetActive(false);
                    boxContent=hit.collider.gameObject.name;
                    wordDisplayText.text = boxContent.ToString();
                }
            }
            
        }
    }
   
}
