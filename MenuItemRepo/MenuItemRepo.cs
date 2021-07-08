using MealClass.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealClass.Repo
{
    public class MenuItemRepo
    {
        private readonly List<MenuItemPOCO> _menuItem = new List<MenuItemPOCO>();
        //create
        public bool AddMenuItemToList(MenuItemPOCO item)
        {
            if(item is null)
            {
                return false;
            }
            _menuItem.Add(item);
            return true;
        }

        //read
        public List<MenuItemPOCO> GetMenuItems()
        {
            return _menuItem;
        }

        public MenuItemPOCO GetItemByNum(int mealNum)
        {
            foreach(MenuItemPOCO item in _menuItem)
            {
                if(item.MealNumber == mealNum)
                {
                    return item;
                }
            }
            return null;
        }

        //delete
        public bool DeleteMenuItem(int mealNum)
        {
            MenuItemPOCO item = GetItemByNum(mealNum);
            if(item is null)
            {
                return false;
            }

            int initialCount = _menuItem.Count;
            _menuItem.Remove(item);

            return initialCount > _menuItem.Count;
        }
    }
}
