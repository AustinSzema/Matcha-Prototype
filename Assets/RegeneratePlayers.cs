using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegeneratePlayers : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public GameObject player5;

    public List<GameObject> players = new List<GameObject>();

    public GameObject[] playerListStart;


    public GameObject[] playerListCheck;

    // Start is called before the first frame update
    void Start()
    {

        players.Add(player1);
        players.Add(player2);
        players.Add(player3);
        players.Add(player4);
        players.Add(player5);


    }

    // Update is called once per frame
    void Update()
    {
        playerListCheck = GameObject.FindGameObjectsWithTag("Player");

        Debug.Log(playerListCheck);
        if(playerListCheck.Length == 0)
        {
            foreach (GameObject player in players)
            {
                Instantiate(player, player.transform.position, Quaternion.identity);
            }

        }



    }
}
