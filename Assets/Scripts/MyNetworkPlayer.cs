using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;
using System.Runtime.Remoting.Messaging;

public class MyNetworkPlayer : NetworkBehaviour {

    
    [SyncVar(hook = nameof(HandlePlayerName))]
    [SerializeField] private string displayName = "Missing Name";

    [SyncVar(hook=nameof(HandleDisplayColor))]
    [SerializeField] private Color playerColor = Color.black;


    [SerializeField] private Renderer sphere;
    [SerializeField] private TMP_Text displayNameText = null;


    #region server

    [Server]
    public void SetDisplayName(string newDisplayName)
    {
        displayName = newDisplayName;
    }


    [Server]
    public void SetColor(Color newPlayerColor)
    {
      playerColor =  newPlayerColor;
    }


    [Command]
    private void CmdSetDisplayName(string newDisplayName)
    {
        if (newDisplayName.Length < 2 || newDisplayName.Length > 20) { return; }
        RpcLogTheNewName(newDisplayName);
        SetDisplayName(newDisplayName);
    }

    

    #endregion

    #region client
    private void HandleDisplayColor(Color oldColor, Color newColor)
    {
        sphere.material.SetColor("_BaseColor", newColor);
    }

    private void HandlePlayerName(string oldName, string newName) 
    {
        displayNameText.text = newName;
    }

    [ContextMenu("Set My Name")]
    private void SetMyName() 
    {
        CmdSetDisplayName("My New Name");
    }

    [ClientRpc]
    private void RpcLogTheNewName(string newName) 
    {
       Debug.Log(newName);
    }


    #endregion



}
