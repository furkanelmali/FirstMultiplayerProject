using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkManager : NetworkManager
{
    

    public override void OnServerAddPlayer(NetworkConnectionToClient conn)
    {
        base.OnServerAddPlayer(conn);

        MyNetworkPlayer player = conn.identity.GetComponent<MyNetworkPlayer>();
        Material playerMaterial = conn.identity.GetComponent<Material>();
        player.SetDisplayName($"Player {numPlayers} ");
        player.SetColor(new Color(Random.Range(0f,1f),Random.Range(0f,1f),Random.Range(0f,1f)));
        
        Debug.Log($"Player joined to server. {numPlayers} players inside now.");
    }
}
