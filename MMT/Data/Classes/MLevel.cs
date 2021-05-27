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

        public static List<MLevel> Levels;

        public int LevelNumber;

        public MMap Map = new MMap();

        public List<MItem> Items;

        public List<MEnemy> Enemies;
        // TODO :Fix bug in "MEnemy is not public".

        public void IntoLastLevel()
        {
            if (CurrentLevel == MinLevel) throw new Exception("Level is min level.");
            CurrentLevel--;
            foreach (var level in Levels.Where(level => level.LevelNumber == CurrentLevel))
            {
                LevelNumber = level.LevelNumber;
                Map = level.Map;
                Items = level.Items;
                Enemies = level.Enemies;
            }
        }

        public void IntoNextLevel()
        {
            if (CurrentLevel == MaxLevel) throw new Exception("Level is max level.");
            CurrentLevel++;
            var newLevel = true;
            foreach (var level in Levels.Where(level => level.LevelNumber == CurrentLevel))
            {
                newLevel = false;
                LevelNumber = level.LevelNumber;
                Map = level.Map;
                Items = level.Items;
                Enemies = level.Enemies;
            }

            if (!newLevel) return;
            Levels.Add(new MLevel(CurrentLevel));
            foreach (var level in Levels.Where(level => level.LevelNumber == CurrentLevel))
            {
                LevelNumber = level.LevelNumber;
                Map = level.Map;
                Items = level.Items;
                Enemies = level.Enemies;
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
                        Map.Content[i, j] = ((MAP) OriginalMap.maps[CurrentLevel - 1][i, j]).IsWall() ? BLOCKS.WALL : BLOCKS.EARTH;
                }
            }
            // TODO :Add items and enemies. (type missing)
        }

        public MLevel()
        {
            CurrentLevel = 1;
            LevelNumber = 1;
            Levels.Add(new MLevel(CurrentLevel));
            foreach (var level in Levels.Where(level => level.LevelNumber == CurrentLevel))
            {
                Map = level.Map;
                Items = level.Items;
                Enemies = level.Enemies;
            }
        }

        public MLevel(int lv)
        {
            LevelNumber = lv;
            InitMap();
        }

        public MLevel(MLevel level) // copy constructor
        {
            foreach (var mLevel in Levels.Where(l => l.LevelNumber == level.LevelNumber))
            {
                Map = level.Map;
                Items = level.Items;
                Enemies = level.Enemies;
            }
        }
    }
}