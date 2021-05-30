using MMT.Data.Classes.Character;
using MMT.Data.Classes.Item;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MMT.Data.Classes
{
    [Serializable]
    public class MLevel
    {
        public static readonly int MinLevel = 1;
        public static readonly int MaxLevel = 16;

        public static int CurrentLevel;
        public static int LastLevel => CurrentLevel == MinLevel ? MinLevel : CurrentLevel - 1;
        public static int NextLevel => CurrentLevel == MaxLevel ? MaxLevel : CurrentLevel + 1;

        public static List<MLevel> Levels = new List<MLevel>();

        public int LevelNumber;

        public MMap Map = new MMap();

        public List<MItem> Items = new List<MItem>();

        public List<MEnemy> Enemies = new List<MEnemy>();
        // TODO :Fix bug in "MEnemy is not public".

        public static void IntoLastLevel()
        {
            if (CurrentLevel > MinLevel)
                CurrentLevel--;
            Shell.WriteLine(string.Format("进入关卡", CurrentLevel), ConsoleColor.Green);
            // 移动角色位置
            MExit exit = (MExit)Levels[CurrentLevel - 1].Items.Where(i => (i as MExit).Exit);
            MMainCharacter.Instance.LocationX = exit.LocationX;
            MMainCharacter.Instance.LocationY = exit.LocationY;
            byte x = Convert.ToByte(exit.LocationX - 1);
            byte y = Convert.ToByte(exit.LocationY - 1);
            bool set = false;
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        if (x > 0 && Levels[CurrentLevel - 1].Map.Content[x, y] == BLOCKS.EARTH)
                        {
                            MMainCharacter.Instance.LocationX--;
                            set = true;
                        }
                        break;
                    case 2:
                        if (x < Levels[CurrentLevel - 1].Map.Size && Levels[CurrentLevel - 1].Map.Content[x, y] == BLOCKS.EARTH)
                        {
                            MMainCharacter.Instance.LocationX++;
                            set = true;
                        }
                        break;
                    case 3:
                        if (y > 0 && Levels[CurrentLevel - 1].Map.Content[x, y] == BLOCKS.EARTH)
                        {
                            MMainCharacter.Instance.LocationY--;
                            set = true;
                        }
                        break;
                    case 4:
                        if (y < Levels[CurrentLevel - 1].Map.Size && Levels[CurrentLevel - 1].Map.Content[x, y] == BLOCKS.EARTH)
                        {
                            MMainCharacter.Instance.LocationY++;
                            set = true;
                        }
                        break;
                }
                if (set) break;
            }
        }

        public static void IntoNextLevel()
        {
            if (CurrentLevel < MaxLevel) 
                CurrentLevel++;
            // 若当前关卡还未生成，则初始化新关卡，并加入到Levels中
            if (Levels.Count < CurrentLevel)
                Levels.Add(new MLevel(CurrentLevel));
            Shell.WriteLine(string.Format("进入关卡", CurrentLevel), ConsoleColor.Green);
            // 移动角色位置
            MExit enter = (MExit)Levels[CurrentLevel - 1].Items.Where(i => !(i as MExit).Exit);
            MMainCharacter.Instance.LocationX = enter.LocationX;
            MMainCharacter.Instance.LocationY = enter.LocationY;
            byte x = Convert.ToByte(enter.LocationX - 1);
            byte y = Convert.ToByte(enter.LocationY - 1);
            bool set = false;
            for (int i = 1; i <= 4; i++)
            {
                switch (i)
                {
                    case 1:
                        if( x > 0 && Levels[CurrentLevel - 1].Map.Content[x,y] == BLOCKS.EARTH)
                        {
                            MMainCharacter.Instance.LocationX--;
                            set = true;
                        }
                        break;
                    case 2:
                        if (x < Levels[CurrentLevel - 1].Map.Size && Levels[CurrentLevel - 1].Map.Content[x, y] == BLOCKS.EARTH)
                        {
                            MMainCharacter.Instance.LocationX++;
                            set = true;
                        }
                        break;
                    case 3:
                        if (y > 0 && Levels[CurrentLevel - 1].Map.Content[x, y] == BLOCKS.EARTH)
                        {
                            MMainCharacter.Instance.LocationY--;
                            set = true;
                        }
                        break;
                    case 4:
                        if (y < Levels[CurrentLevel - 1].Map.Size && Levels[CurrentLevel - 1].Map.Content[x, y] == BLOCKS.EARTH)
                        {
                            MMainCharacter.Instance.LocationY++;
                            set = true;
                        }
                        break;
                }
                if (set) break;
            }
        }

        private void InitMap()
        {
            Map.Size = OriginalMap.Sizes[CurrentLevel - 1];
            Map.Content = new BLOCKS[Map.Size,Map.Size];
            for (var i = 0; i < Map.Size; i++)
            {
                for (var j = 0; j < Map.Size; j++)
                {
                    byte x = Convert.ToByte(i + 1);
                    byte y = Convert.ToByte(j + 1);
                    MAP mapBlock = (MAP)OriginalMap.maps[CurrentLevel - 1][i, j];
                    if (mapBlock.IsWall())
                    {
                        Map.Content[i, j] = BLOCKS.WALL;
                        continue;
                    }
                    Map.Content[i, j] = BLOCKS.EARTH;
                    // 添加物品与敌人
                    // 添加出入口
                    if (mapBlock.IsExit())
                        Items.Add(new MExit(x, y, mapBlock == MAP.EXIT));
                    // 添加门
                    else if (mapBlock.IsDoor())
                    {
                        byte related = Convert.ToByte(mapBlock - 150);
                        Items.Add(new MDoor(x, y, related));
                    }
                    // 添加钥匙
                    else if (mapBlock.IsKey())
                    {
                        byte related = Convert.ToByte(mapBlock - 100);
                        Items.Add(new MKey(x, y, related));
                    }
                    // 添加物品

                    // 添加敌人
                    else if (mapBlock.IsEnemy())
                    {
                        int index = (int)mapBlock - 11;
                        Type enemyType = GENERATOR.ENEMYS[index];
                        System.Reflection.ConstructorInfo constructor = enemyType.GetConstructor(new Type[2] { Type.GetType("System.Byte"), Type.GetType("System.Byte") });
                        
                        Enemies.Add((MEnemy)Convert.ChangeType(constructor.Invoke(new object[2] { x, y }), enemyType));
                    }
                }
            }
        }

        public MLevel()
        {
            CurrentLevel = 1;
            LevelNumber = 1;
            foreach (var level in Levels.Where(level => level.LevelNumber == CurrentLevel))
            {
                Map = level.Map;
                Items = level.Items;
                Enemies = level.Enemies;
            }
        }

        public MLevel(int lv)
        {
            CurrentLevel = lv;
            LevelNumber = lv;
            InitMap();
        }
    }

    public static class GENERATOR
    {
        public static List<Type> ENEMYS = new List<Type>()
        {
            Type.GetType("MMT.Data.Classes.Character.GreenSlim"),
            Type.GetType("MMT.Data.Classes.Character.RedSlim"),
            Type.GetType("MMT.Data.Classes.Character.Bat"),
            Type.GetType("MMT.Data.Classes.Character.Zombie"),
            Type.GetType("MMT.Data.Classes.Character.Skeleton"),
            Type.GetType("MMT.Data.Classes.Character.Magician"),
            Type.GetType("MMT.Data.Classes.Character.SkeletonKnight"),
            Type.GetType("MMT.Data.Classes.Character.Gargoyle"),
            Type.GetType("MMT.Data.Classes.Character.ScytheSpider"),
            Type.GetType("MMT.Data.Classes.Character.SkeletonGeneral"),
            Type.GetType("MMT.Data.Classes.Character.GrandMaster"),
            Type.GetType("MMT.Data.Classes.Character.TheDevil")
        };

        public static List<Type> ITEMS = new List<Type>()
        {   // Potion
            Type.GetType("MMT.Data.Classes.Item.Healthpotion"),
            Type.GetType("MMT.Data.Classes.Item.Magicpotion"),
            Type.GetType("MMT.Data.Classes.Item.Hitpotion"),
            Type.GetType("MMT.Data.Classes.Item.Powerpotion"),
            Type.GetType("MMT.Data.Classes.Item.Armorpotion"),
            Type.GetType("MMT.Data.Classes.Item.MagicArmorpotion"),
            Type.GetType("MMT.Data.Classes.Item.Speedpotion"),
            // Equipment
            Type.GetType("MMT.Data.Classes.Item."),
            Type.GetType("MMT.Data.Classes.Item."),
            Type.GetType("MMT.Data.Classes.Item."),
            Type.GetType("MMT.Data.Classes.Item."),
            Type.GetType("MMT.Data.Classes.Item."),
            Type.GetType("MMT.Data.Classes.Item."),
            Type.GetType("MMT.Data.Classes.Item."),
            Type.GetType("MMT.Data.Classes.Item."),
            Type.GetType("MMT.Data.Classes.Item."),
            Type.GetType("MMT.Data.Classes.Item."),
            Type.GetType("MMT.Data.Classes.Item."),
            Type.GetType("MMT.Data.Classes.Item."),
            Type.GetType("MMT.Data.Classes.Item."),
            Type.GetType("MMT.Data.Classes.Item."),
        };
    }
}