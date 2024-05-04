using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowsCharacter : MonoBehaviour
{
    public GameObject player;
    public Vector2 offset;

    void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, transform.position.z);
    }
}
