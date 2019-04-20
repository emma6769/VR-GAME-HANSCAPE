using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flashLight : MonoBehaviour
{
    private bool onTrigger;
    
    [SerializeField]
    private Text l_text;


    void OnTriggerEnter(Collider collider)
    {
        onTrigger = true;
        l_text.text = "획득하려면" + "<color=yellow>" + "(F)" + "</color>";
    }
    void OnTriggerExit(Collider collider)
    {
        onTrigger = false;
        l_text.text = "";
    }

    void Start()
    {
        (GameObject.FindGameObjectWithTag("flash")).SetActive(false);
        (GameObject.FindGameObjectWithTag("flashLight")).SetActive(false);
        (GameObject.FindGameObjectWithTag("flashTrigger")).SetActive(true);
    }
    void Update()
    {
        if (onTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                l_text.text = "";
                (GameObject.FindGameObjectWithTag("flash")).SetActive(true);
                (GameObject.FindGameObjectWithTag("flashLight")).SetActive(true);
                (GameObject.FindGameObjectWithTag("flashTrigger")).SetActive(false);
            }
        }
    }
}