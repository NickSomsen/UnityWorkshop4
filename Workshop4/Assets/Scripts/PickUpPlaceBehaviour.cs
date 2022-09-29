using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PickUpPlaceBehaviour : MonoBehaviour
{
    private GameObject[] bridgePieces;
    private int bridgePieceIdx = 0;

    public float bridgeHeight;

    private void Start()
    {
        bridgePieces = GameObject.FindGameObjectsWithTag("BridgePiece");
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("PickUp"))
        {
            Debug.Log(bridgePieceIdx);
            GameObject bridgePiece = bridgePieces[bridgePieceIdx];
            bridgePiece.transform.position += new Vector3(0.0f, bridgeHeight * Time.deltaTime, 0.0f);
            bridgePieceIdx++;
        }
    }
}
