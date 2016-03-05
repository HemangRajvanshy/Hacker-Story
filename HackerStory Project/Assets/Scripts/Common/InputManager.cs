using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;

public class InputManager : MonoBehaviour {

	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Escape))
        {
            Main.Instance.Back.Back();
        }

        if(Input.GetMouseButtonDown(0))
        {
            PointerEventData pointer = new PointerEventData(EventSystem.current);
            pointer.position = Input.mousePosition;

            List<RaycastResult> raycastResults = new List<RaycastResult>();
            EventSystem.current.RaycastAll(pointer, raycastResults);

            Main.Instance.OnClick(raycastResults[0]);
        }
    }
}
