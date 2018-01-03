using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogDisplay : MonoBehaviour {

    public Text text;
    public float textDelay;

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }

    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    void HandleLog(string text, string stackTrace, LogType type) {
        StartCoroutine(SetText(text));  
    }

    IEnumerator SetText(string text)
    {
        StopCoroutine("SetText");
        this.text.text = text;
        yield return new WaitForSeconds(textDelay);
        this.text.text = "";
    }
}