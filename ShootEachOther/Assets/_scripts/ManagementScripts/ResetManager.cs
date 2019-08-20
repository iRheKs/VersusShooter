using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace shootEachOther{
	public class ResetManager : MonoBehaviour {

		public PlayerSettings player1;
		public PlayerSettings player2;
		public ColumnGenerator columnGenerator;

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			
		}
        //Metodo de reinicio del juego, llama a los métodos de reinicio de cada objeto en escena
		public void resetGame(){
			foreach (GameObject s in GameObject.FindGameObjectsWithTag ("Shot")){
				if(s!=null)
					Destroy (s);
			}
			CanvasController.Instance.resetCanvas ();
			columnGenerator.resetColumns ();
			player1.resetPlayer ();
			player2.resetPlayer ();
		}
	}
}
