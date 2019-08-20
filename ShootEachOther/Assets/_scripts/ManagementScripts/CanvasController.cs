using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace shootEachOther{
	public class CanvasController : MonoBehaviour {

		public static CanvasController Instance { get; set;}

		[Header("Textos")]
		[Space(10)]

		public Text winner;
		public Text life1;
		public Text life2;


		// Use this for initialization
		void Start () {
			winner.gameObject.SetActive (false);
			life1.text = "Player 1: 100";
			life2.text = "Player 2: 100";
			Instance = this;
		}
		
		// Update is called once per frame
		void Update () {
		
		}
        //Cambia el texto que marca la vida
		public void OnHit(int life,string tag){
			if (tag == "Player1"){
				life1.text = "Player 1: " + life.ToString ();
			}else {
				life2.text = "Player 2: " + life.ToString ();
			}
		}
        //Activa el texto de victoria y le pone el color del jugador que ha ganado
		public void OnWin(int life, string tag){
			if (tag == "Player 1"){
				life2.text = "Player 2: " + life.ToString ();
				winner.color = Color.red;
			}
			else{
				life1.text = "Player 1: " + life.ToString ();
				winner.color = Color.cyan;
			}
				
			winner.text = tag + " Wins";

			winner.gameObject.SetActive (true);
		}
        //Metodo que reinicia el Canvas a su estado inicial
		public void resetCanvas(){
			winner.gameObject.SetActive (false);
			life1.text = "Player 1: 100";
			life2.text = "Player 2: 100";
		}

	}
}
