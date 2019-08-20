using UnityEngine;
using System.Collections;
using System.Collections.Generic;
namespace shootEachOther{
	[System.Serializable]
	public class PlayerController{

		public enum BarrierPositions {top,bottom,left,right,moving};
		[HideInInspector]
		public BarrierPositions barrier = BarrierPositions.moving;

		[Header("Player Settings")]
		public PlayerSettings thisPlayer;

		[Header("Controller Settings")]

		public KeyCode up;
		public KeyCode down;
		public KeyCode left;
		public KeyCode right;
		public KeyCode shot;

        //Metodo que gestiona el control del personaje
		public void control(){

			if (Input.GetKey (up) && this.barrier != BarrierPositions.top) {
				this.thisPlayer.myTransform.Translate (thisPlayer.speed * Time.deltaTime, 0, 0);
			}
			if(Input.GetKey (down) && this.barrier != BarrierPositions.bottom){
				this.thisPlayer.myTransform.Translate (-thisPlayer.speed * Time.deltaTime, 0, 0);
			}
			if(Input.GetKey (left) && this.barrier != BarrierPositions.left){
				this.thisPlayer.myTransform.Translate (0, 0, thisPlayer.speed * Time.deltaTime);
			}
			if(Input.GetKey (right) && this.barrier != BarrierPositions.right){
				this.thisPlayer.myTransform.Translate (0, 0, -thisPlayer.speed * Time.deltaTime);
			}
			if (Input.GetKeyDown (shot)){
                //cuando dispara instancia una bala que esta guardada como prefab y le añade una fuerza
				this.thisPlayer.bullet = (GameObject)GameObject.Instantiate (Resources.Load ("Prefabs/Shot"),thisPlayer.bulletDir, this.thisPlayer.transform.localRotation);
				this.thisPlayer.bullet.GetComponent <Rigidbody>().AddForce (thisPlayer.bulletRot*thisPlayer.bulletSpeed,ForceMode.Impulse);
			}
		
		}
	}
}