using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public GameObject SHealthNPC;
    public GameObject NHHealthNPC;
    public GameObject BHealthNPC;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (GameObject npc in  GameObject.FindGameObjectsWithTag("NPC"))
                npc.GetComponent<NPC>().ChangeHealth(-10);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            foreach (GameObject npc in GameObject.FindGameObjectsWithTag("NPC"))
                npc.GetComponent<NPC>().ChangeHealth(10);
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            Instantiate(NHHealthNPC);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(SHealthNPC);
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            Instantiate(BHealthNPC);
        }
    }

    void OnGUI()
    {
        GUI.color = Color.black;
        GUI.Label(new Rect(10, 10, 500, 20), "Press S to turn spawn standard health NPC");
        GUI.Label(new Rect(10, 30, 500, 20), "Press N to turn spawn number of hits health NPC");
        GUI.Label(new Rect(10, 50, 500, 20), "Press B to turn spawn bleed health NPC");
        GUI.Label(new Rect(10, 70, 500, 20), "Press Space to to do some damage");
        GUI.Label(new Rect(10, 90, 500, 20), "Press H to to heal some health");
    }
}
