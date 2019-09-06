using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class risingWater : MonoBehaviour
{

	public float initialY = -10.0f;
	public float speed = 0.1f;
	public float stopHeight = -1.75f;

	private AudioSource source;
	public AudioClip platformDrop;

	// Use this for initialization
	void Start ()
	{
		transform.position.Set(0.0f, initialY, 0.0f);

		source = GetComponent<AudioSource>();

		enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(transform.position.y < stopHeight)
		{
			transform.Translate(new Vector3(0.0f, speed) * Time.deltaTime);
		}
	}
}
