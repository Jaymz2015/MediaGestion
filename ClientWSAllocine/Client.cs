using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientWSAllocine
{
    public class Client
    {

        public Client()
        {
          
        }

        public String HelloWorld()
        {
            try
            {
                ClientWSAllocine.WSAlloCine.ServiceAllocineSoapClient client = new ClientWSAllocine.WSAlloCine.ServiceAllocineSoapClient("ServiceAllocineSoap");
                return client.HelloWorld();

            }
            catch (Exception ex)
            {
                return null;
            }

           
        }

        public String HelloWorld()
        {
            try
            {
                ClientWSAllocine.WSAlloCine.ServiceAllocineSoapClient client = new ClientWSAllocine.WSAlloCine.ServiceAllocineSoapClient("ServiceAllocineSoap");
                return client.HelloWorld();

            }
            catch (Exception ex)
            {
                return null;
            }


        }


    }
}
