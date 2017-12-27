using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBroadcaster : MonoBehaviour {

    public void BroadcastAttack() {
        PlayerManager.instance.GetPlayer().BroadcastMessage("DoAttack");
    }
}