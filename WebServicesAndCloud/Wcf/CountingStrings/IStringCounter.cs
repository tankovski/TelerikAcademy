using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CountingStrings
{
    
    [ServiceContract]
    public interface IStringCounter
    {
        [OperationContract]
        int CountHowMuchTimesStringApersInOtherString(string text,string word);

        
    }
}
