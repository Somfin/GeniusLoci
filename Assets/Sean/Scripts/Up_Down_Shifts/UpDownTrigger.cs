using UnityEngine;
using System.Collections;

public class UpDownTrigger : MonoBehaviour {


	public UpDownObject[] toMoveDown = {};
	public UpDownObject[] toMoveUp = {};

	public UpDownCollection collection;

	public bool locks = false;


	void OnTriggerEnter(Collider other) {

		if (other.tag == "Player") {

			foreach (UpDownObject i in collection.objects) {

				foreach (UpDownObject j in toMoveUp) {
					if (i == j){
						i.Up ();

						if(locks)
							i.isLocked = true;

						break;
					}

					if(!i.isLocked)
						i.Down();
				}
				if(toMoveUp.Length == 0){

					if(!i.isLocked)
						i.Down();
				}
			}
		}

		/*if (other.tag == "Player") {

			foreach (UpDownObject obj in toMoveDown) {
				obj.Down ();
			}

			foreach (UpDownObject obj in toMoveUp) {
				obj.Up ();
			}

		}*/

	}

}
