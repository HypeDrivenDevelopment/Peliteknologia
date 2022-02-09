using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player;

    Renderer rend;

    Material playerNormal;
    Material playerCharge;
    Material playerChargeFull;
    Material playerSuper;

    private Rigidbody rb;
    private int count;
    private int speed;

    private int charge;
    private int maxCharge;

    Vector3 jump;
    Vector3 superJump;

    private string state;

    private void Start()
    {
        rend = GetComponent<Renderer>();

        state = "neutral";

        playerNormal = Resources.Load("Materials/Player", typeof(Material)) as Material;
        playerCharge = Resources.Load("Materials/PlayerCharge", typeof(Material)) as Material;
        playerChargeFull = Resources.Load("Materials/PlayerChargeFull", typeof(Material)) as Material;
        playerSuper = Resources.Load("Materials/PlayerSuper", typeof(Material)) as Material;

        rb = GetComponent<Rigidbody>();
        count = 0;
        speed = 10;

        charge = 0;
        maxCharge = 50;

        jump = new Vector3(0, 400, 0);
        superJump = new Vector3(0, 1000, 0);


    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        rb.AddForce(movement * speed);

        if (Input.GetKeyDown(KeyCode.Space) && state == "neutral")
        {
            rb.AddForce(jump);
            state = "isJumping";
        }

        if (rb.transform.position.y < 0)
        {
            restartGame();
        }

        if (state == "neutral" || state == "isCharged" || state == "isCharging")
        {
            if (Input.GetKeyUp(KeyCode.LeftControl))
            {
                if (state == "isCharged")
                {
                    rb.AddForce(superJump);
                    changeMaterial(playerSuper);

                    state = "isSuperJumping";
                }
                else if (state == "isCharging")
                {
                    changeMaterial(playerNormal);
                    state = "neutral";
                }

                charge = 0;
            }
            else if (Input.GetKeyDown(KeyCode.LeftControl))
            {
                state = "isCharging";
                changeMaterial(playerCharge);
            }
            else if (Input.GetKey(KeyCode.LeftControl) && state == "isCharging")
            {
                if (charge < maxCharge)
                {
                    charge++;
                }
                else
                {
                    state = "isCharged";
                    changeMaterial(playerChargeFull);
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (state == "isJumping")
            {
                state = "neutral";
            }
            else if (state == "isSuperJumping")
            {
                state = "neutral";
                changeMaterial(playerNormal);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;

            if (count >= 10)
            {
                restartGame();
            }
        }
    }

    void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void changeMaterial(Material material)
    {
        Material[] mats = rend.materials;
        mats[0] = material;
        rend.materials = mats;
    }

}
