using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne_Repository
{
    public class MenuItemRepository
    {
        private List<MenuItem> _listOfItems = new List<MenuItem>();

        //Create
        public void AddItemToList(MenuItem item)
        {
            _listOfItems.Add(item);
        }

        //Read
        public List<MenuItem> GetItemList()
        {
            return _listOfItems;
        }

        //Delete
        public bool RemoveItemFromList(int mealNumber)
        {
            MenuItem item = GetMenuItemByNumber(mealNumber);

            if (item == null)
            {
                return false;
            }

            int initialCount = _listOfItems.Count;
            _listOfItems.Remove(item);

            if (initialCount > _listOfItems.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Helper method
        public MenuItem GetMenuItemByNumber(int mealNumber)
        {
            foreach (MenuItem item in _listOfItems)
            {
                if (item.Number == mealNumber)
                {
                    return item;
                }
            }
            return null;
        }
    }
}
