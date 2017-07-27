using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;

	private enum States {
		cell,
		mirror,
		sheets_0,
		lock_0,
		cell_mirror,
		sheets_1,
		lock_1,
		corridor_0,
		stairs_0,
		floor,
		closet_door,
		stairs_1,
		corridor_1,
		in_closet,
		stairs_2,
		corridor_2,
		corridor_3,
		corridor_subzero,
		courtyard}
	;

	private States myState;

	// Use this for initialization
	void Start() {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update() {
		print(myState);

		switch (myState) {
			case States.cell:
				cell();
				break;
			case States.mirror:
				mirror();
				break;
			case States.sheets_0:
				sheets_0();
				break;
			case States.lock_0:
				lock_0();
				break;
			case States.cell_mirror:
				cell_mirror();
				break;
			case States.sheets_1:
				sheets_1();
				break;
			case States.lock_1:
				lock_1();
				break;
			case States.corridor_subzero:
				corridor_subzero();
				break;
			case States.corridor_0:
				corridor_0();
				break;
			case States.floor:
				floor();
				break;
			case States.corridor_1:
				corridor_1();
				break;
			case States.corridor_2:
				corridor_2();
				break;
			case States.corridor_3:
				corridor_3();
				break;
			case States.stairs_0:
				stairs_0();
				break;
			case States.stairs_1:
				stairs_1();
				break;
			case States.closet_door:
				closet_door();
				break;
			case States.in_closet:
				in_closet();
				break;
			case States.stairs_2:
				stairs_2();
				break;
			case States.courtyard:
				courtyard();
				break;
		}
	}

	void cell() {
		text.text = "You are in prison. There are dirty sheets on your bed," +
		" a mirror hanged on the wall and the door is locked from the outside.\n\n" +
		"Press S to view the Sheets, M to view the Mirror and L for the Lock.";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_0;
		} else if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirror;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_0;
		}
	}

	void sheets_0() {
		text.text = "Disgusting old dirty sheets. You've had many nighmares under thoses... Nothing more to say...\n\n" +
		"Press R to Return to roaming your cell.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void lock_0() {
		text.text = "The door is locked from the outside. It's an old lock.\n\n" +
		"Press R to Return to roaming your cell.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		}
	}

	void mirror() {
		text.text = "Seeing your face in the mirror remind you of the many days you've past locked" +
		" down here. You'll be happy to have a shower... Or at least a razor...\n" +
		"But wait ! You see something, laying on the top of the mirror's frame !\n\n" +
		"Press R to Return to roaming your cell or press T to Take this strange thing.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell;
		} else if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.cell_mirror;
		}
	}

	void cell_mirror() {
		text.text = "You take what seems to be a kind of thin piece of metal. Not quiet strong but it could be bent. \n\n" +
		"Press S to view the Sheets or L to view the Lock.";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.sheets_1;
		} else if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock_1;
		}
	}

	void sheets_1() {
		text.text = "Disgusting old dirty sheets. You've had many nighmares under thoses... Nothing more to say...\n\n" +
		"Press R to Return to roaming your cell.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		}
	}

	void lock_1() {
		text.text = "With somme gigle and random movement you eventually open the lock with the" +
		" thin piece of metal you've just found, transforming it in a kind of key.\n\n" +
		"Press R to Return to roaming your cell or O to Open the door.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.cell_mirror;
		} else if (Input.GetKeyDown(KeyCode.O)) {
			myState = States.corridor_subzero;
		}
	}

	// ============= CORRIDOR =================
	void corridor_subzero() {
		text.text = "You are on the way to freedom !\n\n" +
		"The door open without a sound on an empty corridor.\n\n" +
		"Press Space to continue";
		if (Input.GetKeyDown(KeyCode.Space)) {
			myState = States.corridor_0;
		}
	}

	void corridor_0() {
		text.text = "On your right there's a closet door and there seems to be somthing on the floor.\n\n" +
		"Press S to take the Stairs, F to look at the Floor and C to view the Closet door.";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_0;
		} else if (Input.GetKeyDown(KeyCode.F)) {
			myState = States.floor;
		} else if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.closet_door;
		}
	}

	void stairs_0() {
		text.text = "The stairs on your left are going up, you hear voicies coming down to you, You need to hurry !.\n\n" +
		"Press R to Return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_0;
		}
	}

	void closet_door() {
		text.text = "On the door you can read <<cleaning staff only>>. The door is closed.\n\n" +
		"Press R to Return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_0;
		}
	}

	void floor() {
		text.text = "You see on the floor a hair clip.\n\n" +
		"Press R to Return to the corridor, H to take the Hair clip on the floor.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_0;
		} else if (Input.GetKeyDown(KeyCode.H)) {
			myState = States.corridor_1;
		}
	}

	void corridor_1() {
		text.text = "On your right there's a closet door and there seems to be somthing on the floor.\n\n" +
		"Press S to take the Stairs, P to try to pick the closet's lock.";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.stairs_1;
		} else if (Input.GetKeyDown(KeyCode.P)) {
			myState = States.in_closet;
		}
	}

	void stairs_1() {
		text.text = "The voices comming down the stairs are closer than ever. It seems that's two guards comming down.\n" +
		"You're lucky, they just stop on their way. But for how long ??\n" +
		"Press R to Return to the corridor";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_1;
		}
	}


	void in_closet() {
		text.text = "You go to the closet door and using you're previewsly found thin piece of metal and the hair" +
		" clip you successefuly pick the lock. You then rush inside the closet to hide from the guards comming down the stairs.\n\n" +
		"In this room you see some working suit, a cap and a mop\n\n" +
		"Press R to Return to the corridor, D to Disguise you as a cleaning employee.";
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.corridor_2;
		} else if (Input.GetKeyDown(KeyCode.D)) {
			myState = States.corridor_3;
		}
	}

	void corridor_2() {
		text.text = "The two guards are comming down !\n\n" +
		"Press S to take the Stairs anyway, B to go back to the closet as fast as you can.";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.courtyard;
		} else if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.in_closet;
		}
	}

	void stairs_2() {
		text.text = "The two guards saw you ! You got no escape, great work Einstein...\n\n --- GAME OVER ---\n\n" +
		"Press Space to play again";
		if (Input.GetKeyDown(KeyCode.Space)) {
			myState = States.cell;
		}
	}

	void corridor_3() {
		text.text = "You get out of the closet, dressed like a cleaning employee. " +
		"The two guards look at you for a few seconds, then go back to their discussion\n\n" +
		"Press S to take the Stairs, U to  go back to the closet and undress you.";
		if (Input.GetKeyDown(KeyCode.S)) {
			myState = States.courtyard;
		} else if (Input.GetKeyDown(KeyCode.U)) {
			myState = States.in_closet;
		}
	}

	void courtyard() {
		text.text = "Look like nobody care about a cleaning employee... You just pass through any doors, and go outside the prison\n\n" +
		"CONGRATULATION YOU ARE NOW FREE !\n\n" +
		"Press Space to play again";
		if (Input.GetKeyDown(KeyCode.Space)) {
			myState = States.cell;
		}
	}
}