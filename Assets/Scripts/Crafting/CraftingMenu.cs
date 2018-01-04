using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine;
using UnityEngine.UI;

public class CraftingMenu : MonoBehaviour {

    public GameObject holder;
    public Text ingredientDisplay;

    private bool showingUI = false;
    private MouseLook mouseLook;
    private FirstPersonController controller;

    private void Start()
    {
        mouseLook = FindObjectOfType<FirstPersonController>().m_MouseLook;
        controller = FindObjectOfType<FirstPersonController>();
    }

    public void Toggle()
    {
        showingUI = !showingUI;

        if (showingUI)
        {
            ToggleMouse();
        }

        else
        {
            UnToggleMouse();
        }

        holder.SetActive(showingUI);
    }

    #region Mouse

    private void ToggleMouse()
    {
        mouseLook.m_cursorIsLocked = false;
        controller.canMove = false;
    }

    private void UnToggleMouse()
    {
        mouseLook.m_cursorIsLocked = true;
        controller.canMove = true;
    }

    #endregion
}