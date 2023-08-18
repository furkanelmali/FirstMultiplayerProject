using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.AI;


public class CharacterMovement : NetworkBehaviour
{
    [SerializeField] private NavMeshAgent agent;

    private Camera mainCamera;


    #region Server
    [Command]
     private void CmdMovement(Vector3 position)
    {
        if (!NavMesh.SamplePosition(position, out NavMeshHit hit, 1f, NavMesh.AllAreas)){ return; }
        agent.SetDestination(position);
    
    }

    #endregion
     
    public override void OnStartAuthority()
    {
        mainCamera = Camera.main;
    }

    [ClientCallback]
    private void Update()
    {
        if (!hasAuthority) { return; }
        if (!Input.GetMouseButtonDown(1)) {return;}

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity)) { return; }

        CmdMovement(hit.point);

    }

    #region Client
    #endregion
}
