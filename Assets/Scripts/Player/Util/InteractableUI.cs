using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableUI : MonoBehaviour {

    public Text text;

    private Interactable interactable;

    bool HasInteractableInFront()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        Physics.Raycast(ray, out hit, PlayerManager.stats.interactableReach);
        if (hit.collider != null)
        {
            GameObject obj = hit.collider.gameObject;
            Interactable interactable = obj.GetComponent<Interactable>();
            if (interactable != null)
            {
                this.interactable = interactable;
                return true;
            }
        }
        return false;
    }

    private void Update()
    {
        if (HasInteractableInFront())
        {
            text.text = "Press [mouse 2] to interact with: " + interactable.interactableName;
        }
        else {
            text.text = "";
        }
    }
}