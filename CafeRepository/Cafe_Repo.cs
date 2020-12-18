using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeRepository
{
    public class Cafe_Repo
    {
        private List<Cafe> _listOfCafe = new List<Cafe>();

        //C
        public void AddNewMenuItems(Cafe newMenuItem)
        {
            _listOfCafe.Add(newMenuItem);
        }

        //R
        public List<Cafe> GetMenuList()
        {
            return _listOfCafe;
        }

        //U
        public bool UpdateExisitingMenuItem(int menuId, Cafe updatedItem)
        {
            //find item
            Cafe itemToUpdate = GetMenuByNumber(menuId);

            //update menu item
            if (itemToUpdate != null)
            {
                itemToUpdate.MealNumber = updatedItem.MealNumber;
                itemToUpdate.MealName = updatedItem.MealName;
                itemToUpdate.Description = updatedItem.Description;
                itemToUpdate.Ingredinets = updatedItem.Ingredinets;
                itemToUpdate.Price = updatedItem.Price;

                return true;
            }
            else
            {
                return false;
            }
        }

        //D
        public bool RemoveItemFromList(int mealNumber)
        {
            Cafe itemToDelete = GetMenuByNumber(mealNumber);

            if (itemToDelete == null)
            {
                return false;
            }

            int intialcount = _listOfCafe.Count;
            _listOfCafe.Remove(itemToDelete);

            if(intialcount > _listOfCafe.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // helper method
        public Cafe GetMenuByNumber(int menuId)
        {
            foreach (Cafe item in _listOfCafe)
            {
                if (item.MealNumber == menuId)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
