using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class TrailObject:GameObject
    {
        //Fields
        private int lifeTime;
        public const char Symbol = '|';

        //Constructor
        public TrailObject(MatrixCoords topLeft,int lifeTime)
            : base(topLeft, new char[,] { { '.' } })
        {
            this.lifeTime = lifeTime;
        }

        //Methods
        public override void Update()
        {
            lifeTime--;
            if (this.lifeTime==0)
            {
                this.IsDestroyed = true;
            }
        }
        public override void RespondToCollision(CollisionData collisionData)
        {
            //base.RespondToCollision(collisionData);
        }
    }
}
