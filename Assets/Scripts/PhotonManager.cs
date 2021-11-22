using Photon.Pun;
using UnityEngine;

public class PhotonManager : MonoBehaviour
{
    public MenuManager MenuManager;
    private string gameVersion = "1";

    void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    
    void Start()
    {
        Connect();
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.GameVersion = gameVersion;
    }

    public void JoinRandomRoom()
    {
        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
            MenuManager.LoadGameScene();
        }
    }
}