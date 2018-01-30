using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Video;

public class ButtonBehaviour : MonoBehaviour {

    public int mode;
    public AudioSource winSound;
    public Text textForm;
    public Text passForm;
    public Image buttonImage;
    public Image winUI;
    public Image loseUI;
    public RigidbodyFirstPersonController controller;
    public string expectedPassword;
    private string currentString ="";
    public int maxDigit;
    public AudioSource sound;
    private string outputedDigit;
    private bool inMenu;
    public VideoPlayer video;
    public VideoClip clipBener;
    public void Update()
    {
        if (controller.getInMenu())
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            
        }
        else {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

    }

    private void OnTriggerStay(Collider other)
    {   
        if (other.tag == "Player") {
            textForm.text="Press F to inspect";
            if (Input.GetKeyDown(KeyCode.F))
            {   
                controller.mouseLook.lockCursor=false;
                controller.enabled = false;
                controller.setInMenu(true);
                buttonImage.gameObject.active=true;
            }
            else if (Input.GetKeyDown(KeyCode.Escape)) {
                if (mode == 0) {
                    passForm.text = "_  _  _  _";

                }
                currentString = "";

                outputedDigit = "";
                inMenu = false;
                controller.enabled = true;
                controller.setInMenu(false);
                controller.mouseLook.lockCursor = true;
                buttonImage.gameObject.active = false;
            }
        }        
    }
    public bool checkPass() {
        return currentString==expectedPassword;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            textForm.text = "";
        }
    }
    public void addChar(string c) {
        Debug.Log("mantap");
        sound.Play();
        if (currentString.Length < maxDigit) {
            currentString = currentString + "" + c;
            if (mode == 0) {
                outputedDigit = outputedDigit + c + "  ";
                passForm.text = outputedDigit + "_  _  _  _";
            }
            if (currentString.Length == maxDigit) {
                checkTrue();
            }
        }
    }
    public void checkTrue()
    {
        if (checkPass())
        {
            if (mode == 0)
            {
                buttonImage.gameObject.active = false;
                winSound.Play();
                winUI.gameObject.active = true;
            }
            else if(mode==1) {
                Debug.Log("kampret");
                
                video.clip=clipBener;
                video.Play();
                buttonImage.gameObject.active = false;
                currentString = "";
                inMenu = false;
                controller.enabled = true;
                controller.setInMenu(false);
                controller.mouseLook.lockCursor = true;
                buttonImage.gameObject.active = false;
            }
        }
        else {

            if (mode == 0)
            {
                passForm.text = "_  _  _  _";

            }
            currentString = "";
            outputedDigit = "";
            inMenu = false;
            if (controller.numWrong == 0)
            {
                loseUI.gameObject.active = true;
                controller.enabled = false;
            }
            else {
                buttonImage.gameObject.active = false;
                controller.enabled = true;
                controller.setInMenu(false);
                controller.mouseLook.lockCursor = true;
                controller.wrongInput();

            }
        }
    }
}
