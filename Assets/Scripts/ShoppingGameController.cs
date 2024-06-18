using UnityEngine.UI;
using UnityEngine;

namespace FashionHouse
{
    public class ShoppingGameController : MonoBehaviour
    {
        public float initialBudget = 5000f;
        public AudioSource incorrectAudio;
        public AudioSource correctAudio;
        public Text balance;
        public Text theExpenditure;

        private float currentBudget;
        private float expenditure;
        private int correctChoicesCount = 0;

        public Image[] inventorySlots; // Assign these in the Inspector
        public GameObject[] productPrefabs; // Assign these in the Inspector

        private void Start()
        {
            currentBudget = initialBudget;
        }

        public bool DeductBudget(float price)
        {
            if (currentBudget >= price)
            {
                currentBudget -= price;
                expenditure = 5000 - currentBudget;
                balance.text = string.Format("Balance: ${0:0.00}", currentBudget);
                theExpenditure.text = string.Format("Expenditure: ${0:0.00}", expenditure);
                return true; // Successfully deducted budget
            }
            else
            {
                return false; // Not enough budget
            }
        }

        public void OnBuyButtonClicked(int productIndex)
        {
            if (productIndex >= 0 && productIndex < productPrefabs.Length)
            {
                ProductBehavior productBehavior = productPrefabs[productIndex].GetComponent<ProductBehavior>();
                if (productBehavior != null)
                {
                 
                    if (productBehavior.isCorrectChoice)
                    {
                        // Play correct choice sound
                        correctAudio.Play();

                        bool success = DeductBudget(productBehavior.price);
                        if (success)
                        {
                            AddToInventory(productBehavior.productImage);
                            // Play correct choice sound
                            correctChoicesCount++;
                            if (correctChoicesCount == productPrefabs.Length)
                            {
                                // Level completed!
                                Debug.Log("Level successful!");
                            }
                            productPrefabs[productIndex].SetActive(false);
                        }
                    }
                    else
                    {
                        // Play incorrect choice sound
                        incorrectAudio.Play();
                    }
                }
            }
        }

        private void AddToInventory(Sprite image)
        {
            foreach (Image slot in inventorySlots)
            {
                if (slot.sprite == null)
                {
                    slot.sprite = image;
                    break; // Stop after adding to one slot
                }
            }
        }
    }
}
