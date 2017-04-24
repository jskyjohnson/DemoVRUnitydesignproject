using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        this.gameObject.transform.rotation = Quaternion.identity;

        //ray starts at player position and points down
        Ray ray = new Ray(transform.position, Vector3.down);

        //will store info of successful ray cast
        RaycastHit hitInfo;

        //terrain should have mesh collider and be on custom terrain 
        //layer so we don't hit other objects with our raycast
        LayerMask layer = 1 << LayerMask.NameToLayer("World");

        //cast ray
        if (Physics.Raycast(ray, out hitInfo, layer)) {
            //get where on the z axis our raycast hit the ground
            float z = hitInfo.point.z;
            Debug.Log(hitInfo.point);
            //copy current position into temporary container
            Vector3 pos = transform.position;

            //change z to where on the z axis our raycast hit the ground
            pos.z = z;

            //override our position with the new adjusted position.
            transform.position = pos;
        }
    }
}
