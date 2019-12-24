using UnityEngine;

public class CameraFollowObj : MonoBehaviour {

    private float playerX;
    private float playerZ;
    private float playerDirection;

    public Player player;

    void Start () {
        playerX = player.transform.position.x;
        playerZ = player.transform.position.z;
        playerDirection = player.Direction;
    }

    void LateUpdate () {   
        if (playerDirection != player.Direction) {
            playerDirection = player.Direction;
            playerX = player.TileCenterX;
            playerZ = player.TileCenterZ;
            playerDirection = player.Direction;
        }
        if (playerDirection == 00 || playerDirection == 180) {
            transform.position = new Vector3(playerX, transform.position.y, transform.position.z);
        }
        if(playerDirection == 90 || playerDirection == 270) {
            transform.position = new Vector3(transform.position.x, transform.position.y, playerZ);
        }
    }
}
