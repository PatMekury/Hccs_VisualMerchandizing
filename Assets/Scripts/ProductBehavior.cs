using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FashionHouse
{
    public class ProductBehavior : MonoBehaviour
    {
        public bool isCorrectChoice = false; // Set this in the Inspector
        public float price = 100f; // Set the price for each product
        public Sprite productImage; // Assign the product image in the Inspector

        private void OnBuyButtonClicked()
        {
            // Implement your logic here when the buy button is clicked
            // For example:
            if (isCorrectChoice)
            {
                // Handle correct choice behavior (deduct budget, add to inventory, etc.)
                // You can access the BudgetManager or other relevant components here
            }
            else
            {
                // Handle incorrect choice behavior (play sound, display message, etc.)
            }
        }


    }
}
