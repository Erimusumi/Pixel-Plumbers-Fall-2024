using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    public class FilterEntities
{
    public FilterEntities()
    {

    }
        
    public List<IEntity> FilterItems(List<IEntity> entities)
    {
        List<IEntity> itemList = new List<IEntity>();
        for(int i = 0; i < entities.Count(); i++)
        {
            if(entities[i].GetType() == typeof(IItem))
            {
                itemList.Add(entities[i]);
            }
        }

        return itemList;

    }

    public List<IEntity> FilterEnemies(List<IEntity> entities)
    {
        List<IEntity> enemyList = new List<IEntity>();
        for (int i = 0; i < entities.Count; i++)
        {
            Type currentEntityType = entities[i].GetType();
            if (currentEntityType == typeof(Goomba) || currentEntityType == typeof(Koopa) || currentEntityType == typeof(Goomba2))
            {
                enemyList.Add(entities[i]);
            }
        }


            return enemyList;
    }





}

