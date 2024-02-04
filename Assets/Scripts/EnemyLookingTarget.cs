using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLookingTarget : MonoBehaviour
{
    [SerializeField] private LayerMask _platformLayer;

    private void Update()
    {
        Debug.Log(CheckPlayerVisibil());
    }

    private bool CheckPlayerVisibil()
    {
      
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.left, 10, _platformLayer);

        Debug.DrawRay(transform.position, Vector3.left,Color.red, 10);

        return hit.collider != null;
    }
}
