using UnityEngine;
using System.Collections;
namespace shootEachOther{
	public class ShotTimer : MonoBehaviour {


		public float despawnTime;
        //Cuando se activa el GameObject se pone el tiempo que tarda en desaparecer, en segundos
		void OnEnable(){

			this.despawnTime = 5.0f;

		}
		// Va restando segundos con el tiempo del juego y cuando llega a 0 se elimina de la escena
		void Update () {

			this.despawnTime -= Time.deltaTime;

			if(despawnTime <= 0.0f){
				Destroy (this.gameObject);
			}

		}
        //Cuando colisiona, si es un jugador o una columna se elimina de la escena
		void OnCollisionEnter(Collision other){
			if(other.gameObject.tag.Contains ("Player") || other.gameObject.CompareTag ("Columna"))
				Destroy (this.gameObject);
		}
	}
}

