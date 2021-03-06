﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public string keyName;
    private bool doorKey;   //더이상 할 필요 없음 열쇠를 쓴상태
    private bool getKey;    // 사용자가 열쇠를 들고있음
    private bool doorOpen;  //문이 열려있는 상태
    private bool onTrigger;
    private Transform target;
    private GameObject child;
    private ActionController ac;

    void OnTriggerStay(Collider other)
    {
        onTrigger = true;
        if (other.transform.childCount > 0)
        {
            target = other.transform.GetChild(0);

            if (target.childCount > 1)
            {
                child = target.GetChild(1).gameObject;
                if(child.name == keyName)
                {
                    getKey = true;
                }
            }
            else
            {
                getKey = false;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        onTrigger = false;
    }
    void Start()
    {
        ac = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ActionController>();
    }

    void Update()
    {
        if (onTrigger)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if(doorOpen)
                {
                    doorOpen = false;
                }
                else
                {
                    if (getKey || doorKey)
                    {
                        doorOpen = true;
                    }
                }
            }

        }
        
        if (doorOpen)   
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, -90.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;

            if (getKey)
            {
                getKey = false;
                doorKey = true;

                ac.UseItem(child);
            }
        }
        else
        {
            var newRot = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0.0f, 180.0f, 0.0f), Time.deltaTime * 200);
            transform.rotation = newRot;
        }
    }

    private void OnGUI()
    {
        if (onTrigger)
        {
            if (doorOpen)
            {
                GUI.Box(new Rect(0, 0, 200, 25), "Press F to close");                
            }
            else
            {
                if (getKey || doorKey)
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "Press F to open");
                }
                else
                {
                    GUI.Box(new Rect(0, 0, 200, 25), "Need a Key!");
                }
            }
        }
    }
}
