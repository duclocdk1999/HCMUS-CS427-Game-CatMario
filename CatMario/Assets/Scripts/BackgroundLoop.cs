﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour {

    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;

	// Use this for initialization
	void Start () {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(
            new Vector3(
                Screen.width, 
                Screen.height, 
                mainCamera.transform.position.z
            )
        );
        foreach(GameObject obj in levels)
        {
            LoadChildObjects(obj);
        }
    }
	// -------------------------------------------------------------------------
    void LoadChildObjects(GameObject obj)
    {
        Debug.Log(obj.name);

        float objWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x;
        int childsNeed = (int)(screenBounds.x * 2 / objWidth);
        GameObject clone = Instantiate(obj) as GameObject;
        for (int i = 0; i < childsNeed; i++)
        {
            GameObject c = Instantiate(clone) as GameObject;
            c.transform.SetParent(obj.transform);
            c.transform.position = new Vector3(objWidth * i, obj.transform.position.y, obj.transform.position.z);
            c.name = obj.name + i;
        }
        Destroy(clone);
        Destroy(obj.GetComponent<SpriteRenderer>());
    }
    // -------------------------------------------------------------------------
    void rePositionObject(GameObject obj)
    {
        Transform[] children = obj.GetComponentsInChildren<Transform>();

        if (children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;

            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x;
            if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(
                                                    lastChild.transform.position.x + halfObjectWidth * 2, 
                                                    lastChild.transform.position.y, 
                                                    lastChild.transform.position.z);
            }
            else
            if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth)
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(
                                                    firstChild.transform.position.x - halfObjectWidth * 2,
                                                    firstChild.transform.position.y,
                                                    firstChild.transform.position.z);
            }
        }
    }
    // -------------------------------------------------------------------------
    // Update is called once per frame
    void LateUpdate () {
		foreach(GameObject obj in levels)
        {
            rePositionObject(obj);
        }
    }
}
