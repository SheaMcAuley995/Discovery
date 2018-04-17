using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour {


    private const string PLAYER_TAG = "Player";

    [SerializeField]
    private Camera cam;

    [SerializeField]
    private LayerMask mask;

    private PlayerWeapon currentWeapon;

    void Start()
    {
        if (cam == null)
        {
            Debug.LogError("PlayerShoot: No camera referenced!");
            this.enabled = false;
        }

    }

    void Update()
    {

            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
 
    }

    [Client]
    void Shoot()
    {
        if (!isLocalPlayer)
        {
            return;
        }



        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, currentWeapon.range, mask))
        {
            if (_hit.collider.tag == PLAYER_TAG)
            {
                CmdPlayerShot(_hit.collider.name, currentWeapon.damage, transform.name);
            }
        }


    }

    [Command]
    void CmdPlayerShot(string _playerID, int _damage, string _sourceID)
    {
        Debug.Log(_playerID + " has been shot.");

        Player _player = GameManager.Getplayer(_playerID);
        _player.RpcTakeDamage(_damage);
    }

}

