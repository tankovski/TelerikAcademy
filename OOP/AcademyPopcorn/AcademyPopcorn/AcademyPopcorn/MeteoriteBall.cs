using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class MeteoriteBall:Ball
    {
        private TrailObject[] trail = new TrailObject[1];
        
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            
        }
       
        public override IEnumerable<GameObject> ProduceObjects()
        {
            trail[0] = new TrailObject(this.TopLeft, 3);
            return this.trail;
        }
    }
}
