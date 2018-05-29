using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public enum CameraMode
    {
        StayPut = 0,
        FollowPlayer = 1,
        HandHeldCamera = 2,
    }

    public CameraMode cameraMode = CameraMode.StayPut;
    public float HandHeldRadius = 5f;
    public float waitForHendHeldFollow = 0.1f; //sec
    public string ____________________________;
    private GameObject player;
    private Vector3 cameraOffset;

	// Use this for initialization
	void Start () 
    {
        player=GameObject.FindGameObjectWithTag("Player");
        cameraOffset = this.gameObject.transform.position - player.transform.position;
	}

    IEnumerable HandHeldFollow()
    {
        yield return new WaitForSeconds(1f);
	    Vector3 newPosCandidate = this.transform.position = player.transform.position;
		Vector3 rnd = UnityEngine.Random.insideUnitCircle * HandHeldRadius;
		this.transform.position = newPosCandidate - new Vector3(rnd.x, rnd.y, 0);
    }
	
	// Update is called once per frame
	void Update () 
    {
		switch (cameraMode)
        {
            case CameraMode.StayPut:
                this.transform.position = player.transform.position + cameraOffset;
                break;
                 
            case CameraMode.FollowPlayer:
                StartCoroutine("HandHeldFollow");
                break;

            case CameraMode.HandHeldCamera:
                break;

            default:
                break;
        }
	}
}
