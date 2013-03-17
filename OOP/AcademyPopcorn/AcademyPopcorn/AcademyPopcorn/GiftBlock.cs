using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class GiftBlock:Block
    {
        //Fields
        public const char GiftBlockSymbol = '?';
        Gift[] gifts = new Gift[1];
        public new const string CollisionGroupString = "block";

        //Constructor
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = GiftBlock.GiftBlockSymbol;
        }

        //Methods
        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed == true)
            {
                gifts[0] = new Gift(this.TopLeft);

                return this.gifts;
            }


            return new List<GameObject>();

        }
    }
}
