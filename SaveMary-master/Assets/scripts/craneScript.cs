using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class craneScript : MonoBehaviour {

	public float speed = 0.1f;
	public float limit = 4.0f;
	public AudioClip craneSound;

	private AudioSource source;
	private bool win = false;

	// Use this for initialization
	void Start ()
	{
		source = GetComponent<AudioSource>();
        source.enabled = false;
		enabled = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
			this.transform.Translate(new Vector3(-speed, 0.0f, 0.0f) * Time.deltaTime);
			if(transform.position.x < -limit && !win)
			{
				transform.Translate(new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime);
                
            }
			if(!win)
			{
	            source.enabled = true;
	            source.loop = true;
			}
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
			this.transform.Translate(new Vector3(speed, 0.0f, 0.0f) * Time.deltaTime);
			if(transform.position.x > limit && !win)
			{
				transform.Translate(new Vector3(-speed, 0.0f, 0.0f) * Time.deltaTime);
                
            }
			if(!win)
			{
	            source.enabled = true;
	            source.loop = true;
			}
        }
        if(Input.GetKey(KeyCode.RightArrow) == false && Input.GetKey(KeyCode.LeftArrow) == false)
        {
            source.enabled = false;
            source.loop = false;
        }
    }

	void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.name == "Mary")
		{
			win = true;
		}
	}
}
