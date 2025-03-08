using System.ComponentModel;
using System.ComponentModel.Design;

namespace DynamicLinkLibrary
{
    public class BeautyOfMaths
    {

        public int square(int n)
        {
            return n * n;
        }

        public int square_root(int n)
        {
            for (int i = 0; i<=n/2; i++)
            {
                if((i*i)==n)
                    return i;
            }
            return 0;
        }

    }
}
