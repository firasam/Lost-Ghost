using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NavigatorScript : MonoBehaviour {

    private Image lastImage;
    public Image[] collection;
    private void Start()
    {
        lastImage = collection[0];
    }
    public void changeImage(int index) {
        lastImage.gameObject.active = false;
        collection[index].gameObject.active = true;
        lastImage = collection[index];
    }
}

