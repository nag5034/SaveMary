using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformBehavior : MonoBehaviour
{
	public float fallSpeed = 0.1f;
	public float craneY = 3.66f;
	public bool played = false;
	public AudioClip platformDrop;

	private float height;
	private bool isOnCrane;
	private bool isSettled;
	private Transform cranePos;
	private List<GameObject> platformList;
	private AudioSource source;

    // Use this for initialization
    void Start ()
	{
		isOnCrane = true;
		isSettled = false;

		height = GetComponent<Transform>().lossyScale.y;

		cranePos = GameObject.Find("crane").GetComponent<Transform>();

		platformList = GameObject.Find("Mary").GetComponent<maryRunning>().platformList;

		source = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(tag == "onCrane")
		{
			Vector3 newPosition = new Vector3(cranePos.position.x, craneY - (height / 2.0f), 2.0f);
			transform.position = newPosition;

			if(Input.GetKeyDown(KeyCode.Space))
			{
				isOnCrane = false;
				tag = "falling";
			}
		}

		if(!isOnCrane && !isSettled)
		{
			transform.Translate(new Vector3(0.0f, -fallSpeed, 0.0f) * Time.deltaTime);
		}
        if(isSettled)
        {
			if(!played)
			{
				source.PlayOneShot(platformDrop);
				played = true;
			}
        }
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if(!isSettled && !isOnCrane && (col.gameObject.tag == "resting" || col.gameObject.tag == "ground"))
		{
			GameObject clone = Instantiate(gameObject, new Vector3(0.0f, craneY - (height / 2.0f), 0.0f), Quaternion.identity, GameObject.Find("PlatformList").transform);
			clone.name = "platform";
			clone.tag = "onCrane";
			isSettled = true;
            gameObject.tag = "resting";
			platformList.Add(gameObject);
        }
    }
}
