using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneGuide
{
    public interface IGuideOperation
    {
        void Register();
        void Update();
        void Delete();
        void Search();
        void Listing();
    }
}
