using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PhoneButton : MonoBehaviour, IPointerDownHandler
{
    public UnityEvent onButtonDown;

    public void OnPointerDown(PointerEventData eventData)
    {
        onButtonDown.Invoke();
    }
}
