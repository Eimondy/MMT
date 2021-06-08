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
        public virtual void Interact()
        {
            // 将该物品记录至GameProfile当中
            MMainLogic.Instance.CurrentProfile.ItemCount.Add(this);
        }
        //构造方法
        public MItem(byte locationX, byte locationY)
        {
            LocationX = locationX;
            LocationY = locationY;
        }
        public MItem(MItem item)     // 复制构造函数
        {
            LocationX = item.LocationX;
            LocationY = item.LocationY;
        }
    }
}
