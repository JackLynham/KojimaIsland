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
    private bool noBackMov = true;

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
        MovementManager(v, sneak);
        elapsedtime += Time.deltaTime;
      
    }

    void Update()
    {

        bool shout = Input.GetButtonDown("Attract");
        anim.SetBool(hash.shoutingbool, shout);
        AudioManagement(shout);

    }

    void MovementManager(float vertical, bool sneaking)
    {
        anim.SetBool(hash.sneakingbool, sneaking);

        if (vertical > 0)
        {
            anim.SetFloat(hash.speedFloat, 1.5f, speedDampTime, Time.deltaTime);
            anim.SetBool("Backward", false);
            noBackMov = true;
        }

        if (vertical < 0)
        {
            if(noBackMov == true)
            {
                elapsedtime = 0;
                noBackMov = false; 
            }
            anim.SetFloat(hash.speedFloat, -1.5f, speedDampTime, Time.deltaTime);
            anim.SetBool("Backward", true);

            Rigidbody ourbody = this.GetComponent<Rigidbody>();

            float movement = Mathf.Lerp(0f, 0.0f, -0.025f);
            Vector3 moveback = new Vector3(0.0f, 0.0f, movement);
            moveback = ourbody.transform.TransformDirection(moveback);
            ourbody.transform.position += moveback;

        }

        if (vertical == 0)
        {
            anim.SetFloat(hash.speedFloat, 0.09f);
            anim.SetBool("Backward", false);
            noBackMov = true;
        }
    
    }

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
