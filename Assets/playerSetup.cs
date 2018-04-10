
using UnityEngine;
using UnityEngine.Networking;

[RequireComponent(typeof(Player))]
public class playerSetup : NetworkBehaviour {

    [SerializeField]
    Behaviour[] componetToDisable;

    [SerializeField]
    string remoteLayerName = "RemotePlayer";

    Camera sceneCamera;

    private void Start()
    {
        if(!isLocalPlayer)
        {
            DisableComponets();
            AssignRemoteLayer();
        }
        else
        {
            sceneCamera = Camera.main;
            if(sceneCamera != null)
            {
                Camera.main.gameObject.SetActive(false);
            }
            
        }


        RegisterPlayer();

    }


    public override void OnStartClient()
    {
        base.OnStartClient();

        string _netID = GetComponent<NetworkIdentity>().netId.ToString();
        Player _player = GetComponent<Player>();

        GameManager.RegisterPlayer(_netID, _player);
    }
    void RegisterPlayer()
    {
        string _ID = "Player " + GetComponent<NetworkIdentity>().netId;
        transform.name = _ID;
    }

    void AssignRemoteLayer()
    {
        gameObject.layer = LayerMask.NameToLayer(remoteLayerName);
    }

    void DisableComponets()
    {
        for (int i = 0; i < componetToDisable.Length; i++)
        {
            componetToDisable[i].enabled = false;
        }
    }

    private void OnDisable()
    {
        if(sceneCamera != null)
        {
            Camera.main.gameObject.SetActive(true);
        }

        GameManager.UnRegisterPlayer(transform.name);
    } 


}
