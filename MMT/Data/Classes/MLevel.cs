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
        private static int currentLevel;
        public static readonly int MinLevel = 1;
        public static readonly int MaxLevel = 16;

        public static int CurrentLevel { get => currentLevel; set => currentLevel = value; }
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
            if (CurrentLevel <= MinLevel) return;
            CurrentLevel--;
            Shell.WriteLine(string.Format("进入关卡{0}", CurrentLevel), ConsoleColor.Green);
            // 移动角色位置
            LocateNearExit(true);
        }

        public static void IntoNextLevel()
        {
            if (CurrentLevel >= MaxLevel) return;
            CurrentLevel++;
            // 若当前关卡还未生成，则初始化新关卡，并加入到Levels中
            if (Levels.Count < CurrentLevel)
                Levels.Add(new MLevel(CurrentLevel));
            Shell.WriteLine(string.Format("进入关卡{0}", CurrentLevel), ConsoleColor.Green);
            // 移动角色位置
            LocateNearExit(false);
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
                    else if (mapBlock.IsProperty())
                    {
                        int index = (int)mapBlock - 51;
                        Type itemType = GENERATOR.ITEMS[index];
                        System.Reflection.ConstructorInfo constructor = itemType.GetConstructor(new Type[2] { Type.GetType("System.Byte"), Type.GetType("System.Byte") });
                        Items.Add((MItem)Convert.ChangeType(constructor.Invoke(new object[2] { x, y }), itemType));
                    }
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

        public static void LocateNearExit(bool exit)
        {
            MExit e = null;
            foreach (MItem item in Levels[CurrentLevel - 1].Items)
            {
                if (item is MExit && (item as MExit).Exit == exit?true:false)
                {
                    e = item as MExit;
                    break;
                }
            }
            MMainCharacter.Instance.LocationX = e.LocationX;
            MMainCharacter.Instance.LocationY = e.LocationY;
            bool set = false;
            for (int i = 1; i <= 4; i++)
            {
                byte x = Convert.ToByte(e.LocationX - 1);
                byte y = Convert.ToByte(e.LocationY - 1);
                switch (i)
                {
                    case 1:
                        x--;
                        if (x > 0 && Levels[CurrentLevel - 1].Map.Content[x, y] == BLOCKS.EARTH)
                        {
                            MMainCharacter.Instance.LocationX--;
                            set = true;
                        }
                        break;
                    case 2:
                        x++;
                        if (x < Levels[CurrentLevel - 1].Map.Size && Levels[CurrentLevel - 1].Map.Content[x, y] == BLOCKS.EARTH)
                        {
                            MMainCharacter.Instance.LocationX++;
                            set = true;
                        }
                        break;
                    case 3:
                        y--;
                        if (y > 0 && Levels[CurrentLevel - 1].Map.Content[x, y] == BLOCKS.EARTH)
                        {
                            MMainCharacter.Instance.LocationY--;
                            set = true;
                        }
                        break;
                    case 4:
                        y++;
                        if (y < Levels[CurrentLevel - 1].Map.Size && Levels[CurrentLevel - 1].Map.Content[x, y] == BLOCKS.EARTH)
                        {
                            MMainCharacter.Instance.LocationY++;
                            set = true;
                        }
                        break;
                }
                if (set) break;
            }
            Shell.WriteLine(string.Format("玩家位于：({0},{1})", MMainCharacter.Instance.LocationX, MMainCharacter.Instance.LocationY), ConsoleColor.Green);
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
            Type.GetType("MMT.Data.Classes.Item.HealthPotion"),
            Type.GetType("MMT.Data.Classes.Item.MagicPotion"),
            Type.GetType("MMT.Data.Classes.Item.HitPotion"),
            Type.GetType("MMT.Data.Classes.Item.PowerPotion"),
            Type.GetType("MMT.Data.Classes.Item.ArmorPotion"),
            Type.GetType("MMT.Data.Classes.Item.MagicArmorPotion"),
            Type.GetType("MMT.Data.Classes.Item.SpeedPotion"),
            // Equipment
            Type.GetType("MMT.Data.Classes.Item.StrawSandals"),
            Type.GetType("MMT.Data.Classes.Item.RustySword"),
            Type.GetType("MMT.Data.Classes.Item.Robe"),
            Type.GetType("MMT.Data.Classes.Item.RedGem"),
            Type.GetType("MMT.Data.Classes.Item.RottenStaff"),
            Type.GetType("MMT.Data.Classes.Item.SharpSword"),
            Type.GetType("MMT.Data.Classes.Item.Armor"),
            Type.GetType("MMT.Data.Classes.Item.PowerfulStaff"),
            Type.GetType("MMT.Data.Classes.Item.BlueGem"),
            Type.GetType("MMT.Data.Classes.Item.LongShoes"),
            Type.GetType("MMT.Data.Classes.Item.OverlordArmor"),
            Type.GetType("MMT.Data.Classes.Item.MerlinStaff"),
            Type.GetType("MMT.Data.Classes.Item.Excalibur"),
            Type.GetType("MMT.Data.Classes.Item.Legend")
        };
    }
}