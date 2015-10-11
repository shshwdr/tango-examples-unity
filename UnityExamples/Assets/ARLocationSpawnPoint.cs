using UnityEngine;
using System.Collections;

public class ARLocationSpawnPoint : MonoBehaviour {
	public float health;
	public float maxhealth;
	float angryValue;
	public float spawnValue = 3;
	bool isDying;
	Animator animator;
	public GameObject damageNumber;

	void Start () {
		health = maxhealth;
		isDying = false;
		animator = GetComponent<Animator>() as Animator;
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
		Instantiate (damageNumber, transform.position, transform.rotation);
	}
	public void OnGUI()
	{
		
	}
	// Update is called once per frame
	void Update () {
		angryValue += Time.deltaTime;
		if (angryValue >= spawnValue) {
			spawnEnemy();
			spawnValue = 0;

		}
		
	}

	IEnumerator spawnEnemy(){
		animator.SetBool ("spawnStart",true);
		yield return new WaitForSeconds(2);
		animator.SetBool ("spawnStart",false);

	}
	void die(){
		isDying = true;
		//animator.SetBool ("Die", true);
		GetComponent<MeshCollider> ().enabled = false;
		iTween.FadeTo(gameObject,0, 10);
		Destroy (gameObject,10);
		
	}
}
