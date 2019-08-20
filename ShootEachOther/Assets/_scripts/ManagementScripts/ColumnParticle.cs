using UnityEngine;
using System.Collections;

public class ColumnParticle : MonoBehaviour {

	public ParticleSystem explodeParticle;
	public MeshRenderer myMesh;
	public BoxCollider myCollider;
    //Detecta cuando ha sido golpeado, se desactiva el collider y el mesh para que deje de verse. Tambien activa la particula de explosion
	void OnCollisionEnter(Collision other){
		if(other.gameObject.tag == "Shot"){
			explodeParticle.Play ();
			myCollider.enabled = false;
			myMesh.enabled = false;
		}
	}

}
