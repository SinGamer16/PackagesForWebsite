using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class GameSettings : MonoBehaviour
{

    public int playingAsPlayer = 0;
    private int numOfPlayersSpawned = 0;

    [SerializeField] private GameObject Player;
    private ThirdPersonSettings TPSplayerSettings;
    private FirstPersonSettings FPSplayerSettings;

    public int numOfPlayers = 1;
    [SerializeField] private List<Transform> SpawnPoints;

    [SerializeField] private List<GameObject> Players;
    


    void Awake()
    {
        // Gets the script if the player is in First person or Third person.
        if (Player.GetComponent<FirstPersonSettings>() == null)
        {
            TPSplayerSettings = Player.GetComponent<ThirdPersonSettings>();
        }
        else
        {
            FPSplayerSettings = Player.GetComponent<FirstPersonSettings>();
        }

        // Spawns all players
        for(int i = 0; i < SpawnPoints.Count; i++)
        {
            SpawnPlayer();
        }
        
    }

    // Checks if any spawns are free.
    bool AnySpawnsFree()
    {
        for (int i = 0; i < SpawnPoints.Count; i++)
        {
            if(SpawnPoints[i].GetComponent<SpawnPointScript>().SpawnUsed == true)
            {
                continue;
            }
            else
            {
                return true;
            }
        }
        return false;
    }

    // Spawns a player if a spawn point is free.
    void SpawnPlayer()
    {
        GameObject player;
        
        for (int i = 0; i < SpawnPoints.Count; i++)
        {
            if (SpawnPoints[i].GetComponent<SpawnPointScript>().SpawnUsed == true)
            {
                continue;
            }
            else
            {
                player = Instantiate(Player, SpawnPoints[i].position, SpawnPoints[i].rotation, transform.transform.parent);
                SpawnPoints[i].GetComponent<SpawnPointScript>().SpawnUsed = true;
                Players.Add(player);
                
                if(player.GetComponent<FirstPersonSettings>() == null)
                {
                    player.GetComponent<ThirdPersonSettings>().playerID = numOfPlayersSpawned;
                    Debug.Log(player.GetComponent<ThirdPersonSettings>().playerID);
                }
                else
                {
                    player.GetComponent<FirstPersonSettings>().playerID = numOfPlayersSpawned;
                    Debug.Log(player.GetComponent<FirstPersonSettings>().playerID);
                }

                numOfPlayersSpawned++;

                Debug.Log("Spawned Player");
                break;
            }
        }
    }

    // Gets Player using PlayerID.
    public GameObject GetPlayer(int id)
    {
        return Players[id];
    }

    // Gets active player.
    public GameObject GetActivePlayer()
    {
        return Players[playingAsPlayer];
    }

    void Update()
    {
        // When spawning all players if a spawn point is alread being used it will wait for one to be free. (fixes a collision overlap)
        if (numOfPlayersSpawned < numOfPlayers)
        {
            if (AnySpawnsFree())
            {
                SpawnPlayer();
            }
            else
            {
                Debug.Log("Waiting For Spawn...");
            }
        }


        // Switching between players.
        if (Input.GetKeyUp(KeyCode.F))
        {
            playingAsPlayer++;
        }
        if (playingAsPlayer > Players.Count - 1)
        {
            playingAsPlayer = 0;
        }
    }
}
