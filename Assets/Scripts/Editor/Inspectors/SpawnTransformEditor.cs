using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Primary))]
public class SpawnTransformEditor : Editor {
    
    private Weapon targetWeapon;

    private void OnEnable()
    {
        targetWeapon = (Weapon)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        GUILayout.Label("Spawn Position Info");
        EditorGUILayout.BeginVertical();
        targetWeapon.spawnPosition = EditorGUILayout.Vector3Field("Spawn Position", targetWeapon.spawnPosition, null);
        targetWeapon.spawnRotation = EditorGUILayout.Vector3Field("Spawn Rotation", targetWeapon.spawnRotation, null);
        targetWeapon.spawnScale = EditorGUILayout.Vector3Field("Spawn Scale", targetWeapon.spawnScale, null);
        EditorGUILayout.EndVertical();
    }
}