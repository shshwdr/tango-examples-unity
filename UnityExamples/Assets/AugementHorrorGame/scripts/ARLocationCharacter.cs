using UnityEngine;
using System.Collections;

public class ARLocationCharacter : MonoBehaviour {
	public float health;
	public float maxhealth;
	bool isDying;
	Animator animator;
	public GameObject damageNumber;
	// Use this for initialization
	void Start () {
		health = maxhealth;
		isDying = false;
		animator = GetComponent<Animator>() as Animator;
		//GetComponent<Rigidbody>().velocity = (transform. forward * -10 );
	}

	public void beDamaged(int damageHealth)
	{

		health -= damageHealth;
		if (health <= 0) {
			die();
			return;
		}
		animator.SetTrigger ("beHit");
		//animator.SetBool ("beHit", true);
		damageNumber.GetComponent<TextMesh> ().text = damageHealth+"";
		Vector3 up = new Vector3(0,1,0);
		Vector3 forward;

			Vector3 right = Vector3.Cross(up, Camera.main.transform.forward).normalized;
			forward = Vector3.Cross(right, up).normalized;

		Instantiate (damageNumber, transform.position, Quaternion.LookRotation(forward));
	}
	public void OnGUI()
	{

	}
	// Update is called once per frame
	void Update () {
		//transform.position += transform.forward * Time.deltaTime*0.02f;
		GetComponent<Rigidbody> ().AddForce (transform.forward*7);
	}
	void die(){
		isDying = true;
		animator.SetBool ("Die", true);
		//GetComponent<CapsuleCollider> ().enabled = false;
		iTween.FadeTo(gameObject,0, 10);
		Destroy (gameObject,10);

	}
}
