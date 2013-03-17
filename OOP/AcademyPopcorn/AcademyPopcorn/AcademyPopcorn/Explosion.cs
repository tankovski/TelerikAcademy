using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class Explosion:Ball
    {
        //Fields
        private int lifetime = 0;
        public Explosion(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body[0, 0] = '!';
        }
        
        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
        public override string GetCollisionGroupString()
        {
            return Ball.CollisionGroupString;
        }
        public override void Update()
        {
            base.Update();
            if (this.lifetime == 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
