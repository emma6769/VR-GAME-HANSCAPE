using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightSwitch : MonoBehaviour
{
    private bool onTrigger;
    private bool active;

    [SerializeField]
    private GameObject l_light;

    [SerializeField]
    private Text l_text;

    void OnTriggerEnter(Collider collider)
    {
        onTrigger = true;
        if (!l_light.activeSelf)
        {
            l_text.text = "불을 키려면" + "<color=yellow>" + "(F)" + "</color>";
        }
        else {
            l_text.text = "불을 끄려면" + "<color=yellow>" + "(F)" + "</color>";
        }
    }
    void OnTriggerExit(Collider collider)
    {
        onTrigger = false;
        l_text.text = "";
    }

    void Start()
    {
        l_light.SetActive(false);
        l_text.text = "";
    }
    void Update()
    {
        if (onTrigger)
        {

            if (Input.GetKeyDown(KeyCode.F))
            {
                active = !active;
                l_text.text = "";
            }
        }

        if (active)
        {
            l_light.SetActive(true);
        }
        else
        {
            l_light.SetActive(false);
        }
    }
}