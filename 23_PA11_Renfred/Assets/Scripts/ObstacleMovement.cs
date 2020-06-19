using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
    private float xSpeed = -4f;
    public bool passedPlayer;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(xSpeed*Time.deltaTime, 0, 0f));
        if (transform.position.y < -5)
        {
            Destroy(this.gameObject);
        }

        if (!passedPlayer)
        {
            if (transform.position.x < player.transform.position.x)
            {
                player.GetComponentInParent<Player>().AddScore(1);
                passedPlayer = true;
            }
        }
        else
        {
            if (transform.position.x < player.transform.position.x-1f)
            {
                Destroy(gameObject);
            }
        }
    }
}
