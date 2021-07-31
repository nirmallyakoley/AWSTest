using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoGamingAPI.BL
{
   public interface IOperation
    {
        public int Stop { get; set; }
        void CreateLandmarkNode(string node);
        public int CalculateDistance(string nodeTraversal);
    }
}
