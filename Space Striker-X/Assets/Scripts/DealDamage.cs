using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
   [SerializeField] int DamagePoints = 100;

   public int getDamagePoints()
   {
       return DamagePoints;
   }
}
