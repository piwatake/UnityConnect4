using UnityEngine;
using System.Collections;

public class NewGameButton : MonoBehaviour {



	public void startnewgame() {

		GameManager.instance.initGame ();

	}
}
