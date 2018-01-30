using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinButton : MonoBehaviour {

    public int mode;
    public Image winUI;
    public ButtonBehaviour corrButton;

	// Update is called once per frame
	public void checkTrue() {
        if (corrButton.checkPass()) {
            if (mode == 0) {
                winUI.gameObject.active = true;
                this.gameObject.active = false;
            }
        }
    }
}
