using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public class UIVirtualJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    
    
    [Header("Rect References")]
    public RectTransform containerRect;
    public RectTransform handleRect;

    [Header("Settings")]
    public float joystickRange = 50f;
    public float magnitudeMultiplier = 1f;
    public Muwer muwer;

    void Start()
    {
        muwer = Muwer.regit;
    }
    void OnEnable()
    {
        
        SetupHandle();
    }

    private void SetupHandle()
    {
        if(handleRect)
        {
            UpdateHandleRectPosition(Vector2.zero);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        RectTransformUtility.ScreenPointToLocalPointInRectangle(containerRect, eventData.position, eventData.pressEventCamera, out Vector2 position);
        position = ApplySizeDelta(position);
        Vector2 clampedPosition = ClampValuesToMagnitude(position);
        if(handleRect)
        {
            UpdateHandleRectPosition(clampedPosition * joystickRange);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(handleRect)
        {
             UpdateHandleRectPosition(Vector2.zero);
        }
    }

    void Update()
    {
        muwer.muve = new Vector3(handleRect.localPosition.x/joystickRange, 0, handleRect.localPosition.y/joystickRange);
    }

    private void UpdateHandleRectPosition(Vector2 newPosition)
    {
        newPosition = new Vector2(newPosition.x, newPosition.y);
        handleRect.localPosition = newPosition;
    }

    Vector2 ApplySizeDelta(Vector2 position)
    {
        float x = (position.x/containerRect.position.x) * 2.5f;
        float y = (position.y/containerRect.position.y) * 2.5f;
        return new Vector2(x, y);
    }

    Vector2 ClampValuesToMagnitude(Vector2 position)
    {
        return Vector2.ClampMagnitude(position, 1);
    }

    float InvertValue(float value)
    {
        return -value;
    }
    
}