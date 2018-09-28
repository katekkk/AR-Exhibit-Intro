using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class toggle_manage : MonoBehaviour, IBeginDragHandler,IEndDragHandler {

    private float[] pageArray = new float[] { 0, 0.333f, 0.666f, 1 };
    private float targetPosition = 0;
    private bool isDrag = false;

    public ScrollRect scrollRect;
    public Toggle[] toogleArray;
    public float smooth = 5;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(isDrag == false)
        {
            scrollRect.horizontalNormalizedPosition = Mathf.Lerp(
                scrollRect.horizontalNormalizedPosition,
                targetPosition,
                Time.deltaTime * smooth);
      
        }
	}
    public void onBeginDrag(PointerEventData eventData)
    {
        isDrag = true;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDrag = false;
        float posX = scrollRect.horizontalNormalizedPosition;
        int index = 0;
        float offset = Mathf.Abs(pageArray[index] - posX);
        for (int i = 1; i < pageArray.Length; i++)
        {
            float offsetTmp = Mathf.Abs(pageArray[i] - posX);
            if(offsetTmp < offset)
            {
                index = i;
                offset = offsetTmp;
            }
        }
        targetPosition = pageArray[index];
        toogleArray[index].isOn = true;
        print(scrollRect.horizontalNormalizedPosition);
    }

    public void MoveToPage0(bool isOn)
    {
        if(isOn == true)
        {
            targetPosition = pageArray[0];
        }
    }

    public void MoveToPage1(bool isOn)
    {
        if (isOn == true)
        {
            targetPosition = pageArray[1];
        }
    }
    public void MoveToPage2(bool isOn)
    {
        if (isOn == true)
        {
            targetPosition = pageArray[2];
        }
    }
    public void MoveToPage3(bool isOn)
    {
        if (isOn == true)
        {
            targetPosition = pageArray[3];
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
