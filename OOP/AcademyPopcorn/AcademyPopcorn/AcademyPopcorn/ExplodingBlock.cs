using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ExplodingBlock : Block
    {
        //Fields
        public const char ExplodingBlockSymbol = '%';
        Explosion[] explosion = new Explosion[4];
        public new const string CollisionGroupString = "block";

        //Constructor
        public ExplodingBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body[0, 0] = ExplodingBlock.ExplodingBlockSymbol;
        }





        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed == true)
            {
                explosion[0] = new Explosion(this.TopLeft, new MatrixCoords(1, 0));
                explosion[1] = new Explosion(this.TopLeft, new MatrixCoords(-1, 0));
                explosion[2] = new Explosion(this.TopLeft, new MatrixCoords(0, -1));
                explosion[3] = new Explosion(this.TopLeft, new MatrixCoords(0, 1));
                
                return this.explosion;
            }


            return new List<GameObject>();

        }
    }
}
