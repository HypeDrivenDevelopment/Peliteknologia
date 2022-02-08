using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Map : MonoBehaviour {

	public GameObject hexPrefab;
    public GameObject child;

	// Size of map in terms of number of hexes
	int width = 64;
	int height = 40;

	float xOffset = 0.9f;
	float zOffset = 0.78f;

    //Flag that tells if previous hexagon has been impassable terrain.
    bool flag;

    //Type of terrain.
    string maasto;


    // Use this for initialization
    void Start () {
        //Randomizing object for rng.
        System.Random rnd = new System.Random();

        for (int x = 0; x < width; x++) {
            flag = false;
			for (int z = 0; z < height; z++) {

				float xPos = x * xOffset;

				// Are we on an odd row?
				if (z % 2 == 1) {
					xPos += xOffset/2f;
				}
					
				GameObject hex_go = (GameObject)Instantiate (hexPrefab, new Vector3(xPos, 0 , z * zOffset), Quaternion.identity );

                //Child element of the generated gameobject.
                child = hex_go.gameObject.transform.GetChild(0).gameObject;

                //Two rng-numbers (1 or 2).
                int luku = rnd.Next(1, 3);
                int luku2 = rnd.Next(1, 3);

                //50% chance that terrain is passable and 50% that it isn't. Impassable terrain is rock or lava (50/50 too)
                //Color of the tile is changed as a visualization.
                if (luku % 2 == 0)
                {
                    //If previous tile was impassable, next one can't be. This is to make sure that you can get everywhere on the board.
                    if (flag == false)
                    {
                        if (luku2 % 2 == 0)
                        {
                            child.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.red);
                            maasto = "laava";
                        }
                        else
                        {
                            child.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.black);
                            maasto = "kivi";
                        }
                        flag = true;
                    }
                    else
                    {
                        child.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                        maasto = "ruoho";
                        flag = false;
                    }
                }
                else
                {
                    child.GetComponent<MeshRenderer>().material.SetColor("_Color", Color.green);
                    maasto = "ruoho";
                }

                // Name the hex -gameobjects. Index 0,0 is at lower left corner. Add type of terrain to name.
                hex_go.name = "Hex_" + x + "_" + z + "_" + maasto;

                //Name the child as terrain.
                child.name = maasto;

                //Tagging the gameobject.
                child.tag = maasto;

                hex_go.transform.SetParent (this.transform);

            }

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
