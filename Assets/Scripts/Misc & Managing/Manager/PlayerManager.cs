using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {

#region singleton

    public static PlayerManager instance;
    public static PlayerStats stats;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    #region events

    public delegate void PlayerUpdate();
    public static event PlayerUpdate OnPlayerUpdate;

    #endregion

    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        stats = GetPlayer().GetComponent<PlayerStats>();
    }

    public GameObject GetPlayer()
    {
        return player;
    }

    void UpdatePlayer()
    {
        if (OnPlayerUpdate != null)
        {
            OnPlayerUpdate();
        }
    }

    private void Update()
    {
        UpdatePlayer();
    }
}