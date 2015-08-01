using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;      

public class GameManager : MonoBehaviour {
	public static GameManager instance;
	
	public GameObject TilePrefab;
	public GameObject UserPlayerPrefab;
	//public GameObject AIPlayerPrefab;
	
	public int cols= 7;
	public int rows = 6;

	public List <List<Tile>> map = new List<List<Tile>>();
	public List <Tile> playeronepieces = new List<Tile>();
	public List <Tile> playertwopieces = new List<Tile>();
	List <Player> players = new List<Player>();
	public int currentPlayerIndex = 0;
	public bool EndGame = false;
	private Text levelText;
	
	void Awake() {
		instance = this;
	}
	
	// Use this for initialization
	void Start () {		
		generateMap();
		generatePlayers();
		levelText = GameObject.Find("levelText").GetComponent<Text>();

	}
	
	// Update is called once per frame
	void Update () {
		
		//players[currentPlayerIndex].TurnUpdate();
		if(currentPlayerIndex == 0){
			levelText.text = "Red's Turn";
			levelText.color = Color.red;
		} else if (currentPlayerIndex == 1 ) {
			levelText.text = "Black's Turn";
			levelText.color = Color.black;
		}
	}

	public void doTurn(){
		players[currentPlayerIndex].TurnUpdate();


	}

	
	public void nextTurn() {
		if (currentPlayerIndex +1< players.Count) {
			currentPlayerIndex++;


		} else {
			currentPlayerIndex = 0;
		}
	}
	

	
	void generateMap() {
		map = new List<List<Tile>>();
		for (int i = 0; i < cols; i++) {
			List <Tile> row = new List<Tile>();
			for (int j = 0; j < rows; j++) {
				Tile tile = ((GameObject)Instantiate(TilePrefab, new Vector3(i - Mathf.Floor(cols/2), -j + Mathf.Floor(rows/2), 0 ), Quaternion.Euler(new Vector3()))).GetComponent<Tile>();
				tile.gridPosition = new Vector2(i, j);
				row.Add (tile);
			}
			map.Add(row);
		}
	}
	
	void generatePlayers() {
		UserPlayer player;
		
		player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3(0 - Mathf.Floor(cols/2),1.5f, -0 + Mathf.Floor(rows/2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
		
		players.Add(player);
		
		player = ((GameObject)Instantiate(UserPlayerPrefab, new Vector3((cols-1) - Mathf.Floor(rows/2),1.5f, -(cols-1) + Mathf.Floor(rows/2)), Quaternion.Euler(new Vector3()))).GetComponent<UserPlayer>();
		
		players.Add(player);
		

		

	}
}
