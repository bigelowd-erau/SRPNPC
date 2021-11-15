using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    public GameObject SHealthNPC;
    public GameObject NHHealthNPC;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (GameObject npc in  GameObject.FindGameObjectsWithTag("NPC"))
                npc.GetComponent<NPC>().TakeDamage(10);
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            Instantiate(NHHealthNPC);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            Instantiate(SHealthNPC);
        }
    }

    void OnGUI()
    {
        GUI.color = Color.black;
        GUI.Label(new Rect(10, 10, 500, 20), "Press S to turn spawn standard health NPC");
        GUI.Label(new Rect(10, 30, 500, 20), "Press H to turn spawn number of hits health NPC");
        GUI.Label(new Rect(10, 50, 500, 20), "Press Space to to do some damage");
    }
}
