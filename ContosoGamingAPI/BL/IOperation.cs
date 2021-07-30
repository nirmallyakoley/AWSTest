using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoGamingAPI.BL
{
    interface IOperation
    {
        void CreateLandmarkNode(string node);
        public int CalculateDistance(string nodeTraversal);
    }
}
