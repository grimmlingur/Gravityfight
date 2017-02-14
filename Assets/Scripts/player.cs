using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    private class Node {
        public Node next;
        public GameObject asteroid;
    }
	public float speed = 5f;
	public float rotateSpeed = 3f;
    public Transform anchorPoint;
    private Rigidbody rb;
    private Node list;
    Vector3 originPoint;
	float invincibilityTime = 2f;
	float respawnTime       = 1f;
	int controls;

	

	// Use this for initialization
	void Start () {
		//Gets the controlScheme for the player. GetControlScheme returns either 0 or 1 based on where the 
		//player is in the gameworld. If 0 then the player uses asd to control and if 1 then he uses jkl.
		controls = GetControlScheme.getControls (gameObject.transform.position.x);
        rb=GetComponent<Rigidbody>();
		originPoint = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//gameObject.GetComponent<Rigidbody>().AddForce(gameObject.transform.forward * speed * Time.deltaTime);
		//gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
        

		gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
		if (controls == 0) {
			if (Input.GetKey (KeyCode.A)) {
				gameObject.transform.Rotate (new Vector3 (0, -rotateSpeed, 0));
			}
			if (Input.GetKey (KeyCode.D)) {
				gameObject.transform.Rotate (new Vector3 (0, rotateSpeed, 0));
			}
		} else {
			if (Input.GetKey (KeyCode.J)) {
				gameObject.transform.Rotate (new Vector3 (0, -rotateSpeed, 0));
			}
			if (Input.GetKey (KeyCode.L)) {
				gameObject.transform.Rotate (new Vector3 (0, rotateSpeed, 0));
			}
		}
        if(Input.GetKey(KeyCode.S)){
            //destroy all hinges in list and hinge on this object
            //may need to change the type of joint
            HingeJoint joint=GetComponent<HingeJoint>();
            Destroy(joint);
            while(list!=null)
            {
                Destroy(list.asteroid.GetComponent<HingeJoint>());
                list=list.next;
            }
            
        }
	}

    public void attach(GameObject other,float distbehind)
    { 
        other.tag=gameObject.tag;
        Debug.Log("In Attach");
        
        //if finger is null, then list is empty
        
        
        if(list==null)
        {//player has no asteroids

            //attach joint to ship
            //TODO: add chain of asteroids to belong to player

            //moving the asteroid behind the player
            Transform additiontransform=other.GetComponent<Transform>();
            additiontransform.position=gameObject.transform.position-gameObject.transform.forward*distbehind;
            //creating the joint
            gameObject.AddComponent<HingeJoint>();
            HingeJoint joint=GetComponent<HingeJoint>();
            joint.connectedBody=other.GetComponent<Rigidbody>();
            //gameObject.AddComponent<SpringJoint>();
            //SpringJoint joint=GetComponent<SpringJoint>();
            Debug.Log("We are about to connect the following bodies");
            Debug.Log(gameObject);
            Debug.Log(other);
            joint.connectedBody=other.GetComponent<Rigidbody>();
            joint.anchor=new Vector3(0,0,-distbehind);

            //asteroid is attached, now adding it to list
            list= new Node();
            list.asteroid=other;
            
        }
        else
        {
            //attach to tail
            //possibilities
            //a) remove frontmost hinge, insert new asteroid at front
            //and connect to ship and old frontmost asteroid
            //b)
            //move asteroid to back of tail, create new hinge
            Node finger=list;
            while(true)
            {
                if(finger.next==null)
                    break;
                finger=finger.next;
            }
            //finger points at backmost asteroid
            Transform backtransform=finger.asteroid.GetComponent<Transform>();
            Transform additiontransform=other.GetComponent<Transform>();
            additiontransform.position=backtransform.position-gameObject.transform.forward*distbehind;
            finger.asteroid.AddComponent<HingeJoint>();
            HingeJoint joint=finger.asteroid.GetComponent<HingeJoint>();
            joint.connectedBody=other.GetComponent<Rigidbody>();
            //gameObject.AddComponent<SpringJoint>();
            //SpringJoint joint=GetComponent<SpringJoint>();
            joint.anchor=new Vector3(0,0,-distbehind);
            //asteroid has been attached to back
            //finger still points at previous backmost asteroid, adding new
            //asteroid to list
            Node addition= new Node();
            addition.asteroid=other;
            finger.next=addition; 
      
        }
        //asteroid is attached, now adding it to list
        /*Node finger=null;
        if( list==null)
        {
        }
        else
        {
            finger=list;
            while(true)
            {
                if(finger.next==null)
                    break;
                finger=finger.next;
            }
        }
        */
        /*
        Debug.Log("In Attach");
        gameObject.AddComponent<ConfigurableJoint>();
        ConfigurableJoint joint = GetComponent<ConfigurableJoint>();
        //setting up angular limit
        SoftJointLimit turnlimit = new SoftJointLimit();
        turnlimit.limit=30;
        turnlimit.bounciness=0;
        turnlimit.contactDistance=5;
        joint.lowAngularXLimit=turnlimit;
        joint.targetRotation=new Quaternion(0,0,0,0);
        joint.angularXMotion=ConfigurableJointMotion.Limited;
        //setting up distance limit
        SoftJointLimit distlimit = new SoftJointLimit();
        distlimit.limit=1;
        distlimit.bounciness=0;
        distlimit.contactDistance=5;
        joint.linearLimit=distlimit;
        joint.zMotion=ConfigurableJointMotion.Limited;
        */
    }
    
	public void respawn(){
		StartCoroutine(respawnCoroutine());
	}

	IEnumerator respawnCoroutine()
	{
		yield return new WaitForSeconds(respawnTime);
		gameObject.transform.position = originPoint;
	}
}
