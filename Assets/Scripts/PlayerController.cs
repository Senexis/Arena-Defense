using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private NavMeshAgent agent;
    private string vertical = "Vertical_P";
    private string horizontal = "Horizontal_P";
    private string verticalRotation = "VerticalRotation_P";
    private string horizontalRotation = "HorizontalRotation_P";
    private string triggerAxis = "RightTrigger_P";

    //Fire controls, added for completness sake. Might need to be moved

    private string PrimaryFire = "ButtonA_P";
    private string SpecialPower = "LeftTrigger_P";
    private string Reload = "ButtonA_P";
    public float trigger;

    private Player currentPlayer;

    private int currentController;
    private bool canTakeDamage = true;

    public PlayerClass playerClass;

    private bool paused = false;
    private Canvas menu;
    

    private UnityEngine.UI.Slider healthSlider;
    private UnityEngine.UI.Slider ammoSlider;
    private UnityEngine.UI.Slider powerSlider;

    private UnityEngine.UI.Text healthText;
    private UnityEngine.UI.Text ammoText;
    private UnityEngine.UI.Text powerText;

    private int uiXPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        ReloadWeapon();
        Transform canvas = this.transform.Find("Canvas");
        Transform panel = canvas.Find("Panel");
        panel.transform.position = new Vector3(uiXPosition, 80, 0);
        healthSlider = panel.Find("Health").GetComponent<UnityEngine.UI.Slider>();
        Transform temp = panel.Find("Health").GetComponent<Transform>();
        temp = temp.Find("Fill Area").GetComponent<Transform>();
        healthText = temp.Find("Text").GetComponent<UnityEngine.UI.Text>();
        healthSlider.maxValue = playerClass.Health;
        healthText.text = playerClass.Health + " / " + playerClass.MaxHealth;

        ammoSlider = panel.Find("Ammo").GetComponent<UnityEngine.UI.Slider>();
        ammoSlider.maxValue = GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().getMaxAmmo();
        ammoSlider.value = GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().getCurrentAmmo();
        temp = panel.Find("Ammo").GetComponent<Transform>();
        temp = temp.Find("Fill Area").GetComponent<Transform>();
        ammoText = temp.Find("Text").GetComponent<UnityEngine.UI.Text>();

        powerSlider = panel.Find("Power").GetComponent<UnityEngine.UI.Slider>();
        powerSlider.maxValue = GetComponentInChildren<PlayerClass>().Ultimate.Cooldown;
        powerSlider.value = 0;

        ammoText.text = GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().getCurrentAmmo() + " / " + GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().getMaxAmmo();

        temp = panel.Find("Power").GetComponent<Transform>();
        temp = temp.Find("Fill Area").GetComponent<Transform>();
        powerText = temp.Find("Text").GetComponent<UnityEngine.UI.Text>();
        powerText.enabled = false;

        menu = GameObject.FindGameObjectWithTag("Menu").GetComponent<Canvas>();
        menu.enabled = false;
    }

    public void SetUIPosition(int x)
    {
        uiXPosition = x;
    }

    public void SetController(int controller)
    {
        currentController = controller;
    }

    // Update is called once per frame
    void Update()
    {
        try
        {
            var power = GetComponentInChildren<PlayerClass>().GetComponentInChildren<Power>();
            var cooldown = Mathf.RoundToInt(power.Cooldown - power.currentTimeForCooldown);

            if (cooldown > 0)
            {
                powerText.text = cooldown.ToString();
                powerSlider.value = cooldown;
                powerText.enabled = true;
            }
            else
            {
                powerSlider.value = 0;
                powerText.enabled = false;
            }
        }
        catch (System.Exception)
        {
            //
        }

        healthSlider.value = playerClass.Health;

        var currentAmmo = GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().getCurrentAmmo();

        ammoText.text = (int)currentAmmo + " / " + (int)GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().getMaxAmmo();
        ammoSlider.value = currentAmmo;


        Vector3 move = new Vector3(Input.GetAxis(horizontal + currentController), Input.GetAxis(vertical + currentController), 0);
        transform.position += move * speed * Time.deltaTime;

        float angle = Mathf.Atan2(Input.GetAxis(horizontalRotation + currentController), Input.GetAxis(verticalRotation + currentController)) * Mathf.Rad2Deg;
        if (angle != 0)
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }

        if (Input.GetButtonDown(Reload + currentController))
        {
            ReloadWeapon();
        }

        trigger = Input.GetAxis(triggerAxis + currentController);
        float leftTrigger = Input.GetAxis(SpecialPower + currentController);
        

        if (trigger != 0)
        {
            Shoot();
            
        }
        else
        {
            GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().StopFire();
        }

        if (leftTrigger != 0)
        {
            GetComponentInChildren<PlayerClass>().GetComponentInChildren<Power>().Activate();
        }
    }

    void Shoot()
    {
        GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().Fire();
    }


    void ReloadWeapon()
    {
        GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().Reload();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("We're no strangers to love");
        if (collision.gameObject.tag == "enemy")
        {
            StartCoroutine(TakeDamage());
        }
    }

    IEnumerator TakeDamage()
    {
        if (canTakeDamage)
        {
            canTakeDamage = false;
            playerClass.Health -= 10;
            healthText.text = playerClass.Health + " / " + playerClass.MaxHealth;
            if (playerClass.Health <= 0)
            {
                Destroy(gameObject);
                GetComponentInChildren<PlayerClass>().GetComponentInChildren<Weapon>().StopFire();
            }

            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, .5f); //make player transparent.
            yield return new WaitForSeconds(2f);
            GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f); //remove transparency.
            canTakeDamage = true;
        }
    }
}