using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuickView : EditorWindow {

    [MenuItem("Window/Quick View")]
    public static void ShowWindow()
    {
        GetWindow<QuickView>("Quick View");
    }

    private void OnGUI()
    {
        //Player
        GUILayout.BeginVertical();
        GUILayout.Label("Player");
        if (GUILayout.Button("Player Object"))
        {
            Selection.activeGameObject = GameObject.FindGameObjectWithTag("Player");
        }

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Left Hand"))
        {
            Selection.activeGameObject = PlayerEquipment.instance.leftHand;
        }

        if (GUILayout.Button("Right Hand"))
        {
            Selection.activeGameObject = PlayerEquipment.instance.rightHand;
        }
        GUILayout.EndHorizontal();
        GUILayout.EndVertical();

        //Managers
        GUILayout.BeginVertical();
        GUILayout.Label("Management");
        if (GUILayout.Button("Player Manager"))
        {
            Selection.activeGameObject = FindObjectOfType<PlayerManager>().gameObject;
        }
        GUILayout.EndVertical();
    }
}
