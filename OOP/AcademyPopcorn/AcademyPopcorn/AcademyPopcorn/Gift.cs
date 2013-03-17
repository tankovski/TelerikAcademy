using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class Gift:MovingObject
    {
       //Fields
        public const char Symbol = '@';
        public new const string CollisionGroupString = "gift";

        //Constructor
        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { Gift.Symbol } }, new MatrixCoords(1, 0))
        {
        }

        //Methods
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }
        public override string GetCollisionGroupString()
        {
            return Gift.CollisionGroupString;
        }
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}
