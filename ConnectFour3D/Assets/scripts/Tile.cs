using UnityEngine;
using System.Collections;
using UnityEngine.UI;   

public class Tile : MonoBehaviour {
	
	public Vector2 gridPosition = Vector2.zero;
	public int player = 0;

	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseEnter() {
		transform.GetComponent<Renderer>().material.color = Color.blue;
		
		//Debug.Log("my position is (" + gridPosition.x + "," + gridPosition.y);
	}
	
	void OnMouseExit() {
		if (player == 1) {
			transform.GetComponent<Renderer> ().material.color = Color.red;
		} else if (player == 2) {
			transform.GetComponent<Renderer> ().material.color = Color.black;
		} else {
			transform.GetComponent<Renderer>().material.color = Color.white;
		}

	}
	
	
	void OnMouseDown() {

		if (GameManager.instance.EndGame != true) {

			

			if (this.player == 0 && isValidMove ()) {

				if (GameManager.instance.currentPlayerIndex == 0) {
					player = 1;
				} else if (GameManager.instance.currentPlayerIndex == 1) {
					player = 2;
				}

				if (this.player == 1) {
					GameManager.instance.playeronepieces.Add (this);
				} else {
					GameManager.instance.playertwopieces.Add (this);
					
				}




				//check for win condition for next turn handoff. 
				if (this.player == 1) {
					foreach (Tile t in GameManager.instance.playeronepieces) {
						if (checkIfWin (t, 1)) {
							//Debug.Log ("PLAYER ONE IS A WINNER!11!!2!");
							GameManager.instance.EndGame = true;
							Text winText;
							winText = GameObject.Find ("Text").GetComponent<Text> ();
							winText.text = "PLAYER RED IS A WINNER!11!!2!";
							GameObject.Find ("Text").GetComponent<CanvasGroup> ().alpha = 1;

							GameObject.Find ("NGButton").GetComponent<CanvasGroup> ().alpha = 1;
							//GameObject.Find ("NGButton").GetComponent<CanvasGroup> ().interactable = true;

							GameObject.Find ("levelText").GetComponent<CanvasGroup> ().alpha = 0;

							GameManager.instance.EndGame = true;

							break;
						}
					}

				} else if (this.player == 0){
					//Debug.Log ("else...");

					foreach (Tile t in GameManager.instance.playertwopieces) {
						if (checkIfWin (t, 2)) {
							//Debug.Log ("PLAYER TWO IS A WINNER!11!!2!");
							GameManager.instance.EndGame = true;
							Text winText;
							winText = GameObject.Find ("Text").GetComponent<Text> ();
							winText.text = "PLAYER BLACK IS A WINNER!11!!2!";
							GameObject.Find ("Text").GetComponent<CanvasGroup> ().alpha = 1;
							GameObject.Find ("NGButton").GetComponent<CanvasGroup> ().alpha = 1;
							//GameObject.Find ("NGButton").GetComponent<CanvasGroup> ().interactable = true;
							GameObject.Find ("levelText").GetComponent<CanvasGroup> ().alpha = 0;

							GameManager.instance.EndGame = true;

							break;
						}
					}

				}



				GameManager.instance.doTurn ();

			}







			//Debug.Log (GameManager.instance.currentPlayerIndex + " " + this.gridPosition.x + ", " + this.gridPosition.y);


		}

	}



	bool isValidMove(){
		
		if ( ((int)this.gridPosition.y ) == 5 || GameManager.instance.map [(int)this.gridPosition.x] [(int)this.gridPosition.y + 1].player == 1  || GameManager.instance.map [(int)this.gridPosition.x] [(int)this.gridPosition.y + 1].player == 2 ) {
			return true;
		}
		else
		{
			return false; 
		}
		
		
		
	}



	bool checkIfWin(Tile space, int player ){

		//like forward slash (/) versus backwards slash (\), define forwards diagonal as diagonal from top right to bottom left
		//and backwards diagonal as top left to bottom right. 
		return checkFwdDiag(space, player) || checkBwdDiag(space, player) || checkVert(space, player) || checkHorz(space, player);


	}

		bool checkFwdDiag(Tile space, int playerparam){

			Vector2 temp = space.gridPosition;
			temp.x = temp.x + 1;
			temp.y = temp.y - 1;

			//first one guaranteed.
			int four = 1;
			while(onBoard(temp)){


			if(this.player == playerparam){
				if(GameManager.instance.map[(int)temp.x][(int)temp.y].player == playerparam ){
					four++;
				} else {
					break;
				}
			}


				if(four == 4){
					return true;
				}

				temp.x = temp.x + 1;
				temp.y = temp.y - 1;
				
				

			}

			return false;

		}

	bool checkBwdDiag(Tile space, int playerparam){
		
		Vector2 temp = space.gridPosition;
		temp.x = temp.x - 1;
		temp.y = temp.y - 1;
		
		//first one guaranteed.
		int four = 1;
		while(onBoard(temp)){
			
			
			if(this.player == playerparam){
				if(GameManager.instance.map[(int)temp.x][(int)temp.y].player == playerparam ){
					four++;
				} else {
					break;
				}
			}
			
			
			if(four == 4){
				return true;
			}
			
			temp.x = temp.x - 1;
			temp.y = temp.y - 1;
			
			
			
		}
		
		return false;
		
	}


	bool checkVert(Tile space, int playerparam){
		
		Vector2 temp = space.gridPosition;
		temp.y = temp.y - 1;
		
		//first one guaranteed.
		int four = 1;
		while(onBoard(temp)){
			
			
			if(this.player == playerparam){
				if(GameManager.instance.map[(int)temp.x][(int)temp.y].player == playerparam ){
					four++;
				} else {
					break;
				}
			}
			
			
			if(four == 4){
				return true;
			}

			temp.y = temp.y - 1;
			
			
			
		}
		
		return false;
		
	}


	bool checkHorz(Tile space, int playerparam){
		
		Vector2 temp = space.gridPosition;
		temp.x = temp.x + 1;
		
		//first one guaranteed.
		int four = 1;
		while(onBoard(temp)){
			
			
			if(this.player == playerparam){
				if(GameManager.instance.map[(int)temp.x][(int)temp.y].player == playerparam ){
					four++;
				} else {
					break;
				}
			}
			
			
			if(four == 4){
				return true;
			}
			
			temp.x = temp.x + 1;
			
			

		}
		
		return false;
		
	}


	bool onBoard(Vector2 test){
				
			if(test.x>=0&&test.x<=6&&test.y>=0&&test.y<=5){
				return true;
			}
			return false;

	}


	
	
	
}
