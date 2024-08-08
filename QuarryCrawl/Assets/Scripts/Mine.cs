using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour, IInteractable
{
    [SerializeField] private int crystalType;
    //0 = blue
    //1 = purple
    //2 = orange

    public float maxVeinSize;
    public float crystalsLeft;

    public GameObject inventory;

    private float replenishCountdown;

    public Transform pick;
    [SerializeField] private bool pickGoingDown;
    [SerializeField] private float pickDownClock;
    private float timePickDown;
    private bool pickGoingUp;
    [SerializeField] private float pickUpClock;
    private float timePickUp;

    void Start()
    {
        inventory = GameObject.FindObjectOfType<InventoryScript>().gameObject;
        pick = GameObject.Find("Pickaxe").GetComponent<Transform>();
    }

    void Update()
    {
        if(pickGoingDown)
        {
            pick.Rotate(Vector3.forward, 3f/timePickDown);
            pickDownClock += Time.deltaTime;
            if(pickDownClock >= timePickDown * 0.2f)
            {
                pickGoingDown = false;
                pickGoingUp = true;
            }
        }
        if(pickGoingUp)
        {
            pick.Rotate(Vector3.forward, -0.75f/timePickUp);
            pickUpClock += Time.deltaTime;
            if(pickUpClock >= timePickUp * 0.8f)
            {
                pickGoingUp = false;
                pickDownClock = 0f;
                pickUpClock = 0f;
            }
        }
        if (crystalsLeft == 0f)
        {
            replenishCountdown -= Time.deltaTime;
            if(replenishCountdown < 0f)
            {
                Replenish();
            }
        }else
        {
            replenishCountdown = 30f;
        }
        if (crystalType == 0) 
        {
            gameObject.name = "Mine Blue Crystal " + crystalsLeft.ToString() + "/" + maxVeinSize.ToString();
        }
        if (crystalType == 1)
        {
            gameObject.name = "Mine Purple Crystal " + crystalsLeft.ToString() + "/" + maxVeinSize.ToString();
        }
        if (crystalType == 2)
        {
            gameObject.name = "Mine Orange Crystal " + crystalsLeft.ToString() + "/" + maxVeinSize.ToString();
        }

    }

    public void Interact()
    {
        if(!inventory.GetComponent<InventoryScript>().inventoryFull)
        {
            timePickDown = Interaction.instance.toolCooldown;
            timePickUp = Interaction.instance.toolCooldown;
            pickGoingDown = true;
            if (crystalsLeft > 0f)
            {
                int crystalsMined = Random.Range(1, 6);
                if(inventory.GetComponent<InventoryScript>().crystalStorage + crystalsMined > inventory.GetComponent<InventoryScript>().maxCrystalStorage)
                {
                    crystalsMined = inventory.GetComponent<InventoryScript>().maxCrystalStorage - inventory.GetComponent<InventoryScript>().crystalStorage;
                }
                inventory.GetComponent<InventoryScript>().addToInventory(crystalType, crystalsMined);
                crystalsLeft -= 1f;
                Debug.Log("Mined");
            }
            else
            {
                Debug.Log("Vein Empty");
            }
        }
        else
        {
            Debug.Log("Inventory Full");
        }
        
    }

    private void Replenish()
    {
        crystalsLeft = maxVeinSize;
    }
}
