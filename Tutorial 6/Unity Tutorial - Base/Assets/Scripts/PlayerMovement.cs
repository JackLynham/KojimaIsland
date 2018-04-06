using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public AudioClip shoutingClip;
    public float speedDampTime = 0.01f;
    public float sensitivityX = 1.0f;

    private Animator anim;
    private HashIDs hash;
    private float elapsedtime = 0;
    [Range(0f, 0.1f)]
    public float Speed;
    [Range(0f, 0.5f)]
    public float rotateSpeed;
    [Range(0f, 0.5f)]
    public float jumpSpeed;


    void Awake()
    {
        anim = GetComponent<Animator>();
        anim.SetLayerWeight(1, 1f);
        hash = GameObject.FindGameObjectWithTag("GameController").GetComponent<HashIDs>();

        Quaternion fixRotation = Quaternion.Euler(0f, -90f, 0f);
        Rigidbody ourBody = this.GetComponent<Rigidbody>();
        ourBody.MoveRotation(fixRotation);
    }

    void FixedUpdate()
    {
        float v = Input.GetAxis("Vertical");
        bool sneak = Input.GetButton("Sneak");
        float mouseX = Input.GetAxis("Mouse X");

        Rotating(mouseX);
        MovementManager();
        elapsedtime += Time.deltaTime;
      
    }

    void Update()
    {

        bool shout = Input.GetButtonDown("Attract");
        anim.SetBool(hash.shoutingbool, shout);
        AudioManagement(shout);

    }

    void MovementManager()
    {
        // Walking 
        if (Input.GetAxis("Vertical") > 0)
        {
            // forward
            transform.Translate(Vector3.forward *Speed);

            anim.SetFloat(hash.speedFloat, 1.5f, speedDampTime, Time.deltaTime);
            anim.SetBool("Backward", false);
        }

        //Backwards
        if (Input.GetAxis("Vertical") < 0)
        {
            transform.Translate(Vector3.back* Speed);

            anim.SetFloat(hash.speedFloat, -1.5f, speedDampTime, Time.deltaTime);
            anim.SetBool("Backward", true);
        }
        //Static 
        if (Input.GetAxis("Vertical") == 0)
        {
            anim.SetFloat(hash.speedFloat, 0, speedDampTime, Time.deltaTime);
            anim.SetBool("Backward", false);
        }
        //Turning Left 
        if (Input.GetAxis("Horizontal") < 0)
        {
            transform.Rotate(Vector3.down * rotateSpeed);
        }

        //Turning Right
        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.Rotate(Vector3.up * rotateSpeed);
        }
        if(Input.GetKeyDown ("space"))
        {
            transform.Translate(Vector3.up * 60 * Time.deltaTime, Space.World);
        }
   
   }

    //Rotating Camerea
        void Rotating(float mouseXInput)
    {
        Rigidbody ourBody = this.GetComponent<Rigidbody>();

        Quaternion deltaRotation = Quaternion.Euler(0f, (Input.GetAxis("Mouse X") * sensitivityX), 0f);

        ourBody.MoveRotation(ourBody.rotation * deltaRotation);
    }

    void AudioManagement(bool shout)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
        {
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().pitch = 0.27f;
                GetComponent<AudioSource>().Play();
            }
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }

        if (shout)
        {
            AudioSource.PlayClipAtPoint(shoutingClip, transform.position);
        }
    }

}
