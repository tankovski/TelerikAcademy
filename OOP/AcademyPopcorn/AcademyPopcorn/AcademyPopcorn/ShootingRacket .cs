using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ShootingRacket:Racket
    {
        //Fields
        public new const string CollisionGroupString = "racket";
        private int bullets = 0;
        private int fire = 0;
        Bullet[] bulet = new Bullet[1];

        //Constructor
        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft,width)
        {
            
            this.body = GetRacketBody(width);
        }

        //Methods
        char[,] GetRacketBody(int width)
        {
            char[,] body = new char[1, width];

            for (int i = 0; i < width; i++)
            {
                body[0, i] = '=';
            }

            return body;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            foreach (var item in collisionData.hitObjectsCollisionGroupStrings)
            {

                if (item == "gift")
                {
                    bullets++;
                }
                else
                {
                    base.RespondToCollision(collisionData);
                }

            }
        }
        public void Shoot()
        {
            if (bullets>0)
            {
                fire++;
                bullets--;
            }
        }
        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (fire>0)
            {
                fire--;
                bulet[0]=new Bullet(new MatrixCoords(this.TopLeft.Row,this.TopLeft.Col+this.Width/2));
                return bulet;
            }
            else
            {
                return new List<GameObject>();
            }
        }
    }
}
