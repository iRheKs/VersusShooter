using UnityEngine;
using System.Collections;
namespace shootEachOther{
	public class ColumnGenerator : MonoBehaviour {


		private Vector2[] posColmn;
		private Transform myTransform;

		[Header("Column Settings")]
		[Space(9)]

		public int maxColumns; 
		public float minDistance;

		[Header("Spawn Space Settings")]
		[Space(9)]
		[Tooltip("From Positive to Negative Value")]
		public float zMax;
		[Tooltip("From Positive to Negative Value")]
		public float xMax;

		void Awake(){
			myTransform = GetComponent <Transform>();
			posColmn = new Vector2[maxColumns];
			//Debug.Log ("Vector creado con: " + maxColumns + " columnas");
		}
		// Use this for initialization
		void Start () {
			spawnColumn ();
		}

		// Update is called once per frame
		void Update () {

		}
        //Llama a la funcion de la generacion de las posiciones de la columna, y con dichas posiciones instancia las columnas
        //Tambien pone las columnas como hijas del columnGenerator
		private void spawnColumn(){
			orderColumns ();
			float x, y;

			for (int i = 0; i < maxColumns; i++){

				x = posColmn [i].x;
				y = posColmn [i].y;
				GameObject nuevaColumna;
				nuevaColumna = (GameObject)Instantiate(Resources.Load ("Prefabs/Column"), new Vector3 (x, 0, y), Quaternion.identity);
				nuevaColumna.transform.SetParent (myTransform);
			}

		}
        //Metodo de ordenacion de columnas el cual pone una posicion aleatoria y comprueba con el resto de columnas que la distancia sea mayor a la distancia minima
        //cuando ocurre guarda esa posicion válida. 
		private void orderColumns(){

			float xPos, yPos, distance;
			Vector2 pos;

			for(int iteratorColumn = 0; iteratorColumn < maxColumns; iteratorColumn++) {
				//Debug.Log ("Iteracion " + iteratorColumn);

				if(iteratorColumn > 0){
					int i;
					do{
						distance = minDistance;
						xPos = Random.Range (-xMax,xMax);
						yPos = Random.Range (-zMax,zMax);
						pos = new Vector2(xPos,yPos);

						for (i = 0; i < iteratorColumn && (distance >= minDistance); i++) {
							distance = Vector2.Distance (pos, posColmn [i]);
							//Debug.Log("[Iterator: " + iteratorColumn + "; i: "+ i + "; Distancia: " + distance+ "]");
						}

					}while(i < iteratorColumn);
					posColmn[iteratorColumn] = pos;

				}else{
					xPos = Random.Range (-xMax,xMax);
					yPos = Random.Range (-zMax,zMax);
					pos = new Vector2(xPos,yPos);
					posColmn[iteratorColumn] = pos;
				}
			}

		}
        //Metodo de reinicio de las columnas que borra todas las existentes y las vuelve a generar
		public void resetColumns(){
			for (int i = 0; i < myTransform.childCount; i++){
				Destroy (myTransform.GetChild (i).gameObject);
			}
			spawnColumn ();
		}
	}
}

