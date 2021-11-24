using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GamePhotonManager : MonoBehaviourPunCallbacks
{
    void Awake()
    {
        
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.LogFormat("Player {0} entered room", newPlayer.NickName);
    }
}