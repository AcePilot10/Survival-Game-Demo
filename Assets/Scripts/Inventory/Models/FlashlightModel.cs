using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightModel : MonoBehaviour {

    public GameObject lightObject;

    private bool on = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Toggle();
        }
    }

    public void Toggle() {
        on = !on;
        lightObject.SetActive(on);
    }
}