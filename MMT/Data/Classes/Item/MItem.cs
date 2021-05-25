using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace MMT.Data.Classes.Item
{
    [Serializable]
    public abstract class MItem
    {
        private string name;//物品名称
        private Bitmap image;//物品所使用的图片
        private byte locationX;//物品所在行数
        private byte locationY;//物品所在列数
        public string Name { get => name; set => name = value; }
        public Bitmap Image { get => image; set => image = value; }
        public byte LocationX { get => locationX; set => locationX = value; }
        public byte LocationY { get => locationY; set => locationY = value; }
        //道具交互方法
        public abstract void Interact();
        //构造方法
        public MItem(string name, Bitmap image, byte locationX, byte locationY)
        {
            Name = name;
            Image = image;
            LocationX = locationX;
            LocationY = locationY;
        }
        public MItem(MItem item)     // 复制构造函数
        {
            Name = item.Name;
            Image = item.Image.Clone() as Bitmap;
            LocationX = item.LocationX;
            LocationY = item.LocationY;
        }
    }
}
