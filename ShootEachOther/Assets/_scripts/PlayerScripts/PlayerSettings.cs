using UnityEngine;
using System.Collections;


namespace shootEachOther{
	
	public class PlayerSettings : MonoBehaviour {

		[HideInInspector]
		public Vector3 bulletDir,bulletRot;

		[HideInInspector]
		public GameObject bullet;

		[HideInInspector]
		public Transform myTransform;
		public Vector3 startPosition;

		[HideInInspector]
		public bool newGame;

		[Header("Player Settings")]

		public GameObject target;
		public float speed;

		[Header("Player Controller")]

		public PlayerController pc = new PlayerController();

		[Header("Life Parameters")]

		public int life;
		public int dmgTakenPerShot;

		[Header("Bullet Parameters")]
		public float bulletSpeed;

		[Header("Particles")]

		public ParticleSystem winParticle;
		public ParticleSystem hitParticle;

		void Awake(){
			this.myTransform = this.gameObject.GetComponent <Transform>();
			this.startPosition = myTransform.position;
		}

		// Update is called once per frame
		void Update () {

			this.pc.control();

			this.myTransform.LookAt (this.target.transform);
			this.bulletRot = this.myTransform.forward;

			if (this.gameObject.CompareTag ("Player2")){
				this.bulletDir = this.myTransform.localPosition + new Vector3 (9.0f, 22.5f, 0);
			}else {
				this.bulletDir = this.myTransform.localPosition - new Vector3 (9.0f, -22.5f, 0);
			}

		}

        //Deteccion de colisiones cuando detecta un disparo se quita vida y actualiza el texto en pantalla. Tambien activa las particulas de daño
        //finalmente pone el gameObject a inactivo
		void OnCollisionEnter(Collision other){
			if(other.gameObject.CompareTag ("Shot")){

				this.life -= this.dmgTakenPerShot;
				this.hitParticle.Play ();
				if (this.life != 0)
					CanvasController.Instance.OnHit (this.life,this.gameObject.tag);

				if(this.life <= 0){
					if(this.gameObject.tag == "Player1"){
						this.winParticle.startColor = Color.cyan;
						CanvasController.Instance.OnWin (this.life, "Player 2");
					}else if(this.gameObject.tag == "Player2"){
						this.winParticle.startColor = Color.red;
						CanvasController.Instance.OnWin (this.life, "Player 1");
					}
					this.winParticle.Play ();
					this.gameObject.SetActive (false);
				}

			}
		}
        //Deteccion de colisiones con las paredes para no salirse del mapa
		void OnTriggerEnter(Collider other){
			if(other.gameObject.tag.Contains ("Bot")){
				pc.barrier = PlayerController.BarrierPositions.bottom;
			}
			if(other.gameObject.tag.Contains ("Top")){
				pc.barrier = PlayerController.BarrierPositions.top;
			}
			if(other.gameObject.tag.Contains ("Left")){
				pc.barrier = PlayerController.BarrierPositions.left;
			}
			if(other.gameObject.tag.Contains ("Right")){
				pc.barrier = PlayerController.BarrierPositions.right;
			}
			if(!other.gameObject.tag.Contains ("Pared")){
				pc.barrier = PlayerController.BarrierPositions.moving;
			}
		}
        //Metodo de reinicio del jugador
		public void resetPlayer(){
			this.winParticle.Stop ();
			this.gameObject.SetActive (true);
			this.myTransform.position = startPosition;
			this.life = 100;
		}

	}}
