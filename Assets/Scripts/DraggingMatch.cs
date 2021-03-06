﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggingMatch : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler {

    private const string TAG_PLACEHOLDER = "PlaceHolder";

    public static GameObject DraggedInstance;

    Vector3 _startPosition;
    Vector3 _offsetToMouse;
    float _zDistanceToCamera;

    #region Interface Implementations

    public void OnBeginDrag(PointerEventData eventData) {
        DraggedInstance = gameObject;
        _startPosition = transform.position;
        _zDistanceToCamera = Mathf.Abs(_startPosition.z - Camera.main.transform.position.z);

        _offsetToMouse = _startPosition - Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, _zDistanceToCamera)
        );
    }

    public void OnDrag(PointerEventData eventData) {
        if (Input.touchCount > 1)
            return;

        transform.position = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, _zDistanceToCamera)
            ) + _offsetToMouse;
    }

    public void OnEndDrag(PointerEventData eventData) {
        DraggedInstance = null;
        _offsetToMouse = Vector3.zero;

        if (eventData.pointerCurrentRaycast.gameObject) {
            Debug.Log(eventData.pointerCurrentRaycast.gameObject);
            if (eventData.pointerCurrentRaycast.gameObject.tag == TAG_PLACEHOLDER) {
                Debug.Log("test");
            }
        } else {
            Debug.Log("Not found");
        }
    }

    #endregion
}
