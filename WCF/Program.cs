using System;
using System.ServiceModel;

namespace WCF
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(TelephoneBookService)))
            {
                host.Open();
                Console.WriteLine("The service is ready at {0}", host.BaseAddresses[0].AbsoluteUri);
                Console.WriteLine("Press <Enter> to stop the service");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
