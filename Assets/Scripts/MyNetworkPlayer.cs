using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SyncVar][SerializeField] private string displayName = "Missing Name";
    [SyncVar][SerializeField] private Color playerColor = Color.black;
    [SerializeField] private MeshRenderer sphere;

    [Server]
    public void SetDisplayName(string newDisplayName)
    {
        displayName = newDisplayName;
    }


    [Server]
    public void SetColor(Color newPlayerColor)
    {
      playerColor =  newPlayerColor;
      sphere.material.color = playerColor;
      
    }


}
